using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApplication1
{
    internal class CommonParam 
    {
        //CAN原生參數
        internal UInt32 con_maxlen = 60; //從buffer一次讀取數據的最大數量
        //設定時間相關參數, 超時處理
        internal int waitCmdSec = 3; //等待時間(Sec)


        #region 選擇UI,CANUI,CAN畫面UI
        public enum UI 
        {
            textBox_ID,
            textBox_ShowID,
        }
        #endregion

        #region 通用方法 byte_string_convert, overtimeNoResponse
        /// <summary>
        /// 將byte轉成16進制的string格式, 第一個byte前面沒有空格
        /// </summary>
        /// <param name="bytes">丟入bytes陣列, 轉換成string</param>
        /// <returns>轉成16進制的String型別, 這邊第一個byte沒有空格, 後面會有空格間隔</returns>
        internal string byte_string_convert(byte[] bytes)
        {
            int len = bytes.Length;
            //第一個byte前面不能有空格,所以獨立出來處理
            string str = "" + System.Convert.ToString(bytes[0], 16).PadLeft(2, '0');
            for (int i = 1; i < len; i++)
            {
                str += " " + System.Convert.ToString(bytes[i], 16).PadLeft(2, '0');
            }

            return str;
        }

        /// <summary>
        /// 超過等待時間後, 回傳true 反之false
        /// </summary>
        /// <param name="initialTime">此刻時間</param>
        /// <param name="waitTime">要等待的秒數</param>
        /// <returns></returns>
        internal bool overtimeNoResponse(DateTime initialTime, int waitTime)
        {
            DateTime nowTime;
            TimeSpan diffTime;
            double waitCmdTime;

            nowTime = DateTime.Now;
            diffTime = nowTime - initialTime;
            waitCmdTime = diffTime.TotalSeconds;
            if (waitCmdTime > waitTime)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
