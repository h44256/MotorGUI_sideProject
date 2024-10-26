using BinDIvideLib;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SelfProtocolLib
{
    #region config相關資訊
    /// <summary>
    /// 專門處理config資料的類別
    /// </summary>
    public static class selfProtocolConfig
    {
        public static readonly int testKey;
        static selfProtocolConfig()
        {
            NameValueCollection selfProtocolSettings = (NameValueCollection)ConfigurationManager.GetSection("selfProtocolSettings");
            testKey = Convert.ToInt32(selfProtocolSettings["testKey"]);
        }
    }
    #endregion
    public class SelfProtocol:ISelfProtocol,IBinDivide
    {
        #region 讀取config檔案資訊
        public int config_VCU_sendFrame;
        public SelfProtocol()
        {
            NameValueCollection selfProtocolSettings = (NameValueCollection)ConfigurationManager.GetSection("selfProtocolSettings");
            config_VCU_sendFrame = Convert.ToInt32(selfProtocolSettings["VCU_sendFrame"]);
        }
        #endregion
        //IBinDivide
        public string sourceFilePath { get; set; }
        public string outputFIlePath { get; set; }
        public int divideByte { get; set; }

        /*
         * 計算總共幾份,切割過後的Bin Data數量
         * ex:80KB, 1KB切一份, count_dataByte=80;
         */
        private ushort count_dataByte =00;
        private int otherCmdWriteTimes = 0;//計算writeData的時候, 接收到"非正常命令"訊息的次數。 ex:目前來說是沒收到0x2a 0x2b 0x2c之外都算是非正常命令 
        private byte high_count_dataByte = 0;
        private byte low_count_dataByte = 0;
        private ushort current_count = 0;
        private ushort reply_current_count=0; //下位機slave回傳的current_count
        private byte[][] divideData;
        private byte[] current_dataByte;
        private bool isHandShake;
        private bool isWrite;
        private bool isEnd;
        private static readonly Logger log = LogManager.GetCurrentClassLogger(); //創建NLog 物件

        /// <summary>
        /// 設定CAN現在的狀態
        /// </summary>
        public enum CAN_states
        {
            idle,//完全不做事情狀態
            silence, //靜默狀態 0x700
            waitData,  //等待狀態
            handShake, //握手狀態 1A 
            transmitData,//傳送狀態 2A 2C
            error, //錯誤狀態, 1B 2B 3B
            noResponse, //超過3秒未回應
            repeatData, //連續傳相同資料
        }
        /// <summary>
        /// 設定回覆的幀ID
        /// </summary>
        public enum CAN_frameID
        { 
            VCU_sendFrame = 130,
            VCU_receiveFrame = 131,
            MCU_sendFrame = 230,
            MCU_receiveFrame = 231,
            BMU1_sendFrame = 330,
            BMU1_receiveFrame = 331,
            BMU2_sendFrame = 340,
            BMU2_receiveFrame = 341,
            silenceFrame = 700,
            VCU_receiveVersionFrame = 0x71f,
            MCU_receiveVersionFrame = 0x72f,
            BMU1_receiveVersionFrame = 0x73f,
            BMU2_receiveVersionFrame = 0x74f,
            Charger_receiveVersionFrame = 0x75f,
        }
        public enum CAN_cmd 
        {
            cmdHandShake = 0x10,
            cmdHandShake_ok = 0x1a,
            cmdHandShake_error = 0x1b,
            cmdWriteData = 0x20,
            cmdWriteData_ok = 0x2a,
            cmdWriteData_error = 0x2b,
            cmdWriteData_currentResend = 0x2c,
            cmdEnd = 0x30,
            cmdEnd_ok = 0x3a,
            cmdEnd_error = 0x3b,
            cmdSilenceStart = 0x40,
            cmdSilenceEnd = 0x50,
            cmdUpdate = 0x60,
            cmdVersionVCU = 0x21,
            cmdVersionMCU = 0x22,
            cmdVersionBMU1 = 0x23,
            cmdVersionBMU2 = 0x24,
            cmdVersionCharger = 0x25,
        }
        public string silenceDeviceID()
        {
            return Convert.ToString((int)CAN_frameID.silenceFrame);
        }
        public string sendDeviceID(int send_deviceID) 
        {
            string str_deviceID = send_deviceID.ToString();
            return str_deviceID;
        }
        public bool checkDeviceID(int send_DeviceID, string reply_DeviceID)
        {
            //VCU 131
            if (send_DeviceID == Convert.ToInt32(CAN_frameID.VCU_sendFrame) && reply_DeviceID == Convert.ToString((int)CAN_frameID.VCU_receiveFrame))
                return true;
            //MCU 231
            if (send_DeviceID == Convert.ToInt32(CAN_frameID.MCU_sendFrame) && reply_DeviceID == Convert.ToString((int)CAN_frameID.MCU_receiveFrame))
                return true;
            //BMU#1 331
            if (send_DeviceID == Convert.ToInt32(CAN_frameID.BMU1_sendFrame) && reply_DeviceID == Convert.ToString((int)CAN_frameID.BMU1_receiveFrame))
                return true;
            //BMU#2 341
            if (send_DeviceID == Convert.ToInt32(CAN_frameID.BMU2_sendFrame) && reply_DeviceID == Convert.ToString((int)CAN_frameID.BMU2_receiveFrame))
                return true;

            return false;
        }
        public byte[] cmdUpdate() 
        {
            byte[] cmd = new byte[8];
            cmd[0] = (byte)CAN_cmd.cmdUpdate; 
            for (int i = 1; i < 8; i++)
            {
                cmd[i] = 0x87;
            }
            return cmd;
        }
        public byte[] cmdNONONO()
        {
            byte[] cmd = new byte[8];
            cmd[0] = 0x80 ;
            for (int i = 1; i < 8; i++)
            {
                cmd[i] = 0x87;
            }
            return cmd;
        }
        public byte[] cmdSilenceStart()
        {
            byte[] cmd = new byte[8];
            cmd[0] = (byte)CAN_cmd.cmdSilenceStart;
            for (int i = 1; i < 8; i++)
            {
                cmd[i] = 0x87;
            }
            return cmd;
        }
        public byte[] cmdSilenceEnd()
        {
            byte[] cmd = new byte[8];
            cmd[0] = (byte)CAN_cmd.cmdSilenceEnd;
            for (int i = 1; i < 8; i++)
            {
                cmd[i] = 0x87;
            }
            return cmd;
        }
        public byte[] cmdHandShake() 
        {
            //發送handShake指令
            byte[] cmd = new byte[8];
            //cmd[0] = 0x10;
            cmd[0] = (byte)CAN_cmd.cmdHandShake;
            //cmd[1] = (byte)(count_dataByte - 1); //舊協議 -> 只有一個byte傳送總共資料序列數
            cmd[1] = high_count_dataByte; //現行版本改成2Byte 高位
            cmd[2] = low_count_dataByte; //現行版本改成2Byte 低位
            for (int i = 3; i < 8; i++) 
            {
                cmd[i] = 0xff;
            }
            return cmd;
        }
        public bool check_cmdHandShake(byte reply)
        {
            if (reply == (byte)CAN_cmd.cmdHandShake_ok)
            {
                isHandShake = true;
                return isHandShake;
            }
            else if (reply == (byte)CAN_cmd.cmdHandShake_error)
            {
                isHandShake = false;
                current_count = 0;
                return isHandShake;
            }
            else 
            {
                isHandShake = false;
                return isHandShake;
            }
        }
        public void handShake()
        {
            if (isHandShake)
            {
                //做後續動作
                current_count = 0;
            }
            else if(isHandShake)
            {
                cmdHandShake();
            }
        }

        public byte[] cmdWriteData() 
        {
            //發送write指令
            byte[] cmd = new byte[8];
            cmd[0] = (byte)CAN_cmd.cmdWriteData;
            //cmd[1] = current_count;//舊協議 -> 只有一個byte傳送總共資料序列數
            //處理current_count
            byte high_current_count = (byte)(current_count >> 8);
            byte low_current_count = (byte)(current_count & 0xff);
            cmd[1] = high_current_count;
            cmd[2] = low_current_count;
            for (int i = 3; i < 8; i++)
            {
                cmd[i] = 0xff;
            }
            return cmd;
        }
        /// <summary>
        /// 確認韌體下位機writeData(寫入資料)的回傳序號是到多少, 用來確認Host這邊是不是相同
        /// </summary>
        /// <param name="bytes">傳byte[] 第一個是高位, 第二個是低位</param>
        /// <returns></returns>
        public void check_replyWriteSerial(byte[] bytes)
        {
            ushort highByte = (ushort)(bytes[0] << 8);
            ushort lowByte = (ushort)(bytes[1] & 0xFF);
            reply_current_count = (ushort)(highByte + lowByte);
        }
        public bool check_cmdWrite(byte reply) 
        {
            if (reply == (byte)CAN_cmd.cmdWriteData_ok && current_count == count_dataByte - 1)
            {
                isWrite = false;
                //cmdEnd();
                return isWrite;
            }
            else if (reply == (byte)CAN_cmd.cmdWriteData_ok)
            {
                isWrite = true;
                current_count++;
                return isWrite;
            }
            else if (reply == (byte)CAN_cmd.cmdWriteData_error)
            {
                isWrite = false;
                current_count = 0;
                return isWrite;
            }
            else if (reply == (byte)CAN_cmd.cmdWriteData_currentResend)
            {
                current_count = reply_current_count;//current resend, 把現在的current_count換成下位機要求的current_count
                isWrite = true;
                return isWrite;
            }
            else if (current_count == 0 && otherCmdWriteTimes == 0)
            {
                otherCmdWriteTimes++;
                log.Info("第一次寫入, 收到發送命令 :0 是正常現象, current_count = 0 與 otherCmdWriteTimes =1  代表確實第一次寫入 -->" +
                    "實際current_count = " + current_count + ", " + "實際otherCmdWriteTimes = " + otherCmdWriteTimes + "次, 收到的發送命令是 : " + reply + "!! ");
                //WriteLog("current_count = "+current_count+", " + "非2a2b2c的雜訊出現第 " + otherCmdWriteTimes + "次, 收到的訊息是 : " + reply + "!! " +
                    //",如果current_count = 0 ,且非2a2b2c雜訊是第1次, 代表第一次寫入, 收到發送命令 :0 是正常現象");
                isWrite = true;
                return isWrite;
            }
            else
            {
                isWrite = false;
                return isWrite;
            }
        }

        public byte[] writeData()
        {
            //實際寫入當前被切割的檔案
            if (isWrite)
            {
                return current_dataByte = divideData[current_count];
            }
            else if (current_count == count_dataByte) 
            {
                return null;
            }
            else
            {
                cmdHandShake();
                return null;
            }
        }

        public byte[] cmdEnd()
        {
            //發送end指令
            byte[] cmd = new byte[8];
            //cmd[0] = 0x30;
            cmd[0] = (byte)CAN_cmd.cmdEnd;
            //cmd[1] = current_count;// 舊協議 -> 只有一個byte傳送總共資料序列數
            byte high_current_count = (byte)(current_count >> 8);
            byte low_current_count = (byte)(current_count & 0xff);
            cmd[1] = high_current_count;
            cmd[2] = low_current_count;
            for (int i = 3; i < 8; i++)
            {
                cmd[i] = 0xff;
            }
            return cmd;
        }
        //內部判斷是否要結束
        public bool check_cmdEnd(byte reply)
        {
            if (reply == (byte)CAN_cmd.cmdEnd_ok)
            {
                isEnd = true;
                current_count = 0;
                return isEnd;
            }
            else if (reply == (byte)CAN_cmd.cmdEnd_error)
            {
                isEnd = false;
                current_count = 0;
                return isEnd;
            }
            else 
            {
                //確定是否還要,直接true
                //isEnd = true;
                return isEnd;
            }
        }

 
        /// <summary>
        /// 檢查版本號,丟入現在更新的裝置DeviceID(下位機Slave) ex:VCU(130),MCU(230)
        /// </summary>
        /// <param name="send_DeviceID">下位機的ID,SlaveID </param>
        /// <returns></returns>
        public byte[] cmdVerifyVersion(int send_DeviceID) 
        {
            //發送end指令
            byte[] cmd = new byte[8];
            switch (send_DeviceID) 
            {
                case (int)CAN_frameID.VCU_sendFrame:
                    cmd[0] = (byte)CAN_cmd.cmdVersionVCU;
                    break;
                case (int)CAN_frameID.MCU_sendFrame:
                    cmd[0] = (byte)CAN_cmd.cmdVersionMCU;
                    break;
                case (int)CAN_frameID.BMU1_sendFrame:
                    cmd[0] = (byte)CAN_cmd.cmdVersionBMU1;
                    break;
                case (int)CAN_frameID.BMU2_sendFrame:
                    cmd[0] = (byte)CAN_cmd.cmdVersionBMU2;
                    break;
                    //cmdVersionCharger 因為還沒有相關的MCU(晶片)所以先不寫, 要用時再補上
            }
            cmd[1] = 0xfc;
            for (int i = 2; i < 8; i++)
            {
                cmd[i] = 0xff;
            }
            return cmd;
        }

        //Eason提供的CRC算法
        public ushort Crc16AugCcitt(byte[] data, int length) 
        {
            //Crc16AugCcitt function
            ushort crc = 0x1D0F;//初始值為0x1D0F
            for (int i = 0; i < length; i++)
            {
                crc ^= (ushort)(data[i] << 8);
                for (int j = 0; j < 8; j++) 
                {
                    if ((crc & 0x8000) != 0)
                    {
                        crc = (ushort)((crc << 1) ^ 0x1021); //多項式 0x1021 (CRC-16/CCITT)
                    }
                    else
                    {
                        crc <<= 1;
                    }
                }
            }
            return crc;
        }

        //運算CRC -> 有包含寫入命令

        //public byte[] CRC_Byte()
        //{
        //    byte[] currentByte = writeData();
        //    byte[] CmdDataByte = new byte[currentByte.Length + cmdWriteData().Length]; //創建寫入命令+Data大小的陣列
        //    Array.Copy(cmdWriteData(), 0, CmdDataByte, 0, cmdWriteData().Length);//寫入命令 複製到陣列中
        //    Array.Copy(currentByte, 0, CmdDataByte, cmdWriteData().Length, currentByte.Length);// Data 複製到陣列中
        //    ushort CRC16AugCcitt = Crc16AugCcitt(CmdDataByte, CmdDataByte.Length);// 利用公式得到CRC的值,CRC16AugCcitt
        //    //進行CRC 高低位運算
        //    byte CRC_highByte = (byte)(CRC16AugCcitt >> 8); //高位
        //    byte CRC_lowByte = (byte)(CRC16AugCcitt & 0xff);//低位
        //    byte[] CRC_Byte = new byte[8]; //透過CAN傳送的最終CRC值
        //    CRC_Byte[0] = CRC_highByte;
        //    CRC_Byte[1] = CRC_lowByte;
        //    for (int i = 2; i < CRC_Byte.Length; i++)
        //    {
        //        CRC_Byte[i] = 0xff;
        //    }
        //    return CRC_Byte;
        //}

        //運算CRC -> 沒包含寫入命令
        public byte[] CRC_Byte()
        {
            byte[] currentByte = writeData();
            //byte[] CmdDataByte = new byte[currentByte.Length + cmdWriteData().Length]; //創建寫入命令+Data大小的陣列
            byte[] CmdDataByte = new byte[currentByte.Length]; //創建寫入命令+Data大小的陣列
            //Array.Copy(cmdWriteData(), 0, CmdDataByte, 0, cmdWriteData().Length);//寫入命令 複製到陣列中
            Array.Copy(currentByte, 0, CmdDataByte, 0, currentByte.Length);// Data 複製到陣列中
            ushort CRC16AugCcitt = Crc16AugCcitt(CmdDataByte, CmdDataByte.Length);// 利用公式得到CRC的值,CRC16AugCcitt
            //進行CRC 高低位運算
            byte CRC_highByte = (byte)(CRC16AugCcitt >> 8); //高位
            byte CRC_lowByte = (byte)(CRC16AugCcitt & 0xff);//低位
            byte[] CRC_Byte = new byte[8]; //透過CAN傳送的最終CRC值
            CRC_Byte[0] = CRC_highByte;
            CRC_Byte[1] = CRC_lowByte;
            for (int i = 2; i < CRC_Byte.Length; i++)
            {
                CRC_Byte[i] = 0xff;
            }
            return CRC_Byte;
        }

        //設定公開方法提供給 子程式(繼承這個程式的程式)使用get, set getset
        public ushort getCurrent_count() 
        {
            return current_count;
        }
        public void setCurrentCount(ushort sss) { current_count = sss; }
        public ushort getReplyCurrent_count() 
        {
            return reply_current_count;
        }
        public ushort getCount_dataByte() 
        {
            return count_dataByte; // 其實就是divideData.Length
        }

        public void setOtherCmdWriteTimes(int setTimes) 
        {
            otherCmdWriteTimes = setTimes;
        }

        //需要使用BinDivide功能,都從工廠內部使用
        public void binDivideFactory(string sourceFilePath, int divideByte)
        {
            BinDivide binDivide = new BinDivide(sourceFilePath, divideByte);
            binDivide.runBin();
            divideData = binDivide.divideData;
            count_dataByte = (ushort)divideData.Length;

            //處理count_dataByte -> 現在是ushort 下面改成高低位 2Bytes      
            high_count_dataByte = (byte)(count_dataByte - 1 >> 8); //高位
            low_count_dataByte = (byte)(count_dataByte - 1 & 0xff);//低位
        }
        public void binDivideFactory(string sourceFilePath, string OutputFilePath, int divideByte)
        {
            BinDivide binDivide = new BinDivide(sourceFilePath, OutputFilePath, divideByte);
            binDivide.runBin();
            divideData = binDivide.divideData;
            count_dataByte = (ushort)divideData.Length;

            //處理count_dataByte -> 現在是ushort 下面改成高低位 2Bytes      
            high_count_dataByte = (byte)(count_dataByte-1 >> 8); //高位
            low_count_dataByte = (byte)(count_dataByte-1 & 0xff);//低位
        }

        //From BootLoader.BinDivide
        public void runBInDivide(string sourceFilePath, string OutputFilePath, int divideByte)
        {
            BinDivide binDivide = new BinDivide(sourceFilePath, OutputFilePath, divideByte);
            binDivide.runBInDivide();
        }

        public void WriteLog(String logMsg) 
        {
            BinDivide binDivide = new BinDivide();
            binDivide.WriteLog(logMsg);
        }

    }
}
