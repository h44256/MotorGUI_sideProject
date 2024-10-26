using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSProtocol
{
    public abstract class abs_Bms_Protocol:IBms_Protocol
    {
        public byte BMS_ID { get; set; }
        public enum BMS_States 
        {
            setMode,
            readMode,
            SuccessfulDelivery,
            FailedDelivery,
            noResponse,
        }

        public enum BMS_frameID 
        {
            checkId1 = 300,
            checkId2 = 310,
            setID = 350,
            setID_Reply = 351,
            readID = 360,
            readID_Reply = 361,
        }
        /// <summary>
        /// 設定發送cmdSetID時, 當下Host的frameID
        /// </summary>
        /// <returns></returns>
        public string Bms_setHostFrame()
        {
            return Convert.ToInt32(BMS_frameID.setID).ToString();
            //return "350";
        }
        public byte[] Bms_cmdSetID(byte ID) 
        {
            byte[] sendBmsByte = new byte[8];
            int len = sendBmsByte.Length;
            sendBmsByte[0] = 0x01; //定值0x01
            sendBmsByte[1] = ID;
            for (int i = 2; i < len; i++)
            {
                sendBmsByte[i] = 0x87;
            }
            return sendBmsByte;
        }
        /// <summary>
        /// 丟入byte[]進來,取得這次設置ID成功與否, 0代表成功, 1代表失敗
        /// </summary>
        /// <param name="replyIDSet"></param>
        /// <returns></returns>
        public byte Bms_cmdSetIDReply(byte[] replyIDSet) 
        {
            byte cmdIdSetResult = replyIDSet[2];
            return cmdIdSetResult;
        }
        /// <summary>
        /// 設定發送cmdReadID時, 當下Host的frameID
        /// </summary>
        /// <returns></returns>
        public string Bms_readHostFrame()
        {
            return Convert.ToInt32(BMS_frameID.readID).ToString();
            //return "360";
        }
        public byte[] Bms_cmdReadID()
        {
            byte[] sendBmsByte = new byte[8];
            int len = sendBmsByte.Length;
            sendBmsByte[0] = 0x01; //定值0x01
            for (int i = 1; i < len; i++)
            {
                sendBmsByte[i] = 0x87;
            }
            return sendBmsByte;
        }
        /// <summary>
        /// 丟byte[]進來, 直接得到BMS_ID
        /// </summary>
        /// <param name="IDBytes"></param>
        /// <returns></returns>
        public byte Bms_cmdReadIDReply(byte[] IDBytes) 
        {
            BMS_ID = IDBytes[1];
            return BMS_ID;
        }

    }
}
