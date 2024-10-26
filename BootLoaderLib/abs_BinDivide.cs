using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinDIvideLib
{
    public abstract class abs_BinDivide:IBinDivide
    {
        //繼承IBinDivide 
        public string sourceFilePath { get; set; }
        public string outputFIlePath { get; set; }
        public int divideByte { get; set; }
        //自身變數
        public byte[][] divideData; //切割的資料, 第一個是放總KB數, 第二個是放切割KB大小,ex: 100K 切512bytes 第一個就是200 第二個是512
        //多執行緒操作, 同步threads操作
        private static readonly object locker = new object();//增加locker 避免同時多開檔案造成error
        public void runBin() 
        {
            try
            {
                lock (locker) 
                {
                    // 使用 FileStream 打開原始檔案
                    using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open))
                    {
                        long divideNum = sourceStream.Length / divideByte;//切幾個檔案
                        divideData = new byte[divideNum + 1][];
                        for (int i = 0; i <= divideNum; i++)
                        {
                            long startOffset;
                            long endOffset;
                            if (i < divideNum)
                            {
                                // 要保留的資料範圍（假設要從第 10 個位元組到第 20 個位元組）
                                startOffset = i * divideByte;
                                endOffset = (i + 1) * divideByte;
                                //endOffset = sourceStream.Length;

                                divideData[i] = doBinFileStream(startOffset, endOffset, sourceStream);

                            }
                            else
                            {
                                startOffset = i * divideByte;
                                endOffset = (i + 1) * divideByte;
                                divideData[i] = doBinFileStream(startOffset, endOffset, sourceStream);


                                //用於寫入ff 補滿1KB時使用
                                startOffset = sourceStream.Length - i * divideByte;
                                endOffset = endOffset - i * divideByte;
                                //原本j的終點 endOffset - startOffset ->寫錯囉, 這邊創立第二個陣列
                                for (int j = (int)startOffset; j < endOffset; j++)
                                {
                                    divideData[i][j] = 0xff;
                                }
                            }

                        }
                    }

                    Console.WriteLine("檔案已成功修改。");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"修改檔案時發生錯誤：{e.Message}");
            }
        }

        public void runBInDivide()
        {
            try
            {   //記得設定文件本打開時是UTF-16,如果是UTF8會讀錯
                // 使用 FileStream 打開原始檔案
                using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open))
                {
                    //切幾個檔案
                    long divideNum = sourceStream.Length / divideByte;
                    //產生的檔案名稱
                    string outputFileName;
                    for (int i = 0; i <= divideNum; i++)
                    {
                        //設定切割後檔案的名字
                        outputFileName = $"{i}.bin";
                        string outputFilePath = outputFIlePath + "\\" + outputFileName;
                        if (!File.Exists(outputFilePath))
                        {
                            using (File.Create(outputFilePath)) ;
                        }
                        // 使用 FileStream 創建或覆寫目標檔案
                        using (FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create))
                        {
                            long startOffset;
                            long endOffset;
                            if (i < divideNum)
                            {
                                // 要保留的資料範圍（假設要從第 10 個位元組到第 20 個位元組）
                                startOffset = i * divideByte;
                                endOffset = (i + 1) * divideByte;

                                doBinFileStream(startOffset, endOffset, sourceStream, outputFileStream);

                            }
                            else
                            {
                                startOffset = i * divideByte;
                                endOffset = sourceStream.Length;

                                doBinFileStream(startOffset, endOffset, sourceStream, outputFileStream);

                                //用於寫入ff 補滿1KB時使用
                                using (BinaryWriter writer = new BinaryWriter(outputFileStream))
                                {
                                    startOffset = endOffset;
                                    endOffset = (i + 1) * divideByte;
                                    for (int j = 0; j < endOffset - startOffset; j++)
                                    {
                                        byte[] newData = { 0xFF };
                                        writer.Write(newData);
                                    }
                                }

                            }

                        }
                    }
                }

                Console.WriteLine("檔案已成功修改。");
            }
            catch (IOException e)
            {
                Console.WriteLine($"修改檔案時發生錯誤：{e.Message}");
            }
        }
        //讀檔案+切割檔案
        private void doBinFileStream(long startOffset, long endOffset, FileStream sourceStream, FileStream outputFileStream)
        {
            // 要保留的資料範圍（假設要從第 10 個位元組到第 20 個位元組）
            //startOffset = i * divideByte;
            //endOffset = (i + 1) * divideByte;
            // 設定讀取位置
            sourceStream.Seek(startOffset, SeekOrigin.Begin);

            // 設定寫入位置
            outputFileStream.Seek(0, SeekOrigin.Begin);

            // 創建緩衝區
            byte[] buffer = new byte[endOffset - startOffset];

            // 讀取並寫入資料直到結束
            sourceStream.Read(buffer, 0, buffer.Length);

            // 寫入目標檔案
            outputFileStream.Write(buffer, 0, buffer.Length);
        }
        //單純讀檔案
        private byte[] doBinFileStream(long startOffset, long endOffset, FileStream sourceStream)
        {
            // 設定讀取位置
            sourceStream.Seek(startOffset, SeekOrigin.Begin);

            // 創建緩衝區
            byte[] buffer = new byte[endOffset - startOffset];

            // 讀取並寫入資料直到結束
            sourceStream.Read(buffer, 0, buffer.Length);
            return buffer;
        }

        //增加Writelog功能, 目前路徑跟檔案名稱 先鎖定,後面再來處理
        //private static String logPath = "D:\\SW&FW工作資料\\BootLoader"; //Log目錄 -> 笨寫法 直接寫死
        String logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);//Log目錄 -> AppDomain.CurrentDomain.BaseDirectory取得當前目錄
        public void WriteLog(String logMsg)
        {
            //檔案名稱 使用現在日期
            String logFileName = DateTime.Now.Year.ToString() + int.Parse(DateTime.Now.Month.ToString()).ToString("00") + int.Parse(DateTime.Now.Day.ToString()).ToString("00") + ".txt";
            //String logFileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";  //語法糖
            
            //Log檔內的時間 使用現在時間
            //String nowTime = int.Parse(DateTime.Now.Hour.ToString()).ToString("00") + ":" + int.Parse(DateTime.Now.Minute.ToString()).ToString("00") + ":" + int.Parse(DateTime.Now.Second.ToString()).ToString("00");
            string nowTime = DateTime.Now.ToString("HH:mm:ss.fff"); //語法糖

            if (!Directory.Exists(logPath))
            {
                //建立資料夾
                Directory.CreateDirectory(logPath);
            }

            if (!File.Exists(logPath + "\\" + logFileName))
            {
                //建立檔案
                //File.Create(logPath + "\\" + logFileName).Close();
                using (File.Create(logPath + "\\" + logFileName)) ;
            }

            lock (locker) 
            {
                //using (StreamWriter sw = File.AppendText(logPath + "\\" + logFileName))
                StreamWriter sw = File.AppendText(logPath + "\\" + logFileName);
                {
                    //WriteLine為換行 
                    sw.Write(nowTime + "---->");
                    sw.WriteLine(logMsg);
                    sw.WriteLine("");
                    sw.Close();
                }
            }
        }

    }
}
