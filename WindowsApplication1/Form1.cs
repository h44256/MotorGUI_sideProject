using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Threading;
using System.Collections.Specialized;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using NLog;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using WindowsApplication1.Properties;
using Parameters;
using Parameters.Factory;
using Microsoft.SqlServer.Server;
using NLog.LayoutRenderers;
using Parameters.ExtensionAttribute;
using Parameters.ManagerAttr;


#region CAN原生範例程式的Struct區域
//1.ZLGCAN系列接口卡信息的数据类型。
//目前沒用到
public struct VCI_BOARD_INFO
{
    public UInt16 hw_Version;
    public UInt16 fw_Version;
    public UInt16 dr_Version;
    public UInt16 in_Version;
    public UInt16 irq_Num;
    public byte can_Num;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)] public byte[] str_Serial_Num;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
    public byte[] str_hw_Type;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public byte[] Reserved;
}


/////////////////////////////////////////////////////
//2.定义CAN信息帧的数据类型。
//2.用來判斷VCI_Transmit 和 VCI_Receive 的CAN 訊息幀
unsafe public struct VCI_CAN_OBJ  //使用不安全代码
{
    public uint ID;//幀ID
    public uint TimeStamp;// 表示接收到信息幀的時間標識
    public byte TimeFlag;// 1表示 TimeStamp有效, 只在接收幀時有效果
    public byte SendType;//發送幀 0 正常發送 1單次發送 2自發自收 3單次自發自收
    public byte RemoteFlag;//是否是远程帧
    public byte ExternFlag;//是否是扩展帧
    public byte DataLen;//Data長度

    public fixed byte Data[8];

    public fixed byte Reserved[3];//系統保留變數, 沒有功能

}
////2.定义CAN信息帧的数据类型。
//public struct VCI_CAN_OBJ 
//{
//    public UInt32 ID;
//    public UInt32 TimeStamp;
//    public byte TimeFlag;
//    public byte SendType;
//    public byte RemoteFlag;//是否是远程帧
//    public byte ExternFlag;//是否是扩展帧
//    public byte DataLen;
//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//    public byte[] Data;
//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//    public byte[] Reserved;

//    public void Init()
//    {
//        Data = new byte[8];
//        Reserved = new byte[3];
//    }
//}

//3.定义CAN控制器状态的数据类型。
//目前沒用到
public struct VCI_CAN_STATUS
{
    public byte ErrInterrupt; //中斷紀錄 , 讀操作清除
    public byte regMode; //CAN 控制器模式寄存器
    public byte regStatus;//CAN 控制器狀態寄存器
    public byte regALCapture;//CAN控制器 仲裁丟失寄存器
    public byte regECCapture;//CAN控制器 錯誤寄存器
    public byte regEWLimit;//CAN控制器 錯誤警告限制寄存器
    public byte regRECounter;//CAN控制器  接收錯誤寄存器 0-127 active 128-254 passive 255 關閉總線狀態
    public byte regTECounter;//CAN控制器  發收錯誤寄存器 0-127 active 128-254 passive 255 關閉總線狀態
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] Reserved;
}

//4.定义错误信息的数据类型。
//目前沒用到
public struct VCI_ERR_INFO
{
    public UInt32 ErrCode; //錯誤碼
    public byte Passive_ErrData1; // 當產生的錯誤中有"消極錯誤"時 表示為"消極錯誤"的錯誤標識數據。
    public byte Passive_ErrData2;
    public byte Passive_ErrData3;
    public byte ArLost_ErrData; // 當產生的錯誤中有"仲裁丟失"錯誤時 表示為"仲裁丟失"錯誤的錯誤標識數據。
}

//5.定义初始化CAN的数据类型
public struct VCI_INIT_CONFIG
{
    //目前還沒找到Acc碼的表格
    public UInt32 AccCode; //驗收碼 
    public UInt32 AccMask; //屏蔽碼
    public UInt32 Reserved; // 保留
    public byte Filter; //濾波方式
    public byte Timing0; //定時器0 (BTR0)
    public byte Timing1; //定時器1 (BTR1)
    public byte Mode; //模式
}
//沒有使用到
public struct CHGDESIPANDPORT
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    public byte[] szpwd;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public byte[] szdesip;
    public Int32 desport;
    public void Init()
    {
        szpwd = new byte[10];
        szdesip = new byte[20];
    }
}
#endregion


namespace WindowsApplication1
{
    public partial class Form1 : Form
    {

        #region 定義使用裝置類型的編號
        const int VCI_PCI5121 = 1;
        const int VCI_PCI9810 = 2;
        const int VCI_USBCAN1 = 3;
        const int VCI_USBCAN2 = 4;
        const int VCI_USBCAN2A = 4;
        const int VCI_PCI9820 = 5;
        const int VCI_CAN232 = 6;
        const int VCI_PCI5110 = 7;
        const int VCI_CANLITE = 8;
        const int VCI_ISA9620 = 9;
        const int VCI_ISA5420 = 10;
        const int VCI_PC104CAN = 11;
        const int VCI_CANETUDP = 12;
        const int VCI_CANETE = 12;
        const int VCI_DNP9810 = 13;
        const int VCI_PCI9840 = 14;
        const int VCI_PC104CAN2 = 15;
        const int VCI_PCI9820I = 16;
        const int VCI_CANETTCP = 17;
        const int VCI_PEC9920 = 18;
        const int VCI_PCI5010U = 19;
        const int VCI_USBCAN_E_U = 20;
        const int VCI_USBCAN_2E_U = 21;
        const int VCI_PCI5020U = 22;
        const int VCI_EG20T_CAN = 23;
        const int VCI_PCIE9221 = 24;
        const int VCI_PCIE9211 = 25;
        #endregion

        #region 從dll引入方法, 參數為 DeviceType, DeviceInd, Reserved
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DeviceType"></param>
        /// <param name="DeviceInd"></param>
        /// <param name="Reserved"></param>
        /// <returns></returns>
        /// 
        //開啟CAN裝置連接
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_OpenDevice(UInt32 DeviceType, UInt32 DeviceInd, UInt32 Reserved);
        //關閉CAN裝置連接
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_CloseDevice(UInt32 DeviceType, UInt32 DeviceInd);
        //初始化指定CAN裝置
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_InitCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_INIT_CONFIG pInitConfig);
        //確認有從buffer接收資料但還沒讀取到Host的總數
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_GetReceiveNum(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        //啟動CAN
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_StartCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        //重置CAN
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ResetCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        //Host發送的幀數，一筆8bytes資料算是一幀。
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_Transmit(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pSend, UInt32 Len);
        //Host接收的幀數，一筆8bytes資料算是一幀。
        [DllImport("controlcan.dll", CharSet = CharSet.Ansi)]
        static extern UInt32 VCI_Receive(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, IntPtr pReceive, UInt32 Len, Int32 WaitTime);
        //沒用到的方法
        //[DllImport("controlcan.dll")]
        //static extern UInt32 VCI_Receive(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pReceive, UInt32 Len, Int32 WaitTime);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ReadBoardInfo(UInt32 DeviceType, UInt32 DeviceInd, ref VCI_BOARD_INFO pInfo);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ReadErrInfo(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_ERR_INFO pErrInfo);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ReadCANStatus(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_STATUS pCANStatus);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_GetReference(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, ref byte pData);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_SetReference(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, ref byte pData);
        [DllImport("controlcan.dll")]
        internal static extern UInt32 VCI_ClearBuffer(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd); //有藉由CommonParam去讓btlLib使用, 所以設定internal
        #endregion

        #region CAN使用的定義變數
        //CAN 使用的定義變數
        static UInt32 m_devtype = 4;//USBCAN2
        //m_bOpen ->用於buttonConnect "1" 代表連接成功, "0" 代表斷開連接
        UInt32 m_bOpen = 0;
        UInt32 m_devind = 0;
        UInt32 m_canind = 0;

        VCI_CAN_OBJ[] m_recobj = new VCI_CAN_OBJ[50];

        UInt32[] m_arrdevtype = new UInt32[20];
        #endregion

        #region 自定義變數form1裡面的變數
        //自定義變數區域
        int serial_ReceiveNum = 0; //接收數據的文字提示, 創建接收數據時的計數變數
        string frameID; // CAN幀ID

        //CAN 目前狀態
        uint canStop = 0; //防呆用, 參考VCI_ResetCAN, 把停止訊息放入 全域變數canStop  -> 為了判斷現在是 開始CAN還是停止CAN
        uint canStart = 0;//防呆用, 參考VCI_startCAN, 把開始訊息放入 全域變數canStart -> 為了判斷現在是 開始CAN還是停止CAN

        //Event相關全域變數
        Object global_sender;
        EventArgs global_e;

        //Control區域, 控制相關
        double[] Control_paramValue = new double[4]; //用來記錄Control頁面的 4個textbox數值
        [ParamValue(0.5,5)]
        double Control_textBoxTPSValue;
        [ParamValue(0,100)]
        double Control_textBoxPhaseCurValue;
        [ParamValue(0,100)]
        double Control_textBoxDutyValue;
        [ParamValue(0,360)]
        double Control_textBoxAngleWriteValue;

        //Config區域, 參數表相關
        double slavePeriod;

        //Diagnosis區域, 畫圖相關
        private int m_nTimeCount = 0;
        DateTime basicTime = DateTime.Now;
        TimeSpan timeInterval;
        private System.Windows.Forms.ComboBox[] comboBoxes;
        private PictureBox[] pictureBoxes;
        private Label[] Diagnosis_labels;
        private Label[] Diagnosis_labelsValue;

        //Main區域
        private Label[] Main_labels; //Main_init() 會初始化Main區域的物件, 包括Array大小
        private Label[] Main_labelsValue;
        private double[] Main_parametersValue;
        private Label[] Main_errors;
        private Label[] Main_alarms;
        private Dictionary<Label, AbstractParameters> Main_labelParamDic; //把Main_labels跟Main_parametersValue去做約束, 設定好label時, 值也同時完成

        //objectFactory
        private BaseParameters baseParams = new BaseParameters();
        private SimFOC simFOC = new SimFOC(); // 模擬FOC
        private CommonParam commonParam = new CommonParam();
        private static readonly Logger log = LogManager.GetCurrentClassLogger(); //創建NLog 物件
        private canDiagnosisLib.canParameters parameters = new canDiagnosisLib.canParameters();

        #endregion

        #region 讓原生北京愛泰CAN更好用的功能

        //設定鮑率, 自動配合到CAN官方設定的參數
        private void comboBox_BaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_BaudRate.SelectedIndex)
            {
                case 0: textBox_Time0.Text = "BF"; textBox_Time1.Text = "FF"; break;
                case 1: textBox_Time0.Text = "31"; textBox_Time1.Text = "1C"; break;
                case 2: textBox_Time0.Text = "18"; textBox_Time1.Text = "1C"; break;
                case 3: textBox_Time0.Text = "87"; textBox_Time1.Text = "FF"; break;
                case 4: textBox_Time0.Text = "09"; textBox_Time1.Text = "1C"; break;
                case 5: textBox_Time0.Text = "83"; textBox_Time1.Text = "FF"; break;
                case 6: textBox_Time0.Text = "04"; textBox_Time1.Text = "1C"; break;
                case 7: textBox_Time0.Text = "03"; textBox_Time1.Text = "1C"; break;
                case 8: textBox_Time0.Text = "81"; textBox_Time1.Text = "FA"; break;
                case 9: textBox_Time0.Text = "01"; textBox_Time1.Text = "1C"; break;
                case 10: textBox_Time0.Text = "80"; textBox_Time1.Text = "FA"; break;
                case 11: textBox_Time0.Text = "00"; textBox_Time1.Text = "1C"; break;
                case 12: textBox_Time0.Text = "80"; textBox_Time1.Text = "B6"; break;
                case 13: textBox_Time0.Text = "00"; textBox_Time1.Text = "16"; break;
                case 14: textBox_Time0.Text = "00"; textBox_Time1.Text = "14"; break;
            }
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 表單進入時的基礎環境設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            formlConfig(); // 初始化Config
            Main_init();
            Diagnosis_initChart();
            Setting_init();
            SettingFOC_init();
            textBox_TPSControl.Enabled = false;
            textBox_PhaseCurControl.Enabled = false;
            textBox_DutyControl.Enabled = false;
            textBox_AngleWriteControl.Enabled = false;

            #region Can的設定參數
            //其餘參數, 需要再來看功能
            comboBox_DevIndex.SelectedIndex = 0;
            comboBox_CANIndex.SelectedIndex = 0;
            textBox_AccCode.Text = "00000000";
            textBox_AccMask.Text = "FFFFFFFF";
            comboBox_DevIndex.Enabled = false; //設定不可更動
            comboBox_CANIndex.Enabled = false;//設定不可更動
            textBox_AccCode.Enabled = false;//設定不可更動
            textBox_AccMask.Enabled = false;//設定不可更動
            //001c 500K 
            //011c 250K
            textBox_Time0.Text = "00";
            textBox_Time1.Text = "1C";
            textBox_Time0.Enabled = false;//設定不可更動
            textBox_Time1.Enabled = false;//設定不可更動
            comboBox_BaudRate.SelectedIndex = 11;

            //濾波方式
            comboBox_Filter.SelectedIndex = 1;
            comboBox_Filter.Enabled = false;//設定不可更動
            //模式
            comboBox_Mode.SelectedIndex = 0;
            //發送類型
            comboBox_SendType.SelectedIndex = 0;//0 正常發送, //2 自發自收
            comboBox_FrameFormat.SelectedIndex = 0;
            comboBox_FrameType.SelectedIndex = 0;
            comboBox_Mode.Enabled = false;//設定不可更動
            comboBox_SendType.Enabled = false;//設定不可更動
            comboBox_FrameFormat.Enabled = false;//設定不可更動
            comboBox_FrameType.Enabled = false;//設定不可更動
            //幀ID:0x
            textBox_ID.Text = "102";
            //數據
            textBox_Data.Text = "00 07 02 03 04 05 06 07 ";
            //timer的重複週期,每幾毫秒觸發一次接收訊息的事件
            timer_rec.Interval = 60;

            //
            Int32 curindex = 0;
            comboBox_devtype.Items.Clear();


            /*
             * 這邊是原始code的寫法，可以參考看看
             * curindex = comboBox_devtype.Items.Add("VCI_PCI5121");
             * m_arrdevtype[curindex] = VCI_PCI5121;
             * comboBox_devtype.Items[0] = "VCI_PCI5121";
             * m_arrdevtype[0]=  VCI_PCI5121 ;
             * 
             * 下面是選擇can連接的種類
             */

            curindex = comboBox_devtype.Items.Add("VCI_USBCAN1(I+)");
            m_arrdevtype[curindex] = VCI_USBCAN1;
            curindex = comboBox_devtype.Items.Add("VCI_USBCAN2(II+)");
            m_arrdevtype[curindex] = VCI_USBCAN2;
            curindex = comboBox_devtype.Items.Add("VCI_USBCAN2A");
            m_arrdevtype[curindex] = VCI_USBCAN2A;
            curindex = comboBox_devtype.Items.Add("VCI_PCI9810");
            m_arrdevtype[curindex] = VCI_PCI9810;
            curindex = comboBox_devtype.Items.Add("VCI_PCI9820");
            m_arrdevtype[curindex] = VCI_PCI9820;
            curindex = comboBox_devtype.Items.Add("VCI_PCI9840");
            m_arrdevtype[curindex] = VCI_PCI9840;
            curindex = comboBox_devtype.Items.Add("VCI_PCIE9221");
            m_arrdevtype[curindex] = VCI_PCIE9221;
            curindex = comboBox_devtype.Items.Add("VCI_PCIE9211");
            m_arrdevtype[curindex] = VCI_PCIE9211;

            comboBox_devtype.SelectedIndex = 0;
            comboBox_devtype.MaxDropDownItems = comboBox_devtype.Items.Count;
            comboBox_devtype.Enabled = false;//設定不可更動

            #endregion

            #region 顯示作者
            //string message = "程式名：BootLoader系統上位機軟體\n" +
            //            "作者：游聲迪 treeyou@supreme.com.tw\n" +
            //            "©至上電子股份有限公司 2024\nAll Rights Reserved.";
            //string caption = "版權宣告";
            //MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            #endregion

        }

        #region Can收跟發與清除區域
        /// <summary>
        /// 讀取數據, 透過timer功能,定時去讀取資料 ex: timer_rec.Interval = 60; 這邊是60ms 讀取週期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void timer_rec_Tick(object sender, EventArgs e)
        {
            //第一個res是確認, 從buffer接收資料但還沒讀取到Host的總數。
            UInt32 res = new UInt32();
            res = VCI_GetReceiveNum(m_devtype, m_devind, m_canind);
            if (res == 0)
                return;
            //res = VCI_Receive(m_devtype, m_devind, m_canind, ref m_recobj[0],50, 100);


            //UInt32 con_maxlen = 50; //從buffer一次讀取數據的最大數量

            IntPtr pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VCI_CAN_OBJ)) * (Int32)commonParam.con_maxlen);//AllocHGlobal -> 分配指定大小的全局記憶體


            //這邊第二個res是確認, 現在已經讀進Host這邊的數據幀有多少。
            //猜測是這個method裡面已經有寫從m_devtype去取得幀數據,所以才能夠讀進Host,然後透過IntPtr去把讀到的數據換成VCI_CAN_OBJ,接著直接使用讀進的數據。
            //timer_rec.Interval 原本是直接給定值100,50之類的,不清楚用處, 這邊目前解讀是每隔多少ms就去讀一次Buffer的資料。
            res = VCI_Receive(m_devtype, m_devind, m_canind, pt, commonParam.con_maxlen, timer_rec.Interval);

            ////////////////////////////////////////////////////////
            String str = "";
            for (UInt32 i = 0; i < res; i++)
            {
                VCI_CAN_OBJ obj = (VCI_CAN_OBJ)Marshal.PtrToStructure((IntPtr)((UInt32)pt + i * Marshal.SizeOf(typeof(VCI_CAN_OBJ))), typeof(VCI_CAN_OBJ));
                serial_ReceiveNum++;
                str = serial_ReceiveNum + ". 接收到數據: ";
                str += "  帧ID:0x" + System.Convert.ToString((Int32)obj.ID, 16);//16表示 16進制
                str += "  帧格式:";
                if (obj.RemoteFlag == 0)
                    str += "数据帧 ";
                else
                    str += "远程帧 ";
                if (obj.ExternFlag == 0)
                    str += "标准帧 ";
                else
                    str += "扩展帧 ";

                frameID = System.Convert.ToString((Int32)obj.ID, 16); //得到目前的幀ID


                if (obj.RemoteFlag == 0)
                {
                    str += "数据: ";
                    byte len = (byte)(obj.DataLen % 9);
                    byte j = 0;
                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[0], 16);
                    }
                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[1], 16);
                    }
                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[2], 16);
                    }
                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[3], 16);
                    }
                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[4], 16);
                    }
                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[5], 16);
                    }
                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[6], 16);
                    }
                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[7], 16);
                    }
                    for (int ii = 0; ii < len; ii++)
                    {
                        parameters.testAdcBytes[ii] = obj.Data[ii];
                    }
                }

                Diagnosis_ADC();

                listBox_Info.Items.Add(str);
                listBox_Info.SelectedIndex = listBox_Info.Items.Count - 1;//選中最後一個項目,讓使用者可以看到最新的訊息
            }
            Marshal.FreeHGlobal(pt); //->釋放之前分配的全局記憶體
        }

        #region CAN 連接 關閉 開始 停止相關按鈕
        //CAN 關閉按鈕
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_bOpen == 1)
            {
                button_StopCAN_Click(sender, e);//防呆用, 避免直接關閉時沒有按停止CAN, 北京愛泰這邊沒有按停止CAN, 硬體層的CAN盒子就仍會繼續, 就算關閉GUI軟體也一樣
                VCI_CloseDevice(m_devtype, m_devind);
            }
        }
        //CAN 連接按鈕
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            // m_bOpen=1 代表連接中
            if (m_bOpen == 1)
            {
                button_StopCAN_Click(sender, e);//防呆用, 避免直接關閉時沒有按停止CAN, 北京愛泰這邊沒有按停止CAN, 硬體層的CAN盒子就仍會繼續, 就算關閉GUI軟體也一樣
                VCI_CloseDevice(m_devtype, m_devind);
                // m_bOpen=0 代表斷開中
                m_bOpen = 0;
            }
            else
            {
                m_devtype = m_arrdevtype[comboBox_devtype.SelectedIndex];

                m_devind = (UInt32)comboBox_DevIndex.SelectedIndex;
                m_canind = (UInt32)comboBox_CANIndex.SelectedIndex;
                if (VCI_OpenDevice(m_devtype, m_devind, 0) == 0)
                {
                    MessageBox.Show("打开设备失败,请检查设备类型和设备索引号是否正确", "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                m_bOpen = 1;
                //初始化CAN數據
                VCI_INIT_CONFIG config = new VCI_INIT_CONFIG();
                config.AccCode = System.Convert.ToUInt32("0x" + textBox_AccCode.Text, 16);
                config.AccMask = System.Convert.ToUInt32("0x" + textBox_AccMask.Text, 16);
                config.Timing0 = System.Convert.ToByte("0x" + textBox_Time0.Text, 16);
                config.Timing1 = System.Convert.ToByte("0x" + textBox_Time1.Text, 16);
                config.Filter = (Byte)comboBox_Filter.SelectedIndex;
                config.Mode = (Byte)comboBox_Mode.SelectedIndex;

                VCI_ClearBuffer(m_devtype, m_devind, 0); //初始化就刪除, 自己增加的
                //InitConfig 使用到 InitCAN
                if (VCI_InitCAN(m_devtype, m_devind, m_canind, ref config) == 0)
                {
                    MessageBox.Show("初始化设备失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
            }
            buttonConnect.Text = m_bOpen == 1 ? "斷開" : "連接";
            timer_rec.Enabled = m_bOpen == 1 ? true : false;
        }
        //開始按鈕
        private void button_StartCAN_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;
            uint ret = VCI_StartCAN(m_devtype, m_devind, m_canind);
            canStart = ret;  //把開始訊息放入 全域變數canStart -> 為了判斷現在是 開始CAN還是停止CAN
            canStop = 0;
            label_CANConnectValue.Text = "connect";
            if (ret != 1)
            {
                canStop = 1;
                MessageBox.Show("启动失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            button_StartCAN.Enabled = ret != 1;
            button_StartCAN.Text = ret == 1 ? "CAN已開始" : "開始CAN";
            button_StopCAN.Enabled = ret == 1;
            button_StopCAN.Text = ret != 1 ? "CAN已結束" : "停止CAN";
        }
        //停止按鈕
        private void button_StopCAN_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;
            uint ret = VCI_ResetCAN(m_devtype, m_devind, m_canind);
            canStop = ret; //把停止訊息放入 全域變數canStop -> 為了判斷現在是 開始CAN還是停止CAN
            canStart = 1;
            label_CANConnectValue.Text = "disConnect";
            if (ret == 1)
            {
                canStart = 0;
                //MessageBox.Show("已經成功停止CAN", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            button_StartCAN.Enabled = ret == 1;
            button_StartCAN.Text = ret != 1 ? "CAN已開始" : "開始CAN";
            button_StopCAN.Enabled = ret != 1;
            button_StopCAN.Text = ret == 1 ? "CAN已結束" : "停止CAN";
        }
        #endregion

        /// <summary>
        /// 透過CAN 傳送資料的按鈕, 一次只能傳送8Bytes, 配合VCI_CAN_OBJ的Struct結構
        /// </summary>
        /// <param name="sender">點擊按鈕</param>
        /// <param name="e"></param>
        unsafe private void button_Send_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;
            VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
            //sendobj.Init();
            sendobj.SendType = (byte)comboBox_SendType.SelectedIndex;
            sendobj.RemoteFlag = (byte)comboBox_FrameFormat.SelectedIndex;
            sendobj.ExternFlag = (byte)comboBox_FrameType.SelectedIndex;
            sendobj.ID = System.Convert.ToUInt32("0x" + textBox_ID.Text, 16);
            int len = (textBox_Data.Text.Length + 1) / 3;
            sendobj.DataLen = System.Convert.ToByte(len);
            String strdata = textBox_Data.Text;
            int i = -1;
            if (i++ < len - 1)
                sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[1] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[2] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[3] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[4] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[5] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[6] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[7] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

            if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
            {
                MessageBox.Show("发送失败, 請確認實體裝置是否連接或是插電 !!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 重置訊息列的顯示資訊, 沒有重置變數
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ClearAll_Click(object sender, EventArgs e)
        {
            listBox_Info.Items.Clear();
            serial_ReceiveNum = 0;
        }

        #endregion

        #region simFOC交互區, 區域交互區 
        #region SimFOC與Setting交互區
        /// <summary>
        /// 有gainSet的部分使用這個多載, 這邊是Setting區域的值, 傳給韌體讓他對Main區域產生改變, 先暫時棄用
        /// </summary>
        /// <param name="i"></param>
        /// <param name="adcTrans"></param>
        /// <param name="label"></param>
        /// <param name="baseParameters"></param>
        /// <param name="gainSet"></param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        [Obsolete("這方法先棄用, 同樣功能採用 Main_ParametersSetGain(double Main_parameValue, int i, double adcTrans, string gainSet) ", false)]
        private void setMain_ParametersValue(int i, int adcTrans, Label label, AbstractParameters baseParameters, string gainSet)
        {
            //這邊進來時先檢查gainSet是否為0或是Null或是空字符
            double gain;
            double gainsetMax = 10.0; //縮放最大比例10倍
            if (!string.IsNullOrWhiteSpace(gainSet) && Convert.ToDouble(gainSet) < gainsetMax)
            {
                gain = Convert.ToDouble(gainSet);
            }
            else
            {
                gain = 1.0;
            }

            if (Main_labelParamDic.TryGetValue(label, out var correctParam))
            {
                if (correctParam == baseParameters)
                {
                    Main_parametersValue[i] = baseParameters.getAdcValue() * gain;
                    Main_labelsValue[i].Text = (Main_parametersValue[i] * adcTrans / baseParams.ADC_register).ToString("F1");
                    chart1.Series[i].Points.AddXY(slavePeriod * (m_nTimeCount - 1), Main_parametersValue[i] * 100 / baseParams.ADC_register);
                }
                else
                {
                    throw new InvalidOperationException("Parameter does not match the expected label.");
                }
            }
            else
            {
                throw new KeyNotFoundException("Label is not bound to any parameter.");
            }
        }
        /// <summary>
        /// 有gainSet的部分使用這個多載, 這邊是Setting區域的值, 傳給韌體讓他對Main區域產生改變
        /// </summary>
        /// <param name="Main_parameValue"></param>
        /// <param name="i"></param>
        /// <param name="adcTrans"></param>
        /// <param name="gainSet"></param>
        /// <returns></returns>
        [Obsolete("這方法已經棄用, 原本打算使用setMain_ParametersValu的多載, 現在拼裝到simFOC裡面去做物件管理", false)]
        private double Main_ParametersSetGain(double Main_parameValue, int i, double adcTrans, string gainSet)
        {
            //這邊進來時先檢查gainSet是否為0或是Null或是空字符
            double gain;
            double gainsetMax = 10.01; //縮放最大比例10倍
            if (!string.IsNullOrWhiteSpace(gainSet) && Convert.ToDouble(gainSet) < gainsetMax)
            {
                gain = Convert.ToDouble(gainSet);
            }
            else
            {
                gain = 1.0;
            }
            Main_parametersValue[i] = Main_parameValue * gain;
            Main_labelsValue[i].Text = (Main_parametersValue[i] * adcTrans / baseParams.ADC_register).ToString("F1");
            //chart1.Series[i].Points.AddXY(slavePeriod * (m_nTimeCount - 1), Main_parametersValue[i] * 100 / 4096);
            return Main_parametersValue[i];
        }
        private void SettingFOC_init()
        {
            //simFOC.setSettingCheckBox(Setting_Func, ref simFOC.funcCheckBoxes);
            //simFOC.setSettingCheckBox(Setting_Prot, ref simFOC.protCheckBoxes);

            //simFOC_funcCheckBoxes = simFOC.getFuncCheckBoxes(); 
            //simFOC_protCheckBoxes = simFOC.getProtCheckBoxes();

            simFOC.setSettingCheckBox(Setting_Func, ref simFOC.getFuncCheckBoxes());
            simFOC.setSettingCheckBox(Setting_Prot, ref simFOC.getProtCheckBoxes());
            simFOC.setSettingCheckBox(Setting_Alarm, ref simFOC.getAlarmCheckBoxes());
        }
        private void MainParamSetGain()
        {
            simFOC.textBox_TPSSetText = textBox_TPSSetValue.Text;
            simFOC.textBox_BusVoltSetText = textBox_BusVoltSetValue.Text;
            simFOC.textBox_PhaseCurSetText = textBox_PhaseCurSetValue.Text;
            simFOC.textBox_DriverTempSetText = textBox_DriverTempSetValue.Text;
            simFOC.textBox_MotorTempSetText = textBox_MotorTempSetValue.Text;
            //Main_parametersValue[0] = Main_ParametersSetGain(Main_parametersValue[0], 0, baseParams.ADC_busVolt, textBox_BusVoltSetText.Text);
            //Main_parametersValue[1] = Main_ParametersSetGain(Main_parametersValue[1], 1, baseParams.ADC_phaseCur, textBox_PhaseCurSetText.Text);
            //Main_parametersValue[3] = Main_ParametersSetGain(Main_parametersValue[3], 3, baseParams.ADC_driverTemp, textBox_DriverTempSetText.Text);
            //Main_parametersValue[4] = Main_ParametersSetGain(Main_parametersValue[4], 4, baseParams.ADC_motorTemp, textBox_MotorTempSetText.Text);
        }
        private void SettingFOC_func() 
        {
            Setting_updateCheckBox();
            simFOC.updateFuncStates();
            simFOC.updateProtStates();
            simFOC.updateAlarmStates();
            simFOC.detectSettingAlarm();//先後順序會影響, 先Alarm再Prot
            simFOC.detectProtection();
        }
        #endregion

        #region SimFOC與Control交互區, 模擬回傳給韌體MCU 進行FOC處理 
        [Obsolete("舊的方法交互功能, 直接在UI改值當作模擬, 現在改成simFOC物件去做處理",false)]
        private double Main_ParametersControlRatio(double Main_parameValue, int i, int adcTrans, double controlRatio)
        {
            Main_parametersValue[i] = Main_parameValue * controlRatio;
            Main_labelsValue[i].Text = (Main_parametersValue[i] * adcTrans / baseParams.ADC_register).ToString("F1");
            //chart1.Series[i].Points.AddXY(slavePeriod * (m_nTimeCount - 1), Main_parametersValue[i] * 100 / 4096);
            return Main_parametersValue[i];
        }
        /// <summary>
        /// 選擇參數的控制, 融入到保護控制裡面, 需要先考量保護才能去做動作, 所以合併
        /// </summary>
        [Obsolete("因為後續開發了保護監測功能, 所以把控制移到保護控制裡面detectProtection這方法內",false)]
        private void MainParamControl()
        {
            //Main_parametersValue[1] = Main_ParametersControlRatio(Main_parametersValue[1], 1, ADC_phaseCur, simFOC.getFOCResult22222222());
            //simFOC.chooseTpsMode();
        }
        #endregion

        #region simCAN, 主要是模擬CAN所以全部需要透過CAN傳送資訊的都在這, Main參數區,與Diagnosis交互區
        /// <summary>
        /// 模擬CAN, 所以這邊有timer在更新值, 而圖形跟CSV也需要一直更新所以放到一起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simCAN(object sender, EventArgs e)
        {
            Main_flagStates();//檢查Flag區域的狀態
            Main_receiveParam();
            //由rawValue去繼續後面的韌體值交互
            //MainParamControl();//放棄這方法, 改到保護監測裡面SettingFOC_func這方法裡面的detectProtection
            MainParamSetGain();
            SettingFOC_func();

            Diagnosis_refreshChart();

            // 指定輸出文件路徑
            string filePath = "output.csv";
            writeCSV(filePath);
        }
        private void writeCSV(string filePath)
        {
            // 使用 StreamWriter 寫入 CSV 文件，以追加模式
            using (var writer = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                string currentTime = "'" + DateTime.Now.ToString("HH:mm:ss.ffff") + "'";
                double busVolt = simFOC.busVolt.getPhysicalValue(baseParams.ADC_busVolt);
                double phaseCur = simFOC.phaseCur.getPhysicalValue(baseParams.ADC_phaseCur);
                double speed = simFOC.speed.getPhysicalValue(baseParams.ADC_speed);
                double driverTemp = simFOC.driverTemp.getPhysicalValue(baseParams.ADC_driverTemp);
                double motorTemp = simFOC.motorTemp.getPhysicalValue(baseParams.ADC_motorTemp);
                double motorAngle = simFOC.motorAngle.getPhysicalValue(baseParams.ADC_motorAngle);
                double dcCur = simFOC.dcCur.getPhysicalValue(baseParams.ADC_dcCur);
                double tps = simFOC.tps.getPhysicalValue(baseParams.ADC_tps);
                // 寫入數據
                //writer.WriteLine($"{m_nTimeCount},{busVolt:F1},{phaseCur:F1},{speed:F1},{driverTemp:F1},{motorTemp:F1},{motorAngle:F1},{dcCur:F1},{tps:F1}");
                writer.WriteLine($"{currentTime},{busVolt:F1},{phaseCur:F1},{speed:F1},{driverTemp:F1},{motorTemp:F1},{motorAngle:F1},{dcCur:F1},{tps:F1}");
            }
        }
        #endregion


        #endregion

        #region Control區域
        #region 這邊是按鈕產生分頁的地方
        [Obsolete("這方法暫時棄用, 不用按鈕產生Control分頁的部分, 現在直接改到tabPage裡面了, 除非後續需求要變回來", false)]
        private void button_Control_Click(object sender, EventArgs e)
        {
            FormControl formControl = new FormControl();
            formControl.ShowDialog();
            int qwer = formControl.ShowTest();
            MessageBox.Show("表單拿到" + qwer);
        }
        #endregion

        /// <summary>
        /// 當checkBox打勾後, 把Text輸入的值直接轉成double, 不是ADC值
        /// </summary>
        /// <param name="checkbox"></param>
        /// <param name="str">textBox上面的值</param>
        /// <param name="value">直接轉成double</param>
        private void convertControlParam(bool checkbox, string str, out double value)
        {
            if (checkbox)
            {
                if (!string.IsNullOrWhiteSpace(str))
                {
                    value = Convert.ToDouble(str);
                }
                else
                {
                    value = 0;
                }
            }
            else //沒被勾選的話, 值無法使用, 把他規零
            {
                value = 0;
            }
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            //把control設定的參數值丟到double[]裡面, Array Contorl_param
            //convertControlParam(checkBox_TPSControl.Checked, textBox_TPSControl.Text, out Control_paramValue[0]);
            //convertControlParam(checkBox_PhaseCurControl.Checked, textBox_PhaseCurControl.Text, out Control_paramValue[1]);
            //convertControlParam(checkBox_DutyControl.Checked, textBox_DutyControl.Text, out Control_paramValue[2]);
            //convertControlParam(checkBox_AngleWriteControl.Checked, textBox_AngleWriteControl.Text, out Control_paramValue[3]);
            convertControlParam(checkBox_TPSControl.Checked, textBox_TPSControl.Text, out Control_textBoxTPSValue);
            convertControlParam(checkBox_PhaseCurControl.Checked, textBox_PhaseCurControl.Text, out Control_textBoxPhaseCurValue);
            convertControlParam(checkBox_DutyControl.Checked, textBox_DutyControl.Text, out Control_textBoxDutyValue);
            convertControlParam(checkBox_AngleWriteControl.Checked, textBox_AngleWriteControl.Text, out Control_textBoxAngleWriteValue);
            //InvokeAttrMethod.findAttr(this); //透過特性去處理極值
            this.findAttr(); //透過特性去處理極值, 做成擴展方法
            Control_paramValue[0] = Control_textBoxTPSValue;
            Control_paramValue[1] = Control_textBoxPhaseCurValue;
            Control_paramValue[2] = Control_textBoxDutyValue;
            Control_paramValue[3] = Control_textBoxAngleWriteValue;
            simFOC.setControlParam(Control_paramValue); //把值丟給FOC, 裡面的變數直接參考指向這邊的Control_param
        }
        private void button_EMS_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Control_paramValue.Length; i++)
            {
                Control_paramValue[i] = -1;
            }
            //simFOC.setControlParam(Control_paramValue); //把值丟給FOC, 裡面的變數直接參考指向這邊的Control_param, 其實只要一次, 但是怕還沒按Confirm就需要強制停止
        }
        private void button_Reset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Control_paramValue.Length; i++)
            {
                Control_paramValue[i] = 0;//全部變成0 相當於checkBox都沒打勾的時候按下confirm
            }
            simFOC.setControlParam(Control_paramValue); //為了讓模式從Control改成random
        }
        private void checkTPSCheckBox()
        {
            if (!checkBox_AngleWriteControl.Checked && !checkBox_DutyControl.Checked && !checkBox_PhaseCurControl.Checked)
            {
                checkBox_TPSControl.Enabled = true;
            }
        }
        private void checkBox_TPSControl_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_TPSControl.Checked)
            {
                textBox_TPSControl.Enabled = true;
                checkBox_PhaseCurControl.Enabled = false;
                checkBox_DutyControl.Enabled = false;
                checkBox_AngleWriteControl.Enabled = false;
                textBox_PhaseCurControl.Enabled = false;
                textBox_DutyControl.Enabled = false;
                textBox_AngleWriteControl.Enabled = false;
            }
            else
            {
                textBox_TPSControl.Enabled = false;
                checkBox_PhaseCurControl.Enabled = true;
                checkBox_DutyControl.Enabled = true;
                checkBox_AngleWriteControl.Enabled = true;
            }
        }
        private void checkBox_PhaseCurControl_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_PhaseCurControl.Checked)
            {
                textBox_PhaseCurControl.Enabled = true;
                checkBox_TPSControl.Enabled = false;
                textBox_TPSControl.Enabled = false;
            }
            else
            {
                textBox_PhaseCurControl.Enabled = false;
                checkTPSCheckBox();
            }
        }

        private void checkBox_DutyControl_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DutyControl.Checked)
            {
                textBox_DutyControl.Enabled = true;
                checkBox_TPSControl.Enabled = false;
                textBox_TPSControl.Enabled = false;
            }
            else
            {
                textBox_DutyControl.Enabled = false;
                checkTPSCheckBox();
            }
        }

        private void checkBox_AngleWriteControl_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AngleWriteControl.Checked)
            {
                textBox_AngleWriteControl.Enabled = true;
                checkBox_TPSControl.Enabled = false;
                textBox_TPSControl.Enabled = false;
            }
            else
            {
                textBox_AngleWriteControl.Enabled = false;
                checkTPSCheckBox();
            }
        }

        #endregion

        #region Main區域
        /// <summary>
        /// 模擬CAN, 利用自製Timer去收數據, 也是刷新圖表的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        /// 初始化控件, 把散裝的control用Array裝在一起
        /// </summary>
        private void Main_init()
        {
            #region 綁定Main_labels跟BaseParameters
            //綁定Main_labels跟BaseParameters
            Main_labelParamDic = new Dictionary<Label, AbstractParameters>
            {
                { label_BusVolt, simFOC.busVolt },
                { label_DcCur, simFOC.dcCur },
                { label_PhaseCur, simFOC.phaseCur },
                { label_Speed, simFOC.speed },
                { label_DriverTemp, simFOC.driverTemp },
                { label_MotorTemp, simFOC.motorTemp },
                { label_MotorAngle, simFOC.motorAngle },
                { label_TPS, simFOC.tps}
            };

            int paramNums = 8;
            int alarmNums = 8;
            int errorNums = 8;
            Main_labels = new Label[paramNums];
            Main_labels[0] = label_BusVolt;
            Main_labels[1] = label_PhaseCur;
            Main_labels[2] = label_Speed;
            Main_labels[3] = label_DriverTemp;
            Main_labels[4] = label_MotorTemp;
            Main_labels[5] = label_MotorAngle;
            Main_labels[6] = label_DcCur;
            Main_labels[7] = label_TPS;

            Main_labelsValue = new Label[paramNums];
            Main_labelsValue[0] = label_BusVoltValue;
            Main_labelsValue[1] = label_PhaseCurValue;
            Main_labelsValue[2] = label_SpeedValue;
            Main_labelsValue[3] = label_DriverTempValue;
            Main_labelsValue[4] = label_MotorTempValue;
            Main_labelsValue[5] = label_MotorAngleValue;
            Main_labelsValue[6] = label_DcCurValue;
            Main_labelsValue[7] = label_TPSValue;

            Main_alarms = new Label[alarmNums];
            Main_alarms[0] = label_LowVoltAlarm;
            Main_alarms[1] = label_HighCurAlarm;
            Main_alarms[2] = label_LowTempMotorAlarm;
            Main_alarms[3] = label_LowTempDriverAlarm;
            Main_alarms[4] = label_HighTempMotorAlarm;
            Main_alarms[5] = label_HighTempDriverAlarm;
            Main_alarms[6] = label_DeratingAlarm;
            Main_alarms[7] = label_HighSpeedAlarm;

            Main_errors = new Label[errorNums];
            Main_errors[0] = label_PhaseOCPErr;
            Main_errors[1] = label_OVPErr;
            Main_errors[2] = label_UVPErr;
            Main_errors[3] = label_DcOCPErr;
            Main_errors[4] = label_OTPMotorErr;
            Main_errors[5] = label_OTPDriverErr;
            Main_errors[6] = label_TPSHighErr;
            Main_errors[7] = label_HighSpeedErr;

            //parameters數值相關
            Main_parametersValue = new double[paramNums];
            #endregion

            #region Flag區域 顯示文字跟判斷
            label_CANConnectValue.Text = "✖";
            label_CANConnectValue.ForeColor = Color.Red;
            label_CANStatusValue.Text = "✖";
            label_CANStatusValue.ForeColor = Color.Red;

            label_SideStandValue.Text = "✖";
            label_SideStandValue.ForeColor = Color.Red;
            label_ProtectActivationValue.Text = "✖";
            label_ProtectActivationValue.ForeColor = Color.Red;
            label_RestartValue.Text = "✖";
            label_RestartValue.ForeColor = Color.Red;
            #endregion

        }
        /// <summary>
        /// 用在detectError跟detectAlarm判斷條件
        /// </summary>
        /// <param name="param">要判斷的參數值 busVolt Current Temperature</param>
        /// <param name="bl">true代表大於等於, false代表小於等於</param>
        /// <param name="condition">判斷的條件值</param>
        /// <param name="label">要顯示的Label</param>
        /// <param name="str">顯示什麼文字</param>
        private void detectCondition(double param, bool bl, double condition, Label label, string str)
        {
            if (bl == true)
            {
                if (param >= condition)
                {
                    label.Text = str;
                    label.ForeColor = Color.Red;
                }
                else if (label.ForeColor == Color.Red)
                {
                    label.Text = str;
                    label.ForeColor = Color.Blue;
                }
            }
            else
            {
                if (param <= condition && param > 0)
                {
                    label.Text = str;
                    label.ForeColor = Color.Red;
                }
                else if (label.ForeColor == Color.Red)
                {
                    label.Text = str;
                    label.ForeColor = Color.Blue;
                }
            }
        }
        private void Main_detectAlarm()
        {
            double _busVolt, _current, _speed, _tempD, _tempM;

            _busVolt = Convert.ToDouble(label_BusVoltValue.Text);
            _current = Convert.ToDouble(label_PhaseCurValue.Text);
            _speed = Convert.ToDouble(label_SpeedValue.Text);
            _tempM = Convert.ToDouble(label_MotorTempValue.Text);
            _tempD = Convert.ToDouble(label_DriverTempValue.Text);

            detectCondition(_busVolt, false, simFOC.lowVoltAlarmValue,        label_LowVoltAlarm, "L.Volt.");
            detectCondition(_tempM,   false, simFOC.lowTempMotorAlarmValue,   label_LowTempMotorAlarm, "L.Temp.M.");
            detectCondition(_tempD,   false, simFOC.lowTempDriverAlarmValue,  label_LowTempDriverAlarm, "L.Temp.D.");
            detectCondition(_current,  true, simFOC.highCurAlarmValue,        label_HighCurAlarm, "H.Cur.");
            detectCondition(_speed,    true, simFOC.highSpeedAlarmValue,      label_HighSpeedAlarm, "H.Speed");
            detectCondition(_tempM,    true, simFOC.highTempMotorAlarmValue,  label_HighTempMotorAlarm, "H.Temp.M.");
            detectCondition(_tempD,    true, simFOC.highTempDriverAlarmValue, label_HighTempDriverAlarm, "H.Temp.D.");
            detectCondition(_current,  true, simFOC.highCurAlarmValue,        label_DeratingAlarm, "Derating");
            detectCondition(_speed,    true, simFOC.highSpeedAlarmValue,      label_DeratingAlarm, "Derating");
            detectCondition(_tempM,    true, simFOC.highTempMotorAlarmValue,  label_DeratingAlarm, "Derating");
            detectCondition(_tempD,    true, simFOC.highTempDriverAlarmValue, label_DeratingAlarm, "Derating");

        }
        private void Main_detectError()
        {
            double _busVolt, _current, _tempM, _tempD, _dcCur, _TPSHigh, _speed;

            _busVolt = Convert.ToDouble(label_BusVoltValue.Text);
            _current = Convert.ToDouble(label_PhaseCurValue.Text);
            _dcCur = Convert.ToDouble(label_DcCurValue.Text);
            _tempM = Convert.ToDouble(label_MotorTempValue.Text);
            _tempD = Convert.ToDouble(label_DriverTempValue.Text);
            _TPSHigh = Convert.ToDouble(label_TPSValue.Text);
            _speed = Convert.ToDouble(label_SpeedValue.Text);

            detectCondition(_current, true,  simFOC.phaseOcpErrValue, label_PhaseOCPErr, "Phase O.C.P.");
            detectCondition(_dcCur,   true,  simFOC.dcOcpErrValue, label_DcOCPErr, "Dc O.C.P.");
            detectCondition(_busVolt, true,  simFOC.ovpErrValue, label_OVPErr, "O.V.P.");
            detectCondition(_busVolt, false, simFOC.uvpErrValue, label_UVPErr, "U.V.P.");
            detectCondition(_tempM,   true,  simFOC.otpMotorErrValue, label_OTPMotorErr, "O.T.P.M.");
            detectCondition(_tempD,   true,  simFOC.otpDriverErrValue, label_OTPDriverErr, "O.T.P.D.");
            detectCondition(_TPSHigh, true,  simFOC.tpsHighErrValue, label_TPSHighErr, "TPS H.");
            detectCondition(_speed,   true,  simFOC.highSpeedErrValue, label_HighSpeedErr, "O.Speed");

            //還有TPS HihgSpeed還沒寫
        }

        /// <summary>
        /// 更新ADC值, 畫在Diagnosis圖形與Main_Label上面, 利用字典Main_labelParamDic
        /// 把label跟BaseParameters關聯在一起, 然後再設定Main_ParametersValue跟後續label與圖的更新
        /// </summary>
        /// <param name="i"> Main_ParametersValue index </param>
        /// <param name="adcTrans">想要換成多少值舉例 : 48V 就寫48 , 12A就寫12</param>
        /// <param name="label">對應哪一個Label控件</param>
        /// <param name="labelName">要產生物件的label名稱, 可參考SimFOC跟Factory裡面的一模一樣</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        private double setMain_ParametersValue(int i, double adcTrans, Label label, string labelName)
        {
            if (Main_labelParamDic.TryGetValue(label, out var correctParam))
            {
                AbstractParameters absParameters = simFOC.getAbsParameters(labelName);
                if (correctParam == absParameters)
                {
                    Main_parametersValue[i] = simFOC.getADCValue(labelName);
                    Main_labelsValue[i].Text = (Main_parametersValue[i] * adcTrans / baseParams.ADC_register).ToString("F1");
                    //chart1.Series[i].Points.AddXY(slavePeriod * (m_nTimeCount - 1), Main_parametersValue[i] * 100 / 4096);
                    return Main_parametersValue[i];
                }
                else
                {
                    throw new InvalidOperationException("Parameter does not match the expected label.");
                }
            }
            else
            {
                throw new KeyNotFoundException("Label is not bound to any parameter.");
            }
        }
        private int ProtTimes = 0;
        private void Main_flagStates() 
        {
            if (checkBox_SideStandFunc.Checked)
            {
                label_SideStandValue.Text = "✔";
                label_SideStandValue.ForeColor = Color.Green;
            }
            else 
            {
                label_SideStandValue.Text = "✖";
                label_SideStandValue.ForeColor = Color.Red;
            }
            //用來判斷flag區域的條件狀態
            if (simFOC.getIsProtActive())
            {
                ProtTimes = 1;
                label_ProtectActivationValue.Text = "✔"; //這邊還沒做, 後面補
                label_ProtectActivationValue.ForeColor = Color.Green;
                label_RestartValue.Text = "⟳";
                label_RestartValue.ForeColor = Color.Red;
            }
            else if (!simFOC.getIsProtActive() && ProtTimes == 1) 
            {
                label_ProtectActivationValue.Text = "✖"; //這邊還沒做, 後面補
                label_ProtectActivationValue.ForeColor = Color.Red;
                label_RestartValue.Text = "✔";
                label_RestartValue.ForeColor = Color.Green;
            }
            else
            {
                label_ProtectActivationValue.Text = "✖"; //這邊還沒做, 後面補
                label_ProtectActivationValue.ForeColor = Color.Red;
                label_RestartValue.Text = "✖";
                label_RestartValue.ForeColor = Color.Red;
            }

        }
        private void Main_receiveParam()
        {
            Main_detectError(); //檢查Param是否有Error訊號
            Main_detectAlarm(); //檢查Param是否有Alarm訊號
            //setMain_ParametersValue(0, 65, Main_labels[0], busVolt, textBox_BusVoltSetText.Text); //有Set的跟Set區域交互
            //setMain_ParametersValue(1, 85, Main_labels[1], phaseCur, textBox_PhaseCurSetText.Text);
            //setMain_ParametersValue(2, 10000, Main_labels[2], speed);
            //setMain_ParametersValue(3, 80, Main_labels[3], driverTemp, textBox_DriverTempSetText.Text);
            //setMain_ParametersValue(4, 80, Main_labels[4], motorTemp, textBox_MotorTempSetText.Text);
            //setMain_ParametersValue(5, 360, Main_labels[5], motorAngle);
            //setMain_ParametersValue(6, 80, Main_labels[6], dcCur);
            //Main_parametersValue[0] = setMain_ParametersValue(0, baseParams.ADC_busVolt, Main_labels[0], simFOC.busVolt); //這邊就是rawValue
            //Main_parametersValue[1] = setMain_ParametersValue(1, baseParams.ADC_phaseCur, Main_labels[1], simFOC.phaseCur);
            //Main_parametersValue[2] = setMain_ParametersValue(2, baseParams.ADC_speed, Main_labels[2], simFOC.speed);
            //Main_parametersValue[3] = setMain_ParametersValue(3, baseParams.ADC_driverTemp, Main_labels[3], simFOC.driverTemp);
            //Main_parametersValue[4] = setMain_ParametersValue(4, baseParams.ADC_motorTemp, Main_labels[4], simFOC.motorTemp);
            //Main_parametersValue[5] = setMain_ParametersValue(5, baseParams.ADC_motorAngle, Main_labels[5], simFOC.motorAngle);
            //Main_parametersValue[6] = setMain_ParametersValue(6, baseParams.ADC_dcCur, Main_labels[6], simFOC.dcCur);
            //Main_parametersValue[7] = setMain_ParametersValue(7, baseParams.ADC_tps, Main_labels[7], simFOC.tps);
            Main_parametersValue[0] = setMain_ParametersValue(0, baseParams.ADC_busVolt, Main_labels[0], "label_BusVolt"); //這邊就是rawValue
            Main_parametersValue[1] = setMain_ParametersValue(1, baseParams.ADC_phaseCur, Main_labels[1], "label_PhaseCur");
            Main_parametersValue[2] = setMain_ParametersValue(2, baseParams.ADC_speed, Main_labels[2], "label_Speed");
            Main_parametersValue[3] = setMain_ParametersValue(3, baseParams.ADC_driverTemp, Main_labels[3], "label_DriverTemp");
            Main_parametersValue[4] = setMain_ParametersValue(4, baseParams.ADC_motorTemp, Main_labels[4], "label_MotorTemp");
            Main_parametersValue[5] = setMain_ParametersValue(5, baseParams.ADC_motorAngle, Main_labels[5], "label_MotorAngle");
            Main_parametersValue[6] = setMain_ParametersValue(6, baseParams.ADC_dcCur, Main_labels[6], "label_DcCur");
            Main_parametersValue[7] = setMain_ParametersValue(7, baseParams.ADC_tps, Main_labels[7], "label_TPS");
        }

        #endregion

        #region config區域

        void formlConfig()
        {
            NameValueCollection form1Settings = (NameValueCollection)ConfigurationManager.GetSection("form1Settings");
            slavePeriod = Convert.ToDouble(form1Settings["testKey"]);
        }
        private void button_ConfigConfirm_Click(object sender, EventArgs e)
        {
            // 讀取當前配置值
            var section = (NameValueCollection)ConfigurationManager.GetSection("form1Settings");

            if (section != null)
            {
                // 獲取可寫的配置對象
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var sectionToModify = (DefaultSection)config.GetSection("form1Settings");

                if (sectionToModify != null)
                {
                    // 修改配置文件中的XML內容
                    var xml = sectionToModify.SectionInformation.GetRawXml();
                    //xml = xml.Replace($"key=\"{section["testKey"]}\"", $"value=\"{textBox1.Text}\"");
                    xml = xml.Replace($"<add key=\"testKey\" value=\"{section["testKey"]}\" />",
                                      $"<add key=\"testKey\" value=\"{textBox1.Text}\" />");

                    sectionToModify.SectionInformation.SetRawXml(xml);

                    // 保存更改並刷新配置區段
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("form1Settings");

                    // 重新讀取更新後的配置值
                    section = (NameValueCollection)ConfigurationManager.GetSection("form1Settings");

                    // 顯示更新後的值
                    textBox1.Text = section["testKey"];
                    formlConfig();//更新config設定, 使用到config的部分也要更新

                    MessageBox.Show("Value updated successfully!");
                }
                else
                {
                    MessageBox.Show("Section not found!");
                }
            }
            else
            {
                MessageBox.Show("Section not found!");
            }
        }

        #region 製作密碼保護
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // 保護第5個分頁
            if (e.TabPage == tabControl1.TabPages[4])
            {
                // 顯示密碼輸入對話框
                string password = "1234"; // 設置你的密碼
                string input = PasswordForm.ShowDialog("Enter password : ", "Password Required");

                // 檢查密碼是否正確
                if (input != password)
                {
                    // 如果密碼不正確，取消切換
                    MessageBox.Show("Incorrect password!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }
        public static class PasswordForm
        {
            public static string ShowDialog(string text, string caption)
            {
                Form passwordForm = new Form()
                {
                    //Width = 300,
                    //Height = 150,
                    Text = caption
                };
                passwordForm.StartPosition = FormStartPosition.CenterParent;
                passwordForm.Size = new Size(300, 150);

                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox() { Left = 50, Top = 50, Width = 200 };
                textBox.PasswordChar = '*'; // 密碼輸入時隱藏字符
                System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button() { Text = "Ok", Left = 150, Width = 100, Top = 80, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { passwordForm.Close(); };
                passwordForm.Controls.Add(textBox);
                passwordForm.Controls.Add(confirmation);
                passwordForm.Controls.Add(textLabel);
                passwordForm.AcceptButton = confirmation;//當使用者按下Enter的時候即可觸發確認操作, 這邊預設的是confirmation這個Button;

                return passwordForm.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }
        #endregion

        #endregion

        #region Diagnosis區域
        /// <summary>
        /// 用來更新圖表上面的圖形, 
        /// </summary>
        /// <param name="i">>Main_ParametersValue index, 也可以是第幾個Series, 反正兩個要一致</param>
        private void refreshChart(int i)
        {
            chart1.Series[i].Points.AddXY(slavePeriod * (m_nTimeCount - 1), Main_parametersValue[i] * 100 / baseParams.ADC_register);
        }
        /// <summary>
        /// 更新圖表上的圖, 並且讓圖形能夠一直保持在最新的時間
        /// </summary>
        private void Diagnosis_refreshChart()
        {
            m_nTimeCount++;
            if (slavePeriod * (m_nTimeCount - 1) > slavePeriod * 10)//chtArea.AxisX.ScaleView.Size=500, 這邊的500是從這來的 //這邊的10是區域變數interval的給定值
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Position = slavePeriod * (m_nTimeCount - 1) - slavePeriod * 10; //將視窗焦點維持在最新的點那邊
            }
            //更新全部的圖表
            for (int i = 0; i < Main_parametersValue.Length; i++)
            {
                refreshChart(i);
            }
        }
        [Obsolete("配合真實CAN使用的接收ADC方法, 現在改用模擬CAN就用不到了", false)]
        private void Diagnosis_ADC()
        {
            if (m_nTimeCount == 0)
            {
                basicTime = DateTime.Now;
            }
            m_nTimeCount++;
            double tempInt = 0;
            foreach (ushort item in parameters.getADC(parameters.testAdcBytes))
            {
                Main_parametersValue[0] = item;
                Main_labelsValue[0].Text = (Main_parametersValue[0] * 48 / baseParams.ADC_register).ToString("F1");
                chart1.Series[0].Points.AddXY((slavePeriod * (m_nTimeCount - 1)) + (tempInt), Main_parametersValue[0] * 100 / baseParams.ADC_register);//圖形的XY值
                // 指定輸出文件路徑
                string filePath = "output.csv";

                // 使用 StreamWriter 寫入 CSV 文件，以追加模式
                using (var writer = new StreamWriter(filePath, true, Encoding.UTF8))
                {
                    // 寫入數據
                    DateTime nowTime = DateTime.Now;
                    timeInterval = nowTime - basicTime;
                    writer.WriteLine($"\"{timeInterval}\",{slavePeriod * (m_nTimeCount - 1) + tempInt},{Main_parametersValue[0]}");
                }
                tempInt += slavePeriod / 2;// slavePeriod是韌體的傳輸週期, 2是傳輸資料個數(2個ushort -> 4 Bytes)
            }
            if ((tempInt + slavePeriod * (m_nTimeCount - 1)) > 500)//chtArea.AxisX.ScaleView.Size=500, 這邊的500是從這來的
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Position = (tempInt + slavePeriod * (m_nTimeCount - 1)) - 500; //將視窗焦點維持在最新的點那邊
            }
        }

        private void Diagnosis_initControl()
        {
            comboBoxes = new System.Windows.Forms.ComboBox[4];
            comboBoxes[0] = comboBox1;
            comboBoxes[1] = comboBox2;
            comboBoxes[2] = comboBox3;
            comboBoxes[3] = comboBox4;
            pictureBoxes = new PictureBox[4];
            pictureBoxes[0] = pictureBox1;
            pictureBoxes[1] = pictureBox2;
            pictureBoxes[2] = pictureBox3;
            pictureBoxes[3] = pictureBox4;
            Diagnosis_labels = new Label[4];
            Diagnosis_labels[0] = label_Series0;
            Diagnosis_labels[1] = label_Series1;
            Diagnosis_labels[2] = label_Series2;
            Diagnosis_labels[3] = label_Series3;
            Diagnosis_labelsValue = new Label[4];
            Diagnosis_labelsValue[0] = label_Series0Value;
            Diagnosis_labelsValue[1] = label_Series1Value;
            Diagnosis_labelsValue[2] = label_Series2Value;
            Diagnosis_labelsValue[3] = label_Series3Value;
        }
        private void Diagnosis_visibleControl()
        {
            //隱藏所有Series
            foreach (var series in chart1.Series)
            {
                series.Enabled = false;
            }
            //隱藏所有label
            foreach (var label in Diagnosis_labels)
            {
                label.Visible = false;
            }
            //隱藏所有labelValue
            foreach (var labelValue in Diagnosis_labelsValue)
            {
                labelValue.Visible = false;
            }
        }
        private void Diagnosis_initChart()
        {
            Diagnosis_initControl();


            // 設定ChartArea 圖表設定 Chart設定
            ChartArea chtArea = new ChartArea("ViewArea");
            int interval = 10;
            chtArea.AxisX.Minimum = 0; //X軸數值從0開始
            chtArea.AxisX.ScaleView.Size = slavePeriod * interval; //設定視窗範圍內一開始顯示多少點
            chtArea.AxisX.Interval = slavePeriod;
            chtArea.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chtArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All; //設定scrollbar
            chtArea.AxisX.Title = "ms (毫秒)";
            chtArea.AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All; //設定scrollbar
            chtArea.AxisY.Title = "% (百分比)";
            chtArea.AxisY.Minimum = -20; //Y軸數值從0開始
            chtArea.AxisY.ScaleView.Size = 140; //設定視窗範圍內一開始顯示多少點
            chtArea.AxisY.Interval = 20;
            chtArea.Position.Auto = false; //改成不自動調整not Auto
            chtArea.Position = new ElementPosition(0, 0, 70, 100); // 設置位置和大小,手動調整
            chart1.ChartAreas[0] = chtArea; // chart new 出來時就有內建第一個chartarea
            chart1.Legends[0].Position.Auto = false; //改成不自動調整not Auto, 右上角圖標 
            chart1.Legends[0].Position = new ElementPosition(70, 0, 30, 40);// 設置位置和大小,手動調整


            //這邊的Main_labels.Length是依照label_MotorTemp這邊的數量去畫圖, 所以Comboboxes才只增加這些, 如果還要畫其他的就再更改for迴圈內容
            for (int i = 1; i < Main_labels.Length; i++)
            {
                Series series = new Series($"Series{i}");
                series.ChartType = SeriesChartType.Line;
                series.ChartArea = "ViewArea";
                chart1.Series.Add(series);
            }
            //這邊只是在改chart1裡面的series右上角label的名字
            for (int i = 0; i < Main_labels.Length; i++)
            {
                chart1.Series[i].Name = Main_labels[i].Text;
            }
            Diagnosis_visibleControl();


            // 指定輸出文件路徑
            string filePath = "output.csv";
            // 使用 StreamWriter 寫入 CSV 文件
            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // 寫入標題
                writer.WriteLine("Time, BusVolt, PhaseCur, RPM, DriverTemp, MotroTemp, MotorAngle, DcCur, TPS");
            }

            Diagnosis_addComboBoxItems();

        }

        /// <summary>
        /// 這個是用來模擬Can收發的方法, simCanStart這方法是開始Can, clsTimer是只給這兩個方法用的timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        System.Windows.Forms.Timer clsTimer = new System.Windows.Forms.Timer();//這個timer使用在下面這兩個method

        private void simCanStart_Click(object sender, EventArgs e)
        {
            label_CANConnectValue.Text = "✔";
            label_CANConnectValue.ForeColor = Color.Green;
            label_CANStatusValue.Text = "✔";
            label_CANStatusValue.ForeColor = Color.Green;
            // 設定 Timer
            clsTimer.Tick += new EventHandler(simCAN);
            clsTimer.Tick += new EventHandler(Diagnosis_updateChartSeries);
            clsTimer.Interval = (int)slavePeriod; // 每slavePeriod ms 就讀取一筆
            clsTimer.Start();
            simCanStart.Enabled = false;
            simCanStop.Enabled = true;
        }
        /// <summary>
        /// 這個是用來模擬Can收發的方法, simCanStop這方法是暫停Can, clsTimer是只給這兩個方法用的timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simCanStop_Click(object sender, EventArgs e)
        {
            label_CANConnectValue.Text = "✖";
            label_CANConnectValue.ForeColor = Color.Red;
            label_CANStatusValue.Text = "✖";
            label_CANStatusValue.ForeColor = Color.Red;
            // 取消 Timer裡面的事件
            clsTimer.Tick -= new EventHandler(simCAN);
            clsTimer.Tick -= new EventHandler(Diagnosis_updateChartSeries);
            clsTimer.Stop();
            simCanStart.Enabled = true;
            simCanStop.Enabled = false;
        }
        /// <summary>
        /// 增加comboBox裡面顯示的文字
        /// </summary>
        private void Diagnosis_addComboBoxItems()
        {
            for (int i = 0; i < comboBoxes.Length; i++) //這邊是comboBox的個數
            {
                for (int j = 0; j < chart1.Series.Count; j++) //這邊是數據的個數
                {
                    comboBoxes[i].Items.Add(Main_labels[j].Text);
                }
                comboBoxes[i].Items.Add("None");
            }

        }

        /// <summary>
        /// 在pictureBox裡面去畫Series圖標
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="color"></param>
        /// <param name="chartType"></param>
        private void Diagnosis_drawSeriesInPictureBox(PictureBox pictureBox, Color color, SeriesChartType chartType)
        {
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Pen pen = new Pen(color, 4);
                g.Clear(Color.Transparent);

                if (chartType == SeriesChartType.Line)
                {
                    g.DrawLine(pen, new Point(0, pictureBox.Height / 2), new Point(pictureBox.Width, pictureBox.Height / 2));
                }
                // 可以根據需要添加更多的線型類型
                pen.Dispose();
            }
            pictureBox.Image = bmp;
        }
        /// <summary>
        /// 靈活選擇Series顯示在第幾個comboBox都可以的功能
        /// 這裡包含兩層ComboBoxes, 第一個for 是選第幾個comboBox, 第二個for 是選SelectedIndex -> 就是選項第幾個
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Diagnosis_updateChartSeries(object sender, EventArgs e)
        {
            Diagnosis_visibleControl();
            for (int i = 0; i < comboBoxes.Length; i++)
            {
                var color = Color.White;//設定顏色
                int selectedIndex = comboBoxes[i].SelectedIndex;
                switch (i)
                {
                    case 0:
                        color = Color.Red;
                        break;
                    case 1:
                        color = Color.Purple;
                        break;
                    case 2:
                        color = Color.Green;
                        break;
                    case 3:
                        color = Color.Blue;
                        break;
                }
                if (selectedIndex >= 0 && selectedIndex < chart1.Series.Count)//comboBox裡面的選項
                {
                    var series = chart1.Series[selectedIndex];
                    series.Enabled = true;
                    series.Color = color;//讓series的顏色跟著comboBox走
                    Diagnosis_drawSeriesInPictureBox(pictureBoxes[i], series.Color, series.ChartType);
                    Diagnosis_labels[i].Text = comboBoxes[i].Text;//讓labels的文字顯現的是ComboBox設定的文字
                    Diagnosis_labelsValue[i].Text = (Main_parametersValue[selectedIndex]).ToString(); //顯示文字
                    Diagnosis_labels[i].Visible = true;
                    Diagnosis_labelsValue[i].Visible = true;
                }
                else
                {
                    pictureBoxes[i].Image = null; // 清除沒有選擇的 PictureBox 圖像
                }
            }
        }
        private void Diagnosis_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < comboBoxes.Length; i++)
            {
                if (sender == comboBoxes[i])
                {
                    Diagnosis_updateChartSeries(sender, e);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Diagnosis_comboBox_SelectedIndexChanged(sender, e);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Diagnosis_comboBox_SelectedIndexChanged(sender, e);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            Diagnosis_comboBox_SelectedIndexChanged(sender, e);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            Diagnosis_comboBox_SelectedIndexChanged(sender, e);
        }
        #endregion

        #region Setting區域 Setting頁面 
        private bool[] Setting_Func;
        private bool[] Setting_Prot;
        private bool[] Setting_Alarm;
        private void Setting_init() 
        {
            int settingFuncCount = groupBox_Function.Controls.Count;
            int settingProtCount = groupBox_Protection.Controls.Count;
            int settingAlarmCount = groupBox_SettingAlarm.Controls.Count;
            Setting_Func = new bool[settingFuncCount];
            Setting_Prot = new bool[settingProtCount];
            Setting_Alarm = new bool[settingAlarmCount];
        }

        private void detectSettingCheckBox() 
        {
            //低減速跟高減速只能擇一
            if (checkBox_LowBrakeFunc.Checked)
            {
                checkBox_HighBrakeFunc.Enabled = false;
            }
            else if (checkBox_HighBrakeFunc.Checked)
            {
                checkBox_LowBrakeFunc.Enabled = false;
            }
            else 
            {
                checkBox_HighBrakeFunc.Enabled = true;
                checkBox_LowBrakeFunc.Enabled = true;
            }
            //定速巡航不能下側柱跟設定成停車設定成Park
            if (checkBox_CruiseFunc.Checked)
            {
                checkBox_SideStandFunc.Enabled = false;
                checkBox_ParkFunc.Enabled = false;
            }
            else
            {
                checkBox_SideStandFunc.Enabled = true;
                checkBox_ParkFunc.Enabled = true;
            }
            //Derating按下去之後, 所有的Alarm都打勾, 取消時全部取消
            if (checkBox_DeratingAlarm.Checked)
            {
                foreach (CheckBox checkBox in groupBox_SettingAlarm.Controls.OfType<CheckBox>())
                {
                    checkBox.Checked = true;
                }
            }
            else 
            {
                foreach (CheckBox checkBox in groupBox_SettingAlarm.Controls.OfType<CheckBox>())
                {
                    checkBox.Checked = false;
                }
            }
        }
        private void Setting_updateCheckBox() 
        {
            Setting_Func[0] = checkBox_KeyOnFunc.Checked;
            Setting_Func[1] = checkBox_StartFunc.Checked;
            Setting_Func[2] = checkBox_CruiseFunc.Checked;
            Setting_Func[3] = checkBox_SideStandFunc.Checked;
            Setting_Func[4] = checkBox_LowBrakeFunc.Checked;
            Setting_Func[5] = checkBox_HighBrakeFunc.Checked;
            Setting_Func[6] = checkBox_BoostFunc.Checked;
            Setting_Func[7] = checkBox_ParkFunc.Checked;

            Setting_Prot[0] = checkBox_PhaseOCPProtect.Checked;
            Setting_Prot[1] = checkBox_OVPProtect.Checked;
            Setting_Prot[2] = checkBox_UVPProtect.Checked;
            Setting_Prot[3] = checkBox_DcOCPProtect.Checked;
            Setting_Prot[4] = checkBox_OTPMoterProtect.Checked;
            Setting_Prot[5] = checkBox_OTPDriverProtect.Checked;
            Setting_Prot[6] = checkBox_TPSHighProtect.Checked;
            Setting_Prot[7] = checkBox_HighSpeedProtect.Checked;

            Setting_Alarm[0] = checkBox_LowVoltAlarm.Checked;
            Setting_Alarm[1] = checkBox_HighCurAlarm.Checked;
            Setting_Alarm[2] = checkBox_LowTempMotorAlarm.Checked;
            Setting_Alarm[3] = checkBox_LowTempDriverAlarm.Checked;
            Setting_Alarm[4] = checkBox_HighTempMotorAlarm.Checked;
            Setting_Alarm[5] = checkBox_HighTempDriverAlarm.Checked;
            Setting_Alarm[6] = checkBox_DeratingAlarm.Checked;
            Setting_Alarm[7] = checkBox_HighSpeedAlarm.Checked;
            detectSettingCheckBox();
        }
        private void button_SettingStartMotor_Click(object sender, EventArgs e)
        {
            checkBox_KeyOnFunc.Checked = true;
            checkBox_StartFunc.Checked = true;
        }
        private void button_SettingRestartMotor_Click(object sender, EventArgs e)
        {
            foreach (CheckBox checkBox in groupBox_Function.Controls.OfType<CheckBox>())
            {
                checkBox.Checked = false;
            }
        }

        private void button_SettingDisableAlarm_Click(object sender, EventArgs e)
        {
            foreach (CheckBox checkBox in groupBox_SettingAlarm.Controls.OfType<CheckBox>())
            {
                checkBox.Checked = true;
            }
        }

        private void button_SettingDisableProtection_Click(object sender, EventArgs e)
        {
            foreach (CheckBox checkBox in groupBox_Protection.Controls.OfType<CheckBox>())
            {
                checkBox.Checked = true;
            }
        }
        #endregion
    }
}