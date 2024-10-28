namespace WindowsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_devtype = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Time1 = new System.Windows.Forms.TextBox();
            this.textBox_AccMask = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Mode = new System.Windows.Forms.ComboBox();
            this.comboBox_Filter = new System.Windows.Forms.ComboBox();
            this.textBox_Time0 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_AccCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_CANIndex = new System.Windows.Forms.ComboBox();
            this.comboBox_DevIndex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.button_StartCAN = new System.Windows.Forms.Button();
            this.button_StopCAN = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox_FrameFormat = new System.Windows.Forms.ComboBox();
            this.comboBox_FrameType = new System.Windows.Forms.ComboBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox_SendType = new System.Windows.Forms.ComboBox();
            this.comboBox_BaudRate = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Data = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox_Info = new System.Windows.Forms.ListBox();
            this.timer_rec = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_SettingDisableAlarm = new System.Windows.Forms.Button();
            this.button_SettingStartMotor = new System.Windows.Forms.Button();
            this.button_SettingDisableProtection = new System.Windows.Forms.Button();
            this.button_SettingRestartMotor = new System.Windows.Forms.Button();
            this.groupBox_GainSet = new System.Windows.Forms.GroupBox();
            this.label_TPSSet = new System.Windows.Forms.Label();
            this.textBox_MotorTempSetValue = new System.Windows.Forms.TextBox();
            this.label_BusVoltSet = new System.Windows.Forms.Label();
            this.label_MotorTempSet = new System.Windows.Forms.Label();
            this.label_PhaseCurSet = new System.Windows.Forms.Label();
            this.label_DriverTempSet = new System.Windows.Forms.Label();
            this.label_PISet = new System.Windows.Forms.Label();
            this.textBox_TPSSetValue = new System.Windows.Forms.TextBox();
            this.textBox_BusVoltSetValue = new System.Windows.Forms.TextBox();
            this.textBox_PhaseCurSetValue = new System.Windows.Forms.TextBox();
            this.textBox_DriverTempSetValue = new System.Windows.Forms.TextBox();
            this.textBox_PISetValue = new System.Windows.Forms.TextBox();
            this.groupBox_SettingAlarm = new System.Windows.Forms.GroupBox();
            this.checkBox_HighSpeedAlarm = new System.Windows.Forms.CheckBox();
            this.checkBox_LowVoltAlarm = new System.Windows.Forms.CheckBox();
            this.checkBox_DeratingAlarm = new System.Windows.Forms.CheckBox();
            this.checkBox_HighCurAlarm = new System.Windows.Forms.CheckBox();
            this.checkBox_HighTempDriverAlarm = new System.Windows.Forms.CheckBox();
            this.checkBox_LowTempMotorAlarm = new System.Windows.Forms.CheckBox();
            this.checkBox_LowTempDriverAlarm = new System.Windows.Forms.CheckBox();
            this.checkBox_HighTempMotorAlarm = new System.Windows.Forms.CheckBox();
            this.groupBox_Protection = new System.Windows.Forms.GroupBox();
            this.checkBox_HighSpeedProtect = new System.Windows.Forms.CheckBox();
            this.checkBox_TPSHighProtect = new System.Windows.Forms.CheckBox();
            this.checkBox_OTPDriverProtect = new System.Windows.Forms.CheckBox();
            this.checkBox_DcOCPProtect = new System.Windows.Forms.CheckBox();
            this.checkBox_OTPMoterProtect = new System.Windows.Forms.CheckBox();
            this.checkBox_UVPProtect = new System.Windows.Forms.CheckBox();
            this.checkBox_OVPProtect = new System.Windows.Forms.CheckBox();
            this.checkBox_PhaseOCPProtect = new System.Windows.Forms.CheckBox();
            this.groupBox_Function = new System.Windows.Forms.GroupBox();
            this.checkBox_ParkFunc = new System.Windows.Forms.CheckBox();
            this.checkBox_BoostFunc = new System.Windows.Forms.CheckBox();
            this.checkBox_HighBrakeFunc = new System.Windows.Forms.CheckBox();
            this.checkBox_LowBrakeFunc = new System.Windows.Forms.CheckBox();
            this.checkBox_SideStandFunc = new System.Windows.Forms.CheckBox();
            this.checkBox_CruiseFunc = new System.Windows.Forms.CheckBox();
            this.checkBox_StartFunc = new System.Windows.Forms.CheckBox();
            this.checkBox_KeyOnFunc = new System.Windows.Forms.CheckBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.button_Reset = new System.Windows.Forms.Button();
            this.button_Confirm = new System.Windows.Forms.Button();
            this.checkBox_AngleWriteControl = new System.Windows.Forms.CheckBox();
            this.checkBox_DutyControl = new System.Windows.Forms.CheckBox();
            this.checkBox_PhaseCurControl = new System.Windows.Forms.CheckBox();
            this.checkBox_TPSControl = new System.Windows.Forms.CheckBox();
            this.button_EMS = new System.Windows.Forms.Button();
            this.textBox_AngleWriteControl = new System.Windows.Forms.TextBox();
            this.label_AngleWriteControl = new System.Windows.Forms.Label();
            this.textBox_DutyControl = new System.Windows.Forms.TextBox();
            this.label_DutyControl = new System.Windows.Forms.Label();
            this.textBox_PhaseCurControl = new System.Windows.Forms.TextBox();
            this.label_PhaseCurControl = new System.Windows.Forms.Label();
            this.textBox_TPSControl = new System.Windows.Forms.TextBox();
            this.label_TPSControl = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label_Series3 = new System.Windows.Forms.Label();
            this.label_Series3Value = new System.Windows.Forms.Label();
            this.label_Series2 = new System.Windows.Forms.Label();
            this.label_Series2Value = new System.Windows.Forms.Label();
            this.label_Series1 = new System.Windows.Forms.Label();
            this.label_Series1Value = new System.Windows.Forms.Label();
            this.label_Series0 = new System.Windows.Forms.Label();
            this.label_Series0Value = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button_ClearAll = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label_SlavePeriod = new System.Windows.Forms.Label();
            this.button_ConfigConfirm = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.simCanStop = new System.Windows.Forms.Button();
            this.simCanStart = new System.Windows.Forms.Button();
            this.labelVersion = new System.Windows.Forms.Label();
            this.groupBox_Parameters = new System.Windows.Forms.GroupBox();
            this.label_TPSValue = new System.Windows.Forms.Label();
            this.label_TPS = new System.Windows.Forms.Label();
            this.label_MotorAngleValue = new System.Windows.Forms.Label();
            this.label_MotorAngle = new System.Windows.Forms.Label();
            this.label_MotorTempValue = new System.Windows.Forms.Label();
            this.label_MotorTemp = new System.Windows.Forms.Label();
            this.label_DriverTempValue = new System.Windows.Forms.Label();
            this.label_DriverTemp = new System.Windows.Forms.Label();
            this.label_SpeedValue = new System.Windows.Forms.Label();
            this.label_Speed = new System.Windows.Forms.Label();
            this.label_PhaseCurValue = new System.Windows.Forms.Label();
            this.label_PhaseCur = new System.Windows.Forms.Label();
            this.label_DcCurValue = new System.Windows.Forms.Label();
            this.label_DcCur = new System.Windows.Forms.Label();
            this.label_BusVolt = new System.Windows.Forms.Label();
            this.label_BusVoltValue = new System.Windows.Forms.Label();
            this.groupBox_Status = new System.Windows.Forms.GroupBox();
            this.label_CANConnectValue = new System.Windows.Forms.Label();
            this.label_CANConnect = new System.Windows.Forms.Label();
            this.label_CANStatusValue = new System.Windows.Forms.Label();
            this.label_CANStatus = new System.Windows.Forms.Label();
            this.groupBox_Error = new System.Windows.Forms.GroupBox();
            this.label_HighSpeedErr = new System.Windows.Forms.Label();
            this.label_OTPDriverErr = new System.Windows.Forms.Label();
            this.label_TPSHighErr = new System.Windows.Forms.Label();
            this.label_DcOCPErr = new System.Windows.Forms.Label();
            this.label_OTPMotorErr = new System.Windows.Forms.Label();
            this.label_UVPErr = new System.Windows.Forms.Label();
            this.label_OVPErr = new System.Windows.Forms.Label();
            this.label_PhaseOCPErr = new System.Windows.Forms.Label();
            this.groupBox_Alarm = new System.Windows.Forms.GroupBox();
            this.label_HighCurAlarm = new System.Windows.Forms.Label();
            this.label_LowTempDriverAlarm = new System.Windows.Forms.Label();
            this.label_HighTempDriverAlarm = new System.Windows.Forms.Label();
            this.label_DeratingAlarm = new System.Windows.Forms.Label();
            this.label_LowTempMotorAlarm = new System.Windows.Forms.Label();
            this.label_LowVoltAlarm = new System.Windows.Forms.Label();
            this.label_HighSpeedAlarm = new System.Windows.Forms.Label();
            this.label_HighTempMotorAlarm = new System.Windows.Forms.Label();
            this.groupBox_Flag = new System.Windows.Forms.GroupBox();
            this.label_Restart = new System.Windows.Forms.Label();
            this.label_RestartValue = new System.Windows.Forms.Label();
            this.label_ProtectActivation = new System.Windows.Forms.Label();
            this.label_ProtectActivationValue = new System.Windows.Forms.Label();
            this.label_SideStand = new System.Windows.Forms.Label();
            this.label_SideStandValue = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox_GainSet.SuspendLayout();
            this.groupBox_SettingAlarm.SuspendLayout();
            this.groupBox_Protection.SuspendLayout();
            this.groupBox_Function.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox_Parameters.SuspendLayout();
            this.groupBox_Status.SuspendLayout();
            this.groupBox_Error.SuspendLayout();
            this.groupBox_Alarm.SuspendLayout();
            this.groupBox_Flag.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_devtype);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.comboBox_CANIndex);
            this.groupBox1.Controls.Add(this.comboBox_DevIndex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 140);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备参数";
            // 
            // comboBox_devtype
            // 
            this.comboBox_devtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_devtype.FormattingEnabled = true;
            this.comboBox_devtype.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.comboBox_devtype.Location = new System.Drawing.Point(51, 19);
            this.comboBox_devtype.MaxDropDownItems = 15;
            this.comboBox_devtype.Name = "comboBox_devtype";
            this.comboBox_devtype.Size = new System.Drawing.Size(121, 20);
            this.comboBox_devtype.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 12);
            this.label14.TabIndex = 4;
            this.label14.Text = "类型:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Time1);
            this.groupBox2.Controls.Add(this.textBox_AccMask);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.comboBox_Mode);
            this.groupBox2.Controls.Add(this.comboBox_Filter);
            this.groupBox2.Controls.Add(this.textBox_Time0);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_AccCode);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(10, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 81);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "初始化CAN参数";
            // 
            // textBox_Time1
            // 
            this.textBox_Time1.Location = new System.Drawing.Point(218, 46);
            this.textBox_Time1.Name = "textBox_Time1";
            this.textBox_Time1.Size = new System.Drawing.Size(28, 22);
            this.textBox_Time1.TabIndex = 1;
            // 
            // textBox_AccMask
            // 
            this.textBox_AccMask.Location = new System.Drawing.Point(74, 46);
            this.textBox_AccMask.Name = "textBox_AccMask";
            this.textBox_AccMask.Size = new System.Drawing.Size(70, 22);
            this.textBox_AccMask.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "定时器1:0x";
            // 
            // comboBox_Mode
            // 
            this.comboBox_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Mode.FormattingEnabled = true;
            this.comboBox_Mode.Items.AddRange(new object[] {
            "正常",
            "只听"});
            this.comboBox_Mode.Location = new System.Drawing.Point(317, 48);
            this.comboBox_Mode.Name = "comboBox_Mode";
            this.comboBox_Mode.Size = new System.Drawing.Size(70, 20);
            this.comboBox_Mode.TabIndex = 1;
            // 
            // comboBox_Filter
            // 
            this.comboBox_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Filter.FormattingEnabled = true;
            this.comboBox_Filter.Items.AddRange(new object[] {
            "双滤波",
            "单滤波"});
            this.comboBox_Filter.Location = new System.Drawing.Point(317, 21);
            this.comboBox_Filter.Name = "comboBox_Filter";
            this.comboBox_Filter.Size = new System.Drawing.Size(70, 20);
            this.comboBox_Filter.TabIndex = 1;
            // 
            // textBox_Time0
            // 
            this.textBox_Time0.Location = new System.Drawing.Point(218, 19);
            this.textBox_Time0.Name = "textBox_Time0";
            this.textBox_Time0.Size = new System.Drawing.Size(28, 22);
            this.textBox_Time0.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(280, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "模式:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(256, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "滤波方式:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "屏蔽码:0x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "定时器0:0x";
            // 
            // textBox_AccCode
            // 
            this.textBox_AccCode.Location = new System.Drawing.Point(74, 19);
            this.textBox_AccCode.Name = "textBox_AccCode";
            this.textBox_AccCode.Size = new System.Drawing.Size(70, 22);
            this.textBox_AccCode.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "验收码:0x";
            // 
            // comboBox_CANIndex
            // 
            this.comboBox_CANIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CANIndex.FormattingEnabled = true;
            this.comboBox_CANIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBox_CANIndex.Location = new System.Drawing.Point(368, 23);
            this.comboBox_CANIndex.Name = "comboBox_CANIndex";
            this.comboBox_CANIndex.Size = new System.Drawing.Size(47, 20);
            this.comboBox_CANIndex.TabIndex = 1;
            // 
            // comboBox_DevIndex
            // 
            this.comboBox_DevIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DevIndex.FormattingEnabled = true;
            this.comboBox_DevIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboBox_DevIndex.Location = new System.Drawing.Point(238, 23);
            this.comboBox_DevIndex.Name = "comboBox_DevIndex";
            this.comboBox_DevIndex.Size = new System.Drawing.Size(41, 20);
            this.comboBox_DevIndex.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "第几路CAN:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "索引号:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(6, 19);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "連接CAN";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // button_StartCAN
            // 
            this.button_StartCAN.Location = new System.Drawing.Point(87, 19);
            this.button_StartCAN.Name = "button_StartCAN";
            this.button_StartCAN.Size = new System.Drawing.Size(75, 23);
            this.button_StartCAN.TabIndex = 5;
            this.button_StartCAN.Text = "開始CAN";
            this.button_StartCAN.UseVisualStyleBackColor = true;
            this.button_StartCAN.Click += new System.EventHandler(this.button_StartCAN_Click);
            // 
            // button_StopCAN
            // 
            this.button_StopCAN.Location = new System.Drawing.Point(168, 19);
            this.button_StopCAN.Name = "button_StopCAN";
            this.button_StopCAN.Size = new System.Drawing.Size(75, 23);
            this.button_StopCAN.TabIndex = 5;
            this.button_StopCAN.Text = "停止CAN";
            this.button_StopCAN.UseVisualStyleBackColor = true;
            this.button_StopCAN.Click += new System.EventHandler(this.button_StopCAN_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox_FrameFormat);
            this.groupBox3.Controls.Add(this.comboBox_FrameType);
            this.groupBox3.Controls.Add(this.button_Send);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.comboBox_SendType);
            this.groupBox3.Controls.Add(this.comboBox_BaudRate);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBox_Data);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.textBox_ID);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(20, 179);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(425, 108);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送数据帧";
            // 
            // comboBox_FrameFormat
            // 
            this.comboBox_FrameFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FrameFormat.FormattingEnabled = true;
            this.comboBox_FrameFormat.Items.AddRange(new object[] {
            "数据帧",
            "远程帧"});
            this.comboBox_FrameFormat.Location = new System.Drawing.Point(324, 19);
            this.comboBox_FrameFormat.Name = "comboBox_FrameFormat";
            this.comboBox_FrameFormat.Size = new System.Drawing.Size(70, 20);
            this.comboBox_FrameFormat.TabIndex = 1;
            // 
            // comboBox_FrameType
            // 
            this.comboBox_FrameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FrameType.FormattingEnabled = true;
            this.comboBox_FrameType.Items.AddRange(new object[] {
            "标准帧",
            "扩展帧"});
            this.comboBox_FrameType.Location = new System.Drawing.Point(197, 20);
            this.comboBox_FrameType.Name = "comboBox_FrameType";
            this.comboBox_FrameType.Size = new System.Drawing.Size(70, 20);
            this.comboBox_FrameType.TabIndex = 1;
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(325, 72);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 23);
            this.button_Send.TabIndex = 5;
            this.button_Send.Text = "发送";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(275, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "帧格式:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(148, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "帧类型:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(149, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "鮑率";
            // 
            // comboBox_SendType
            // 
            this.comboBox_SendType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SendType.FormattingEnabled = true;
            this.comboBox_SendType.Items.AddRange(new object[] {
            "正常发送",
            "单次正常发送",
            "自发自收",
            "单次自发自收"});
            this.comboBox_SendType.Location = new System.Drawing.Point(71, 20);
            this.comboBox_SendType.Name = "comboBox_SendType";
            this.comboBox_SendType.Size = new System.Drawing.Size(70, 20);
            this.comboBox_SendType.TabIndex = 1;
            // 
            // comboBox_BaudRate
            // 
            this.comboBox_BaudRate.FormattingEnabled = true;
            this.comboBox_BaudRate.Items.AddRange(new object[] {
            "5Kbps",
            "10Kbps",
            "20Kbps",
            "40Kbps",
            "50Kbps",
            "80Kbps",
            "100Kbps",
            "125Kbps",
            "200Kbps",
            "250Kbps",
            "400Kbps",
            "500Kbps",
            "666Kbps",
            "800Kbps",
            "1000Kbps"});
            this.comboBox_BaudRate.Location = new System.Drawing.Point(197, 48);
            this.comboBox_BaudRate.Name = "comboBox_BaudRate";
            this.comboBox_BaudRate.Size = new System.Drawing.Size(70, 20);
            this.comboBox_BaudRate.TabIndex = 3;
            this.comboBox_BaudRate.SelectedIndexChanged += new System.EventHandler(this.comboBox_BaudRate_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "发送格式:";
            // 
            // textBox_Data
            // 
            this.textBox_Data.Location = new System.Drawing.Point(56, 73);
            this.textBox_Data.Name = "textBox_Data";
            this.textBox_Data.Size = new System.Drawing.Size(251, 22);
            this.textBox_Data.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "数据:";
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(69, 46);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(70, 22);
            this.textBox_ID.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "帧ID:0x";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox_Info);
            this.groupBox4.Location = new System.Drawing.Point(20, 293);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(754, 375);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "所有信息";
            // 
            // listBox_Info
            // 
            this.listBox_Info.FormattingEnabled = true;
            this.listBox_Info.ItemHeight = 12;
            this.listBox_Info.Location = new System.Drawing.Point(10, 28);
            this.listBox_Info.Name = "listBox_Info";
            this.listBox_Info.Size = new System.Drawing.Size(733, 328);
            this.listBox_Info.TabIndex = 0;
            // 
            // timer_rec
            // 
            this.timer_rec.Interval = 60;
            this.timer_rec.Tick += new System.EventHandler(this.timer_rec_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(802, 725);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_SettingDisableAlarm);
            this.tabPage1.Controls.Add(this.button_SettingStartMotor);
            this.tabPage1.Controls.Add(this.button_SettingDisableProtection);
            this.tabPage1.Controls.Add(this.button_SettingRestartMotor);
            this.tabPage1.Controls.Add(this.groupBox_GainSet);
            this.tabPage1.Controls.Add(this.groupBox_SettingAlarm);
            this.tabPage1.Controls.Add(this.groupBox_Protection);
            this.tabPage1.Controls.Add(this.groupBox_Function);
            this.tabPage1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(794, 699);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Setting";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button_SettingDisableAlarm
            // 
            this.button_SettingDisableAlarm.BackColor = System.Drawing.Color.Red;
            this.button_SettingDisableAlarm.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SettingDisableAlarm.ForeColor = System.Drawing.Color.White;
            this.button_SettingDisableAlarm.Location = new System.Drawing.Point(350, 539);
            this.button_SettingDisableAlarm.Name = "button_SettingDisableAlarm";
            this.button_SettingDisableAlarm.Size = new System.Drawing.Size(146, 82);
            this.button_SettingDisableAlarm.TabIndex = 37;
            this.button_SettingDisableAlarm.Text = "Disable Alarm";
            this.button_SettingDisableAlarm.UseVisualStyleBackColor = false;
            this.button_SettingDisableAlarm.Click += new System.EventHandler(this.button_SettingDisableAlarm_Click);
            // 
            // button_SettingStartMotor
            // 
            this.button_SettingStartMotor.BackColor = System.Drawing.Color.GreenYellow;
            this.button_SettingStartMotor.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SettingStartMotor.ForeColor = System.Drawing.Color.Black;
            this.button_SettingStartMotor.Location = new System.Drawing.Point(350, 412);
            this.button_SettingStartMotor.Name = "button_SettingStartMotor";
            this.button_SettingStartMotor.Size = new System.Drawing.Size(146, 82);
            this.button_SettingStartMotor.TabIndex = 36;
            this.button_SettingStartMotor.Text = "Start Motor";
            this.button_SettingStartMotor.UseVisualStyleBackColor = false;
            this.button_SettingStartMotor.Click += new System.EventHandler(this.button_SettingStartMotor_Click);
            // 
            // button_SettingDisableProtection
            // 
            this.button_SettingDisableProtection.BackColor = System.Drawing.Color.Red;
            this.button_SettingDisableProtection.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SettingDisableProtection.ForeColor = System.Drawing.Color.White;
            this.button_SettingDisableProtection.Location = new System.Drawing.Point(551, 539);
            this.button_SettingDisableProtection.Name = "button_SettingDisableProtection";
            this.button_SettingDisableProtection.Size = new System.Drawing.Size(146, 82);
            this.button_SettingDisableProtection.TabIndex = 35;
            this.button_SettingDisableProtection.Text = "Disable Protection";
            this.button_SettingDisableProtection.UseVisualStyleBackColor = false;
            this.button_SettingDisableProtection.Click += new System.EventHandler(this.button_SettingDisableProtection_Click);
            // 
            // button_SettingRestartMotor
            // 
            this.button_SettingRestartMotor.BackColor = System.Drawing.Color.Yellow;
            this.button_SettingRestartMotor.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SettingRestartMotor.ForeColor = System.Drawing.Color.Black;
            this.button_SettingRestartMotor.Location = new System.Drawing.Point(551, 412);
            this.button_SettingRestartMotor.Name = "button_SettingRestartMotor";
            this.button_SettingRestartMotor.Size = new System.Drawing.Size(146, 82);
            this.button_SettingRestartMotor.TabIndex = 34;
            this.button_SettingRestartMotor.Text = "Restart Motor";
            this.button_SettingRestartMotor.UseVisualStyleBackColor = false;
            this.button_SettingRestartMotor.Click += new System.EventHandler(this.button_SettingRestartMotor_Click);
            // 
            // groupBox_GainSet
            // 
            this.groupBox_GainSet.Controls.Add(this.label_TPSSet);
            this.groupBox_GainSet.Controls.Add(this.textBox_MotorTempSetValue);
            this.groupBox_GainSet.Controls.Add(this.label_BusVoltSet);
            this.groupBox_GainSet.Controls.Add(this.label_MotorTempSet);
            this.groupBox_GainSet.Controls.Add(this.label_PhaseCurSet);
            this.groupBox_GainSet.Controls.Add(this.label_DriverTempSet);
            this.groupBox_GainSet.Controls.Add(this.label_PISet);
            this.groupBox_GainSet.Controls.Add(this.textBox_TPSSetValue);
            this.groupBox_GainSet.Controls.Add(this.textBox_BusVoltSetValue);
            this.groupBox_GainSet.Controls.Add(this.textBox_PhaseCurSetValue);
            this.groupBox_GainSet.Controls.Add(this.textBox_DriverTempSetValue);
            this.groupBox_GainSet.Controls.Add(this.textBox_PISetValue);
            this.groupBox_GainSet.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_GainSet.Location = new System.Drawing.Point(350, 19);
            this.groupBox_GainSet.Name = "groupBox_GainSet";
            this.groupBox_GainSet.Size = new System.Drawing.Size(347, 342);
            this.groupBox_GainSet.TabIndex = 33;
            this.groupBox_GainSet.TabStop = false;
            this.groupBox_GainSet.Text = "Gain Set";
            // 
            // label_TPSSet
            // 
            this.label_TPSSet.AutoSize = true;
            this.label_TPSSet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TPSSet.Location = new System.Drawing.Point(23, 46);
            this.label_TPSSet.Name = "label_TPSSet";
            this.label_TPSSet.Size = new System.Drawing.Size(56, 19);
            this.label_TPSSet.TabIndex = 10;
            this.label_TPSSet.Text = "TPSSet";
            // 
            // textBox_MotorTempSetValue
            // 
            this.textBox_MotorTempSetValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MotorTempSetValue.Location = new System.Drawing.Point(178, 227);
            this.textBox_MotorTempSetValue.Name = "textBox_MotorTempSetValue";
            this.textBox_MotorTempSetValue.Size = new System.Drawing.Size(100, 26);
            this.textBox_MotorTempSetValue.TabIndex = 32;
            // 
            // label_BusVoltSet
            // 
            this.label_BusVoltSet.AutoSize = true;
            this.label_BusVoltSet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_BusVoltSet.Location = new System.Drawing.Point(23, 92);
            this.label_BusVoltSet.Name = "label_BusVoltSet";
            this.label_BusVoltSet.Size = new System.Drawing.Size(88, 19);
            this.label_BusVoltSet.TabIndex = 12;
            this.label_BusVoltSet.Text = "Bus Volt. Set";
            // 
            // label_MotorTempSet
            // 
            this.label_MotorTempSet.AutoSize = true;
            this.label_MotorTempSet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MotorTempSet.Location = new System.Drawing.Point(23, 230);
            this.label_MotorTempSet.Name = "label_MotorTempSet";
            this.label_MotorTempSet.Size = new System.Drawing.Size(114, 19);
            this.label_MotorTempSet.TabIndex = 31;
            this.label_MotorTempSet.Text = "Motor Temp. Set";
            // 
            // label_PhaseCurSet
            // 
            this.label_PhaseCurSet.AutoSize = true;
            this.label_PhaseCurSet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PhaseCurSet.Location = new System.Drawing.Point(23, 141);
            this.label_PhaseCurSet.Name = "label_PhaseCurSet";
            this.label_PhaseCurSet.Size = new System.Drawing.Size(99, 19);
            this.label_PhaseCurSet.TabIndex = 14;
            this.label_PhaseCurSet.Text = "Phase Cur. Set";
            // 
            // label_DriverTempSet
            // 
            this.label_DriverTempSet.AutoSize = true;
            this.label_DriverTempSet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DriverTempSet.Location = new System.Drawing.Point(23, 187);
            this.label_DriverTempSet.Name = "label_DriverTempSet";
            this.label_DriverTempSet.Size = new System.Drawing.Size(113, 19);
            this.label_DriverTempSet.TabIndex = 16;
            this.label_DriverTempSet.Text = "Driver Temp. Set";
            // 
            // label_PISet
            // 
            this.label_PISet.AutoSize = true;
            this.label_PISet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PISet.Location = new System.Drawing.Point(23, 279);
            this.label_PISet.Name = "label_PISet";
            this.label_PISet.Size = new System.Drawing.Size(43, 19);
            this.label_PISet.TabIndex = 18;
            this.label_PISet.Text = "PISet";
            // 
            // textBox_TPSSetValue
            // 
            this.textBox_TPSSetValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TPSSetValue.Location = new System.Drawing.Point(178, 43);
            this.textBox_TPSSetValue.Name = "textBox_TPSSetValue";
            this.textBox_TPSSetValue.Size = new System.Drawing.Size(100, 26);
            this.textBox_TPSSetValue.TabIndex = 19;
            // 
            // textBox_BusVoltSetValue
            // 
            this.textBox_BusVoltSetValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_BusVoltSetValue.Location = new System.Drawing.Point(178, 89);
            this.textBox_BusVoltSetValue.Name = "textBox_BusVoltSetValue";
            this.textBox_BusVoltSetValue.Size = new System.Drawing.Size(100, 26);
            this.textBox_BusVoltSetValue.TabIndex = 20;
            // 
            // textBox_PhaseCurSetValue
            // 
            this.textBox_PhaseCurSetValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_PhaseCurSetValue.Location = new System.Drawing.Point(178, 138);
            this.textBox_PhaseCurSetValue.Name = "textBox_PhaseCurSetValue";
            this.textBox_PhaseCurSetValue.Size = new System.Drawing.Size(100, 26);
            this.textBox_PhaseCurSetValue.TabIndex = 21;
            // 
            // textBox_DriverTempSetValue
            // 
            this.textBox_DriverTempSetValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DriverTempSetValue.Location = new System.Drawing.Point(178, 184);
            this.textBox_DriverTempSetValue.Name = "textBox_DriverTempSetValue";
            this.textBox_DriverTempSetValue.Size = new System.Drawing.Size(100, 26);
            this.textBox_DriverTempSetValue.TabIndex = 22;
            // 
            // textBox_PISetValue
            // 
            this.textBox_PISetValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_PISetValue.Location = new System.Drawing.Point(178, 276);
            this.textBox_PISetValue.Name = "textBox_PISetValue";
            this.textBox_PISetValue.Size = new System.Drawing.Size(100, 26);
            this.textBox_PISetValue.TabIndex = 23;
            // 
            // groupBox_SettingAlarm
            // 
            this.groupBox_SettingAlarm.Controls.Add(this.checkBox_HighSpeedAlarm);
            this.groupBox_SettingAlarm.Controls.Add(this.checkBox_LowVoltAlarm);
            this.groupBox_SettingAlarm.Controls.Add(this.checkBox_DeratingAlarm);
            this.groupBox_SettingAlarm.Controls.Add(this.checkBox_HighCurAlarm);
            this.groupBox_SettingAlarm.Controls.Add(this.checkBox_HighTempDriverAlarm);
            this.groupBox_SettingAlarm.Controls.Add(this.checkBox_LowTempMotorAlarm);
            this.groupBox_SettingAlarm.Controls.Add(this.checkBox_LowTempDriverAlarm);
            this.groupBox_SettingAlarm.Controls.Add(this.checkBox_HighTempMotorAlarm);
            this.groupBox_SettingAlarm.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_SettingAlarm.Location = new System.Drawing.Point(11, 431);
            this.groupBox_SettingAlarm.Name = "groupBox_SettingAlarm";
            this.groupBox_SettingAlarm.Size = new System.Drawing.Size(236, 179);
            this.groupBox_SettingAlarm.TabIndex = 30;
            this.groupBox_SettingAlarm.TabStop = false;
            this.groupBox_SettingAlarm.Text = "Alarm";
            // 
            // checkBox_HighSpeedAlarm
            // 
            this.checkBox_HighSpeedAlarm.AutoSize = true;
            this.checkBox_HighSpeedAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_HighSpeedAlarm.Location = new System.Drawing.Point(123, 133);
            this.checkBox_HighSpeedAlarm.Name = "checkBox_HighSpeedAlarm";
            this.checkBox_HighSpeedAlarm.Size = new System.Drawing.Size(82, 23);
            this.checkBox_HighSpeedAlarm.TabIndex = 15;
            this.checkBox_HighSpeedAlarm.Text = "H.Speed";
            this.checkBox_HighSpeedAlarm.UseVisualStyleBackColor = true;
            // 
            // checkBox_LowVoltAlarm
            // 
            this.checkBox_LowVoltAlarm.AutoSize = true;
            this.checkBox_LowVoltAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_LowVoltAlarm.Location = new System.Drawing.Point(10, 41);
            this.checkBox_LowVoltAlarm.Name = "checkBox_LowVoltAlarm";
            this.checkBox_LowVoltAlarm.Size = new System.Drawing.Size(69, 23);
            this.checkBox_LowVoltAlarm.TabIndex = 8;
            this.checkBox_LowVoltAlarm.Text = "L. Volt";
            this.checkBox_LowVoltAlarm.UseVisualStyleBackColor = true;
            // 
            // checkBox_DeratingAlarm
            // 
            this.checkBox_DeratingAlarm.AutoSize = true;
            this.checkBox_DeratingAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_DeratingAlarm.Location = new System.Drawing.Point(10, 133);
            this.checkBox_DeratingAlarm.Name = "checkBox_DeratingAlarm";
            this.checkBox_DeratingAlarm.Size = new System.Drawing.Size(79, 23);
            this.checkBox_DeratingAlarm.TabIndex = 14;
            this.checkBox_DeratingAlarm.Text = "Derating";
            this.checkBox_DeratingAlarm.UseVisualStyleBackColor = true;
            this.checkBox_DeratingAlarm.CheckedChanged += new System.EventHandler(this.checkBox_DeratingAlarm_CheckedChanged);
            // 
            // checkBox_HighCurAlarm
            // 
            this.checkBox_HighCurAlarm.AutoSize = true;
            this.checkBox_HighCurAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_HighCurAlarm.Location = new System.Drawing.Point(123, 41);
            this.checkBox_HighCurAlarm.Name = "checkBox_HighCurAlarm";
            this.checkBox_HighCurAlarm.Size = new System.Drawing.Size(69, 23);
            this.checkBox_HighCurAlarm.TabIndex = 9;
            this.checkBox_HighCurAlarm.Text = "H.Cur.";
            this.checkBox_HighCurAlarm.UseVisualStyleBackColor = true;
            // 
            // checkBox_HighTempDriverAlarm
            // 
            this.checkBox_HighTempDriverAlarm.AutoSize = true;
            this.checkBox_HighTempDriverAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_HighTempDriverAlarm.Location = new System.Drawing.Point(123, 104);
            this.checkBox_HighTempDriverAlarm.Name = "checkBox_HighTempDriverAlarm";
            this.checkBox_HighTempDriverAlarm.Size = new System.Drawing.Size(96, 23);
            this.checkBox_HighTempDriverAlarm.TabIndex = 13;
            this.checkBox_HighTempDriverAlarm.Text = "H.Temp.D.";
            this.checkBox_HighTempDriverAlarm.UseVisualStyleBackColor = true;
            // 
            // checkBox_LowTempMotorAlarm
            // 
            this.checkBox_LowTempMotorAlarm.AutoSize = true;
            this.checkBox_LowTempMotorAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_LowTempMotorAlarm.Location = new System.Drawing.Point(10, 72);
            this.checkBox_LowTempMotorAlarm.Name = "checkBox_LowTempMotorAlarm";
            this.checkBox_LowTempMotorAlarm.Size = new System.Drawing.Size(97, 23);
            this.checkBox_LowTempMotorAlarm.TabIndex = 10;
            this.checkBox_LowTempMotorAlarm.Text = "L.Temp.M.";
            this.checkBox_LowTempMotorAlarm.UseVisualStyleBackColor = true;
            // 
            // checkBox_LowTempDriverAlarm
            // 
            this.checkBox_LowTempDriverAlarm.AutoSize = true;
            this.checkBox_LowTempDriverAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_LowTempDriverAlarm.Location = new System.Drawing.Point(123, 72);
            this.checkBox_LowTempDriverAlarm.Name = "checkBox_LowTempDriverAlarm";
            this.checkBox_LowTempDriverAlarm.Size = new System.Drawing.Size(94, 23);
            this.checkBox_LowTempDriverAlarm.TabIndex = 12;
            this.checkBox_LowTempDriverAlarm.Text = "L.Temp.D.";
            this.checkBox_LowTempDriverAlarm.UseVisualStyleBackColor = true;
            // 
            // checkBox_HighTempMotorAlarm
            // 
            this.checkBox_HighTempMotorAlarm.AutoSize = true;
            this.checkBox_HighTempMotorAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_HighTempMotorAlarm.Location = new System.Drawing.Point(10, 104);
            this.checkBox_HighTempMotorAlarm.Name = "checkBox_HighTempMotorAlarm";
            this.checkBox_HighTempMotorAlarm.Size = new System.Drawing.Size(99, 23);
            this.checkBox_HighTempMotorAlarm.TabIndex = 11;
            this.checkBox_HighTempMotorAlarm.Text = "H.Temp.M.";
            this.checkBox_HighTempMotorAlarm.UseVisualStyleBackColor = true;
            // 
            // groupBox_Protection
            // 
            this.groupBox_Protection.Controls.Add(this.checkBox_HighSpeedProtect);
            this.groupBox_Protection.Controls.Add(this.checkBox_TPSHighProtect);
            this.groupBox_Protection.Controls.Add(this.checkBox_OTPDriverProtect);
            this.groupBox_Protection.Controls.Add(this.checkBox_DcOCPProtect);
            this.groupBox_Protection.Controls.Add(this.checkBox_OTPMoterProtect);
            this.groupBox_Protection.Controls.Add(this.checkBox_UVPProtect);
            this.groupBox_Protection.Controls.Add(this.checkBox_OVPProtect);
            this.groupBox_Protection.Controls.Add(this.checkBox_PhaseOCPProtect);
            this.groupBox_Protection.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Protection.Location = new System.Drawing.Point(11, 235);
            this.groupBox_Protection.Name = "groupBox_Protection";
            this.groupBox_Protection.Size = new System.Drawing.Size(236, 179);
            this.groupBox_Protection.TabIndex = 29;
            this.groupBox_Protection.TabStop = false;
            this.groupBox_Protection.Text = "Protection";
            // 
            // checkBox_HighSpeedProtect
            // 
            this.checkBox_HighSpeedProtect.AutoSize = true;
            this.checkBox_HighSpeedProtect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_HighSpeedProtect.Location = new System.Drawing.Point(123, 129);
            this.checkBox_HighSpeedProtect.Name = "checkBox_HighSpeedProtect";
            this.checkBox_HighSpeedProtect.Size = new System.Drawing.Size(99, 23);
            this.checkBox_HighSpeedProtect.TabIndex = 7;
            this.checkBox_HighSpeedProtect.Text = "High Speed";
            this.checkBox_HighSpeedProtect.UseVisualStyleBackColor = true;
            // 
            // checkBox_TPSHighProtect
            // 
            this.checkBox_TPSHighProtect.AutoSize = true;
            this.checkBox_TPSHighProtect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_TPSHighProtect.Location = new System.Drawing.Point(10, 129);
            this.checkBox_TPSHighProtect.Name = "checkBox_TPSHighProtect";
            this.checkBox_TPSHighProtect.Size = new System.Drawing.Size(87, 23);
            this.checkBox_TPSHighProtect.TabIndex = 6;
            this.checkBox_TPSHighProtect.Text = "TPS High";
            this.checkBox_TPSHighProtect.UseVisualStyleBackColor = true;
            // 
            // checkBox_OTPDriverProtect
            // 
            this.checkBox_OTPDriverProtect.AutoSize = true;
            this.checkBox_OTPDriverProtect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_OTPDriverProtect.Location = new System.Drawing.Point(123, 100);
            this.checkBox_OTPDriverProtect.Name = "checkBox_OTPDriverProtect";
            this.checkBox_OTPDriverProtect.Size = new System.Drawing.Size(99, 23);
            this.checkBox_OTPDriverProtect.TabIndex = 5;
            this.checkBox_OTPDriverProtect.Text = "OTP Driver";
            this.checkBox_OTPDriverProtect.UseVisualStyleBackColor = true;
            // 
            // checkBox_DcOCPProtect
            // 
            this.checkBox_DcOCPProtect.AutoSize = true;
            this.checkBox_DcOCPProtect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_DcOCPProtect.Location = new System.Drawing.Point(123, 68);
            this.checkBox_DcOCPProtect.Name = "checkBox_DcOCPProtect";
            this.checkBox_DcOCPProtect.Size = new System.Drawing.Size(82, 23);
            this.checkBox_DcOCPProtect.TabIndex = 4;
            this.checkBox_DcOCPProtect.Text = "Dc OCP";
            this.checkBox_DcOCPProtect.UseVisualStyleBackColor = true;
            // 
            // checkBox_OTPMoterProtect
            // 
            this.checkBox_OTPMoterProtect.AutoSize = true;
            this.checkBox_OTPMoterProtect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_OTPMoterProtect.Location = new System.Drawing.Point(10, 100);
            this.checkBox_OTPMoterProtect.Name = "checkBox_OTPMoterProtect";
            this.checkBox_OTPMoterProtect.Size = new System.Drawing.Size(99, 23);
            this.checkBox_OTPMoterProtect.TabIndex = 3;
            this.checkBox_OTPMoterProtect.Text = "OTP Moter";
            this.checkBox_OTPMoterProtect.UseVisualStyleBackColor = true;
            // 
            // checkBox_UVPProtect
            // 
            this.checkBox_UVPProtect.AutoSize = true;
            this.checkBox_UVPProtect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_UVPProtect.Location = new System.Drawing.Point(10, 68);
            this.checkBox_UVPProtect.Name = "checkBox_UVPProtect";
            this.checkBox_UVPProtect.Size = new System.Drawing.Size(59, 23);
            this.checkBox_UVPProtect.TabIndex = 2;
            this.checkBox_UVPProtect.Text = "UVP";
            this.checkBox_UVPProtect.UseVisualStyleBackColor = true;
            // 
            // checkBox_OVPProtect
            // 
            this.checkBox_OVPProtect.AutoSize = true;
            this.checkBox_OVPProtect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_OVPProtect.Location = new System.Drawing.Point(123, 37);
            this.checkBox_OVPProtect.Name = "checkBox_OVPProtect";
            this.checkBox_OVPProtect.Size = new System.Drawing.Size(60, 23);
            this.checkBox_OVPProtect.TabIndex = 1;
            this.checkBox_OVPProtect.Text = "OVP";
            this.checkBox_OVPProtect.UseVisualStyleBackColor = true;
            // 
            // checkBox_PhaseOCPProtect
            // 
            this.checkBox_PhaseOCPProtect.AutoSize = true;
            this.checkBox_PhaseOCPProtect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_PhaseOCPProtect.Location = new System.Drawing.Point(10, 37);
            this.checkBox_PhaseOCPProtect.Name = "checkBox_PhaseOCPProtect";
            this.checkBox_PhaseOCPProtect.Size = new System.Drawing.Size(100, 23);
            this.checkBox_PhaseOCPProtect.TabIndex = 0;
            this.checkBox_PhaseOCPProtect.Text = "Phase OCP";
            this.checkBox_PhaseOCPProtect.UseVisualStyleBackColor = true;
            // 
            // groupBox_Function
            // 
            this.groupBox_Function.Controls.Add(this.checkBox_ParkFunc);
            this.groupBox_Function.Controls.Add(this.checkBox_BoostFunc);
            this.groupBox_Function.Controls.Add(this.checkBox_HighBrakeFunc);
            this.groupBox_Function.Controls.Add(this.checkBox_LowBrakeFunc);
            this.groupBox_Function.Controls.Add(this.checkBox_SideStandFunc);
            this.groupBox_Function.Controls.Add(this.checkBox_CruiseFunc);
            this.groupBox_Function.Controls.Add(this.checkBox_StartFunc);
            this.groupBox_Function.Controls.Add(this.checkBox_KeyOnFunc);
            this.groupBox_Function.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Function.Location = new System.Drawing.Point(11, 19);
            this.groupBox_Function.Name = "groupBox_Function";
            this.groupBox_Function.Size = new System.Drawing.Size(236, 179);
            this.groupBox_Function.TabIndex = 28;
            this.groupBox_Function.TabStop = false;
            this.groupBox_Function.Text = "Function";
            // 
            // checkBox_ParkFunc
            // 
            this.checkBox_ParkFunc.AutoSize = true;
            this.checkBox_ParkFunc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_ParkFunc.Location = new System.Drawing.Point(123, 134);
            this.checkBox_ParkFunc.Name = "checkBox_ParkFunc";
            this.checkBox_ParkFunc.Size = new System.Drawing.Size(57, 23);
            this.checkBox_ParkFunc.TabIndex = 7;
            this.checkBox_ParkFunc.Text = "Park";
            this.checkBox_ParkFunc.UseVisualStyleBackColor = true;
            // 
            // checkBox_BoostFunc
            // 
            this.checkBox_BoostFunc.AutoSize = true;
            this.checkBox_BoostFunc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_BoostFunc.Location = new System.Drawing.Point(10, 134);
            this.checkBox_BoostFunc.Name = "checkBox_BoostFunc";
            this.checkBox_BoostFunc.Size = new System.Drawing.Size(64, 23);
            this.checkBox_BoostFunc.TabIndex = 6;
            this.checkBox_BoostFunc.Text = "Boost";
            this.checkBox_BoostFunc.UseVisualStyleBackColor = true;
            // 
            // checkBox_HighBrakeFunc
            // 
            this.checkBox_HighBrakeFunc.AutoSize = true;
            this.checkBox_HighBrakeFunc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_HighBrakeFunc.Location = new System.Drawing.Point(123, 105);
            this.checkBox_HighBrakeFunc.Name = "checkBox_HighBrakeFunc";
            this.checkBox_HighBrakeFunc.Size = new System.Drawing.Size(97, 23);
            this.checkBox_HighBrakeFunc.TabIndex = 5;
            this.checkBox_HighBrakeFunc.Text = "High Brake";
            this.checkBox_HighBrakeFunc.UseVisualStyleBackColor = true;
            // 
            // checkBox_LowBrakeFunc
            // 
            this.checkBox_LowBrakeFunc.AutoSize = true;
            this.checkBox_LowBrakeFunc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_LowBrakeFunc.Location = new System.Drawing.Point(10, 105);
            this.checkBox_LowBrakeFunc.Name = "checkBox_LowBrakeFunc";
            this.checkBox_LowBrakeFunc.Size = new System.Drawing.Size(97, 23);
            this.checkBox_LowBrakeFunc.TabIndex = 4;
            this.checkBox_LowBrakeFunc.Text = "Low Brake";
            this.checkBox_LowBrakeFunc.UseVisualStyleBackColor = true;
            // 
            // checkBox_SideStandFunc
            // 
            this.checkBox_SideStandFunc.AutoSize = true;
            this.checkBox_SideStandFunc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_SideStandFunc.Location = new System.Drawing.Point(123, 73);
            this.checkBox_SideStandFunc.Name = "checkBox_SideStandFunc";
            this.checkBox_SideStandFunc.Size = new System.Drawing.Size(94, 23);
            this.checkBox_SideStandFunc.TabIndex = 3;
            this.checkBox_SideStandFunc.Text = "Side Stand";
            this.checkBox_SideStandFunc.UseVisualStyleBackColor = true;
            // 
            // checkBox_CruiseFunc
            // 
            this.checkBox_CruiseFunc.AutoSize = true;
            this.checkBox_CruiseFunc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_CruiseFunc.Location = new System.Drawing.Point(10, 73);
            this.checkBox_CruiseFunc.Name = "checkBox_CruiseFunc";
            this.checkBox_CruiseFunc.Size = new System.Drawing.Size(67, 23);
            this.checkBox_CruiseFunc.TabIndex = 2;
            this.checkBox_CruiseFunc.Text = "Cruise";
            this.checkBox_CruiseFunc.UseVisualStyleBackColor = true;
            // 
            // checkBox_StartFunc
            // 
            this.checkBox_StartFunc.AutoSize = true;
            this.checkBox_StartFunc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_StartFunc.Location = new System.Drawing.Point(123, 42);
            this.checkBox_StartFunc.Name = "checkBox_StartFunc";
            this.checkBox_StartFunc.Size = new System.Drawing.Size(57, 23);
            this.checkBox_StartFunc.TabIndex = 1;
            this.checkBox_StartFunc.Text = "Start";
            this.checkBox_StartFunc.UseVisualStyleBackColor = true;
            // 
            // checkBox_KeyOnFunc
            // 
            this.checkBox_KeyOnFunc.AutoSize = true;
            this.checkBox_KeyOnFunc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_KeyOnFunc.Location = new System.Drawing.Point(10, 42);
            this.checkBox_KeyOnFunc.Name = "checkBox_KeyOnFunc";
            this.checkBox_KeyOnFunc.Size = new System.Drawing.Size(77, 23);
            this.checkBox_KeyOnFunc.TabIndex = 0;
            this.checkBox_KeyOnFunc.Text = "Key On";
            this.checkBox_KeyOnFunc.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.button_Reset);
            this.tabPage9.Controls.Add(this.button_Confirm);
            this.tabPage9.Controls.Add(this.checkBox_AngleWriteControl);
            this.tabPage9.Controls.Add(this.checkBox_DutyControl);
            this.tabPage9.Controls.Add(this.checkBox_PhaseCurControl);
            this.tabPage9.Controls.Add(this.checkBox_TPSControl);
            this.tabPage9.Controls.Add(this.button_EMS);
            this.tabPage9.Controls.Add(this.textBox_AngleWriteControl);
            this.tabPage9.Controls.Add(this.label_AngleWriteControl);
            this.tabPage9.Controls.Add(this.textBox_DutyControl);
            this.tabPage9.Controls.Add(this.label_DutyControl);
            this.tabPage9.Controls.Add(this.textBox_PhaseCurControl);
            this.tabPage9.Controls.Add(this.label_PhaseCurControl);
            this.tabPage9.Controls.Add(this.textBox_TPSControl);
            this.tabPage9.Controls.Add(this.label_TPSControl);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(794, 699);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "Control";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // button_Reset
            // 
            this.button_Reset.BackColor = System.Drawing.Color.SandyBrown;
            this.button_Reset.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Reset.Location = new System.Drawing.Point(253, 304);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(124, 52);
            this.button_Reset.TabIndex = 31;
            this.button_Reset.Text = "Reset";
            this.button_Reset.UseVisualStyleBackColor = false;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // button_Confirm
            // 
            this.button_Confirm.BackColor = System.Drawing.Color.Yellow;
            this.button_Confirm.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Confirm.Location = new System.Drawing.Point(402, 304);
            this.button_Confirm.Name = "button_Confirm";
            this.button_Confirm.Size = new System.Drawing.Size(124, 52);
            this.button_Confirm.TabIndex = 30;
            this.button_Confirm.Text = "Confirm";
            this.button_Confirm.UseVisualStyleBackColor = false;
            this.button_Confirm.Click += new System.EventHandler(this.button_Confirm_Click);
            // 
            // checkBox_AngleWriteControl
            // 
            this.checkBox_AngleWriteControl.AutoSize = true;
            this.checkBox_AngleWriteControl.Location = new System.Drawing.Point(313, 214);
            this.checkBox_AngleWriteControl.Name = "checkBox_AngleWriteControl";
            this.checkBox_AngleWriteControl.Size = new System.Drawing.Size(88, 16);
            this.checkBox_AngleWriteControl.TabIndex = 29;
            this.checkBox_AngleWriteControl.Text = "AngleWrite";
            this.checkBox_AngleWriteControl.UseVisualStyleBackColor = true;
            this.checkBox_AngleWriteControl.CheckedChanged += new System.EventHandler(this.checkBox_AngleWriteControl_CheckedChanged);
            // 
            // checkBox_DutyControl
            // 
            this.checkBox_DutyControl.AutoSize = true;
            this.checkBox_DutyControl.Location = new System.Drawing.Point(313, 157);
            this.checkBox_DutyControl.Name = "checkBox_DutyControl";
            this.checkBox_DutyControl.Size = new System.Drawing.Size(51, 16);
            this.checkBox_DutyControl.TabIndex = 28;
            this.checkBox_DutyControl.Text = "Duty";
            this.checkBox_DutyControl.UseVisualStyleBackColor = true;
            this.checkBox_DutyControl.CheckedChanged += new System.EventHandler(this.checkBox_DutyControl_CheckedChanged);
            // 
            // checkBox_PhaseCurControl
            // 
            this.checkBox_PhaseCurControl.AutoSize = true;
            this.checkBox_PhaseCurControl.Location = new System.Drawing.Point(313, 102);
            this.checkBox_PhaseCurControl.Name = "checkBox_PhaseCurControl";
            this.checkBox_PhaseCurControl.Size = new System.Drawing.Size(84, 16);
            this.checkBox_PhaseCurControl.TabIndex = 27;
            this.checkBox_PhaseCurControl.Text = "Phase Cur.";
            this.checkBox_PhaseCurControl.UseVisualStyleBackColor = true;
            this.checkBox_PhaseCurControl.CheckedChanged += new System.EventHandler(this.checkBox_PhaseCurControl_CheckedChanged);
            // 
            // checkBox_TPSControl
            // 
            this.checkBox_TPSControl.AutoSize = true;
            this.checkBox_TPSControl.Location = new System.Drawing.Point(313, 45);
            this.checkBox_TPSControl.Name = "checkBox_TPSControl";
            this.checkBox_TPSControl.Size = new System.Drawing.Size(106, 16);
            this.checkBox_TPSControl.TabIndex = 26;
            this.checkBox_TPSControl.Text = "TPSSimulation";
            this.checkBox_TPSControl.UseVisualStyleBackColor = true;
            this.checkBox_TPSControl.CheckedChanged += new System.EventHandler(this.checkBox_TPSControl_CheckedChanged);
            // 
            // button_EMS
            // 
            this.button_EMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.button_EMS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_EMS.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_EMS.ForeColor = System.Drawing.Color.White;
            this.button_EMS.Location = new System.Drawing.Point(24, 283);
            this.button_EMS.Name = "button_EMS";
            this.button_EMS.Size = new System.Drawing.Size(205, 92);
            this.button_EMS.TabIndex = 25;
            this.button_EMS.Text = "EmergencyStop";
            this.button_EMS.UseVisualStyleBackColor = false;
            this.button_EMS.Click += new System.EventHandler(this.button_EMS_Click);
            // 
            // textBox_AngleWriteControl
            // 
            this.textBox_AngleWriteControl.Location = new System.Drawing.Point(139, 211);
            this.textBox_AngleWriteControl.Name = "textBox_AngleWriteControl";
            this.textBox_AngleWriteControl.Size = new System.Drawing.Size(100, 22);
            this.textBox_AngleWriteControl.TabIndex = 24;
            // 
            // label_AngleWriteControl
            // 
            this.label_AngleWriteControl.AutoSize = true;
            this.label_AngleWriteControl.Location = new System.Drawing.Point(32, 214);
            this.label_AngleWriteControl.Name = "label_AngleWriteControl";
            this.label_AngleWriteControl.Size = new System.Drawing.Size(69, 12);
            this.label_AngleWriteControl.TabIndex = 23;
            this.label_AngleWriteControl.Text = "AngleWrite";
            // 
            // textBox_DutyControl
            // 
            this.textBox_DutyControl.Location = new System.Drawing.Point(139, 157);
            this.textBox_DutyControl.Name = "textBox_DutyControl";
            this.textBox_DutyControl.Size = new System.Drawing.Size(100, 22);
            this.textBox_DutyControl.TabIndex = 22;
            // 
            // label_DutyControl
            // 
            this.label_DutyControl.AutoSize = true;
            this.label_DutyControl.Location = new System.Drawing.Point(32, 160);
            this.label_DutyControl.Name = "label_DutyControl";
            this.label_DutyControl.Size = new System.Drawing.Size(32, 12);
            this.label_DutyControl.TabIndex = 21;
            this.label_DutyControl.Text = "Duty";
            // 
            // textBox_PhaseCurControl
            // 
            this.textBox_PhaseCurControl.Location = new System.Drawing.Point(139, 99);
            this.textBox_PhaseCurControl.Name = "textBox_PhaseCurControl";
            this.textBox_PhaseCurControl.Size = new System.Drawing.Size(100, 22);
            this.textBox_PhaseCurControl.TabIndex = 20;
            // 
            // label_PhaseCurControl
            // 
            this.label_PhaseCurControl.AutoSize = true;
            this.label_PhaseCurControl.Location = new System.Drawing.Point(32, 102);
            this.label_PhaseCurControl.Name = "label_PhaseCurControl";
            this.label_PhaseCurControl.Size = new System.Drawing.Size(65, 12);
            this.label_PhaseCurControl.TabIndex = 19;
            this.label_PhaseCurControl.Text = "Phase Cur.";
            // 
            // textBox_TPSControl
            // 
            this.textBox_TPSControl.Location = new System.Drawing.Point(139, 45);
            this.textBox_TPSControl.Name = "textBox_TPSControl";
            this.textBox_TPSControl.Size = new System.Drawing.Size(100, 22);
            this.textBox_TPSControl.TabIndex = 18;
            // 
            // label_TPSControl
            // 
            this.label_TPSControl.AutoSize = true;
            this.label_TPSControl.Location = new System.Drawing.Point(32, 48);
            this.label_TPSControl.Name = "label_TPSControl";
            this.label_TPSControl.Size = new System.Drawing.Size(87, 12);
            this.label_TPSControl.TabIndex = 17;
            this.label_TPSControl.Text = "TPSSimulation";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label_Series3);
            this.tabPage2.Controls.Add(this.label_Series3Value);
            this.tabPage2.Controls.Add(this.label_Series2);
            this.tabPage2.Controls.Add(this.label_Series2Value);
            this.tabPage2.Controls.Add(this.label_Series1);
            this.tabPage2.Controls.Add(this.label_Series1Value);
            this.tabPage2.Controls.Add(this.label_Series0);
            this.tabPage2.Controls.Add(this.label_Series0Value);
            this.tabPage2.Controls.Add(this.pictureBox4);
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.comboBox4);
            this.tabPage2.Controls.Add(this.comboBox3);
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(794, 699);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Diagnosis";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label_Series3
            // 
            this.label_Series3.AutoSize = true;
            this.label_Series3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Series3.Location = new System.Drawing.Point(616, 293);
            this.label_Series3.Name = "label_Series3";
            this.label_Series3.Size = new System.Drawing.Size(32, 15);
            this.label_Series3.TabIndex = 16;
            this.label_Series3.Text = "VDC";
            // 
            // label_Series3Value
            // 
            this.label_Series3Value.AutoSize = true;
            this.label_Series3Value.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Series3Value.Location = new System.Drawing.Point(711, 293);
            this.label_Series3Value.Name = "label_Series3Value";
            this.label_Series3Value.Size = new System.Drawing.Size(13, 15);
            this.label_Series3Value.TabIndex = 17;
            this.label_Series3Value.Text = "0";
            // 
            // label_Series2
            // 
            this.label_Series2.AutoSize = true;
            this.label_Series2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Series2.Location = new System.Drawing.Point(616, 269);
            this.label_Series2.Name = "label_Series2";
            this.label_Series2.Size = new System.Drawing.Size(32, 15);
            this.label_Series2.TabIndex = 14;
            this.label_Series2.Text = "VDC";
            // 
            // label_Series2Value
            // 
            this.label_Series2Value.AutoSize = true;
            this.label_Series2Value.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Series2Value.Location = new System.Drawing.Point(711, 269);
            this.label_Series2Value.Name = "label_Series2Value";
            this.label_Series2Value.Size = new System.Drawing.Size(13, 15);
            this.label_Series2Value.TabIndex = 15;
            this.label_Series2Value.Text = "0";
            // 
            // label_Series1
            // 
            this.label_Series1.AutoSize = true;
            this.label_Series1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Series1.Location = new System.Drawing.Point(616, 246);
            this.label_Series1.Name = "label_Series1";
            this.label_Series1.Size = new System.Drawing.Size(32, 15);
            this.label_Series1.TabIndex = 12;
            this.label_Series1.Text = "VDC";
            // 
            // label_Series1Value
            // 
            this.label_Series1Value.AutoSize = true;
            this.label_Series1Value.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Series1Value.Location = new System.Drawing.Point(711, 246);
            this.label_Series1Value.Name = "label_Series1Value";
            this.label_Series1Value.Size = new System.Drawing.Size(13, 15);
            this.label_Series1Value.TabIndex = 13;
            this.label_Series1Value.Text = "0";
            // 
            // label_Series0
            // 
            this.label_Series0.AutoSize = true;
            this.label_Series0.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Series0.Location = new System.Drawing.Point(616, 222);
            this.label_Series0.Name = "label_Series0";
            this.label_Series0.Size = new System.Drawing.Size(32, 15);
            this.label_Series0.TabIndex = 10;
            this.label_Series0.Text = "VDC";
            // 
            // label_Series0Value
            // 
            this.label_Series0Value.AutoSize = true;
            this.label_Series0Value.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Series0Value.Location = new System.Drawing.Point(711, 222);
            this.label_Series0Value.Name = "label_Series0Value";
            this.label_Series0Value.Size = new System.Drawing.Size(13, 15);
            this.label_Series0Value.TabIndex = 11;
            this.label_Series0Value.Text = "0";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(15, 237);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 29);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(15, 184);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 29);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(15, 126);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 29);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(15, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 29);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(57, 241);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(84, 20);
            this.comboBox4.TabIndex = 4;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(57, 188);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(84, 20);
            this.comboBox3.TabIndex = 3;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(57, 130);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(84, 20);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(57, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(84, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(147, 33);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series 0";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(629, 301);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox1);
            this.tabPage5.Controls.Add(this.groupBox6);
            this.tabPage5.Controls.Add(this.button_ClearAll);
            this.tabPage5.Controls.Add(this.groupBox3);
            this.tabPage5.Controls.Add(this.groupBox4);
            this.tabPage5.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(794, 699);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "CAN設定";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonConnect);
            this.groupBox6.Controls.Add(this.button_StartCAN);
            this.groupBox6.Controls.Add(this.button_StopCAN);
            this.groupBox6.Location = new System.Drawing.Point(469, 48);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(250, 48);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "啟動CAN";
            // 
            // button_ClearAll
            // 
            this.button_ClearAll.Location = new System.Drawing.Point(469, 258);
            this.button_ClearAll.Name = "button_ClearAll";
            this.button_ClearAll.Size = new System.Drawing.Size(75, 23);
            this.button_ClearAll.TabIndex = 11;
            this.button_ClearAll.Text = "清除信息";
            this.button_ClearAll.UseVisualStyleBackColor = true;
            this.button_ClearAll.Click += new System.EventHandler(this.button_ClearAll_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label_SlavePeriod);
            this.tabPage6.Controls.Add(this.button_ConfigConfirm);
            this.tabPage6.Controls.Add(this.textBox1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(794, 699);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Config";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label_SlavePeriod
            // 
            this.label_SlavePeriod.AutoSize = true;
            this.label_SlavePeriod.Location = new System.Drawing.Point(12, 43);
            this.label_SlavePeriod.Name = "label_SlavePeriod";
            this.label_SlavePeriod.Size = new System.Drawing.Size(105, 12);
            this.label_SlavePeriod.TabIndex = 35;
            this.label_SlavePeriod.Text = "label_SlavePeriod";
            // 
            // button_ConfigConfirm
            // 
            this.button_ConfigConfirm.Location = new System.Drawing.Point(564, 39);
            this.button_ConfigConfirm.Name = "button_ConfigConfirm";
            this.button_ConfigConfirm.Size = new System.Drawing.Size(100, 36);
            this.button_ConfigConfirm.TabIndex = 34;
            this.button_ConfigConfirm.Text = "ConfigConfirm";
            this.button_ConfigConfirm.UseVisualStyleBackColor = true;
            this.button_ConfigConfirm.Click += new System.EventHandler(this.button_ConfigConfirm_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 33;
            // 
            // simCanStop
            // 
            this.simCanStop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simCanStop.Location = new System.Drawing.Point(994, 34);
            this.simCanStop.Name = "simCanStop";
            this.simCanStop.Size = new System.Drawing.Size(118, 45);
            this.simCanStop.TabIndex = 19;
            this.simCanStop.Text = "simCanStop";
            this.simCanStop.UseVisualStyleBackColor = true;
            this.simCanStop.Click += new System.EventHandler(this.simCanStop_Click);
            // 
            // simCanStart
            // 
            this.simCanStart.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simCanStart.Location = new System.Drawing.Point(845, 34);
            this.simCanStart.Name = "simCanStart";
            this.simCanStart.Size = new System.Drawing.Size(118, 45);
            this.simCanStart.TabIndex = 18;
            this.simCanStart.Text = "simCanStart";
            this.simCanStart.UseVisualStyleBackColor = true;
            this.simCanStart.Click += new System.EventHandler(this.simCanStart_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(1351, 728);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(64, 12);
            this.labelVersion.TabIndex = 12;
            this.labelVersion.Text = "版號:Ver1.2";
            // 
            // groupBox_Parameters
            // 
            this.groupBox_Parameters.Controls.Add(this.label_TPSValue);
            this.groupBox_Parameters.Controls.Add(this.label_TPS);
            this.groupBox_Parameters.Controls.Add(this.label_MotorAngleValue);
            this.groupBox_Parameters.Controls.Add(this.label_MotorAngle);
            this.groupBox_Parameters.Controls.Add(this.label_MotorTempValue);
            this.groupBox_Parameters.Controls.Add(this.label_MotorTemp);
            this.groupBox_Parameters.Controls.Add(this.label_DriverTempValue);
            this.groupBox_Parameters.Controls.Add(this.label_DriverTemp);
            this.groupBox_Parameters.Controls.Add(this.label_SpeedValue);
            this.groupBox_Parameters.Controls.Add(this.label_Speed);
            this.groupBox_Parameters.Controls.Add(this.label_PhaseCurValue);
            this.groupBox_Parameters.Controls.Add(this.label_PhaseCur);
            this.groupBox_Parameters.Controls.Add(this.label_DcCurValue);
            this.groupBox_Parameters.Controls.Add(this.label_DcCur);
            this.groupBox_Parameters.Controls.Add(this.label_BusVolt);
            this.groupBox_Parameters.Controls.Add(this.label_BusVoltValue);
            this.groupBox_Parameters.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Parameters.Location = new System.Drawing.Point(845, 98);
            this.groupBox_Parameters.Name = "groupBox_Parameters";
            this.groupBox_Parameters.Size = new System.Drawing.Size(258, 387);
            this.groupBox_Parameters.TabIndex = 13;
            this.groupBox_Parameters.TabStop = false;
            this.groupBox_Parameters.Text = "Parameters";
            // 
            // label_TPSValue
            // 
            this.label_TPSValue.AutoSize = true;
            this.label_TPSValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TPSValue.Location = new System.Drawing.Point(134, 331);
            this.label_TPSValue.Name = "label_TPSValue";
            this.label_TPSValue.Size = new System.Drawing.Size(17, 19);
            this.label_TPSValue.TabIndex = 15;
            this.label_TPSValue.Text = "0";
            // 
            // label_TPS
            // 
            this.label_TPS.AutoSize = true;
            this.label_TPS.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TPS.Location = new System.Drawing.Point(6, 331);
            this.label_TPS.Name = "label_TPS";
            this.label_TPS.Size = new System.Drawing.Size(64, 19);
            this.label_TPS.TabIndex = 14;
            this.label_TPS.Text = "TPS (V):";
            // 
            // label_MotorAngleValue
            // 
            this.label_MotorAngleValue.AutoSize = true;
            this.label_MotorAngleValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MotorAngleValue.Location = new System.Drawing.Point(134, 251);
            this.label_MotorAngleValue.Name = "label_MotorAngleValue";
            this.label_MotorAngleValue.Size = new System.Drawing.Size(17, 19);
            this.label_MotorAngleValue.TabIndex = 13;
            this.label_MotorAngleValue.Text = "0";
            // 
            // label_MotorAngle
            // 
            this.label_MotorAngle.AutoSize = true;
            this.label_MotorAngle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MotorAngle.Location = new System.Drawing.Point(6, 251);
            this.label_MotorAngle.Name = "label_MotorAngle";
            this.label_MotorAngle.Size = new System.Drawing.Size(89, 19);
            this.label_MotorAngle.TabIndex = 12;
            this.label_MotorAngle.Text = "Motor Angle:";
            // 
            // label_MotorTempValue
            // 
            this.label_MotorTempValue.AutoSize = true;
            this.label_MotorTempValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MotorTempValue.Location = new System.Drawing.Point(134, 209);
            this.label_MotorTempValue.Name = "label_MotorTempValue";
            this.label_MotorTempValue.Size = new System.Drawing.Size(17, 19);
            this.label_MotorTempValue.TabIndex = 11;
            this.label_MotorTempValue.Text = "0";
            // 
            // label_MotorTemp
            // 
            this.label_MotorTemp.AutoSize = true;
            this.label_MotorTemp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MotorTemp.Location = new System.Drawing.Point(6, 209);
            this.label_MotorTemp.Name = "label_MotorTemp";
            this.label_MotorTemp.Size = new System.Drawing.Size(93, 19);
            this.label_MotorTemp.TabIndex = 10;
            this.label_MotorTemp.Text = "Motor Temp.:";
            // 
            // label_DriverTempValue
            // 
            this.label_DriverTempValue.AutoSize = true;
            this.label_DriverTempValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DriverTempValue.Location = new System.Drawing.Point(134, 169);
            this.label_DriverTempValue.Name = "label_DriverTempValue";
            this.label_DriverTempValue.Size = new System.Drawing.Size(17, 19);
            this.label_DriverTempValue.TabIndex = 9;
            this.label_DriverTempValue.Text = "0";
            // 
            // label_DriverTemp
            // 
            this.label_DriverTemp.AutoSize = true;
            this.label_DriverTemp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DriverTemp.Location = new System.Drawing.Point(6, 169);
            this.label_DriverTemp.Name = "label_DriverTemp";
            this.label_DriverTemp.Size = new System.Drawing.Size(92, 19);
            this.label_DriverTemp.TabIndex = 8;
            this.label_DriverTemp.Text = "Driver Temp.:";
            // 
            // label_SpeedValue
            // 
            this.label_SpeedValue.AutoSize = true;
            this.label_SpeedValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SpeedValue.Location = new System.Drawing.Point(134, 133);
            this.label_SpeedValue.Name = "label_SpeedValue";
            this.label_SpeedValue.Size = new System.Drawing.Size(17, 19);
            this.label_SpeedValue.TabIndex = 7;
            this.label_SpeedValue.Text = "0";
            // 
            // label_Speed
            // 
            this.label_Speed.AutoSize = true;
            this.label_Speed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Speed.Location = new System.Drawing.Point(6, 129);
            this.label_Speed.Name = "label_Speed";
            this.label_Speed.Size = new System.Drawing.Size(98, 19);
            this.label_Speed.TabIndex = 6;
            this.label_Speed.Text = "Speed (RPM):";
            // 
            // label_PhaseCurValue
            // 
            this.label_PhaseCurValue.AutoSize = true;
            this.label_PhaseCurValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PhaseCurValue.Location = new System.Drawing.Point(134, 89);
            this.label_PhaseCurValue.Name = "label_PhaseCurValue";
            this.label_PhaseCurValue.Size = new System.Drawing.Size(17, 19);
            this.label_PhaseCurValue.TabIndex = 5;
            this.label_PhaseCurValue.Text = "0";
            // 
            // label_PhaseCur
            // 
            this.label_PhaseCur.AutoSize = true;
            this.label_PhaseCur.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PhaseCur.Location = new System.Drawing.Point(6, 89);
            this.label_PhaseCur.Name = "label_PhaseCur";
            this.label_PhaseCur.Size = new System.Drawing.Size(103, 19);
            this.label_PhaseCur.TabIndex = 4;
            this.label_PhaseCur.Text = "Phase Cur. (A):";
            // 
            // label_DcCurValue
            // 
            this.label_DcCurValue.AutoSize = true;
            this.label_DcCurValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DcCurValue.Location = new System.Drawing.Point(134, 291);
            this.label_DcCurValue.Name = "label_DcCurValue";
            this.label_DcCurValue.Size = new System.Drawing.Size(17, 19);
            this.label_DcCurValue.TabIndex = 3;
            this.label_DcCurValue.Text = "0";
            // 
            // label_DcCur
            // 
            this.label_DcCur.AutoSize = true;
            this.label_DcCur.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DcCur.Location = new System.Drawing.Point(6, 291);
            this.label_DcCur.Name = "label_DcCur";
            this.label_DcCur.Size = new System.Drawing.Size(85, 19);
            this.label_DcCur.TabIndex = 2;
            this.label_DcCur.Text = "Dc Cur. (A):";
            // 
            // label_BusVolt
            // 
            this.label_BusVolt.AutoSize = true;
            this.label_BusVolt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_BusVolt.Location = new System.Drawing.Point(6, 48);
            this.label_BusVolt.Name = "label_BusVolt";
            this.label_BusVolt.Size = new System.Drawing.Size(92, 19);
            this.label_BusVolt.TabIndex = 0;
            this.label_BusVolt.Text = "Bus Volt. (V):";
            // 
            // label_BusVoltValue
            // 
            this.label_BusVoltValue.AutoSize = true;
            this.label_BusVoltValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_BusVoltValue.Location = new System.Drawing.Point(134, 48);
            this.label_BusVoltValue.Name = "label_BusVoltValue";
            this.label_BusVoltValue.Size = new System.Drawing.Size(17, 19);
            this.label_BusVoltValue.TabIndex = 1;
            this.label_BusVoltValue.Text = "0";
            // 
            // groupBox_Status
            // 
            this.groupBox_Status.Controls.Add(this.label_CANConnectValue);
            this.groupBox_Status.Controls.Add(this.label_CANConnect);
            this.groupBox_Status.Controls.Add(this.label_CANStatusValue);
            this.groupBox_Status.Controls.Add(this.label_CANStatus);
            this.groupBox_Status.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Status.Location = new System.Drawing.Point(845, 495);
            this.groupBox_Status.Name = "groupBox_Status";
            this.groupBox_Status.Size = new System.Drawing.Size(258, 130);
            this.groupBox_Status.TabIndex = 14;
            this.groupBox_Status.TabStop = false;
            this.groupBox_Status.Text = "Status";
            // 
            // label_CANConnectValue
            // 
            this.label_CANConnectValue.AutoSize = true;
            this.label_CANConnectValue.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CANConnectValue.Location = new System.Drawing.Point(134, 86);
            this.label_CANConnectValue.Name = "label_CANConnectValue";
            this.label_CANConnectValue.Size = new System.Drawing.Size(28, 25);
            this.label_CANConnectValue.TabIndex = 13;
            this.label_CANConnectValue.Text = "✖";
            // 
            // label_CANConnect
            // 
            this.label_CANConnect.AutoSize = true;
            this.label_CANConnect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CANConnect.Location = new System.Drawing.Point(6, 86);
            this.label_CANConnect.Name = "label_CANConnect";
            this.label_CANConnect.Size = new System.Drawing.Size(94, 19);
            this.label_CANConnect.TabIndex = 14;
            this.label_CANConnect.Text = "CANConnect";
            // 
            // label_CANStatusValue
            // 
            this.label_CANStatusValue.AutoSize = true;
            this.label_CANStatusValue.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CANStatusValue.Location = new System.Drawing.Point(134, 46);
            this.label_CANStatusValue.Name = "label_CANStatusValue";
            this.label_CANStatusValue.Size = new System.Drawing.Size(28, 25);
            this.label_CANStatusValue.TabIndex = 11;
            this.label_CANStatusValue.Text = "✖";
            // 
            // label_CANStatus
            // 
            this.label_CANStatus.AutoSize = true;
            this.label_CANStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CANStatus.Location = new System.Drawing.Point(6, 46);
            this.label_CANStatus.Name = "label_CANStatus";
            this.label_CANStatus.Size = new System.Drawing.Size(80, 19);
            this.label_CANStatus.TabIndex = 12;
            this.label_CANStatus.Text = "CANStauts";
            // 
            // groupBox_Error
            // 
            this.groupBox_Error.Controls.Add(this.label_HighSpeedErr);
            this.groupBox_Error.Controls.Add(this.label_OTPDriverErr);
            this.groupBox_Error.Controls.Add(this.label_TPSHighErr);
            this.groupBox_Error.Controls.Add(this.label_DcOCPErr);
            this.groupBox_Error.Controls.Add(this.label_OTPMotorErr);
            this.groupBox_Error.Controls.Add(this.label_UVPErr);
            this.groupBox_Error.Controls.Add(this.label_OVPErr);
            this.groupBox_Error.Controls.Add(this.label_PhaseOCPErr);
            this.groupBox_Error.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Error.Location = new System.Drawing.Point(1138, 99);
            this.groupBox_Error.Name = "groupBox_Error";
            this.groupBox_Error.Size = new System.Drawing.Size(236, 179);
            this.groupBox_Error.TabIndex = 15;
            this.groupBox_Error.TabStop = false;
            this.groupBox_Error.Text = "Error";
            // 
            // label_HighSpeedErr
            // 
            this.label_HighSpeedErr.AutoSize = true;
            this.label_HighSpeedErr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_HighSpeedErr.Location = new System.Drawing.Point(113, 138);
            this.label_HighSpeedErr.Name = "label_HighSpeedErr";
            this.label_HighSpeedErr.Size = new System.Drawing.Size(15, 19);
            this.label_HighSpeedErr.TabIndex = 28;
            this.label_HighSpeedErr.Text = "-";
            // 
            // label_OTPDriverErr
            // 
            this.label_OTPDriverErr.AutoSize = true;
            this.label_OTPDriverErr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_OTPDriverErr.Location = new System.Drawing.Point(113, 99);
            this.label_OTPDriverErr.Name = "label_OTPDriverErr";
            this.label_OTPDriverErr.Size = new System.Drawing.Size(15, 19);
            this.label_OTPDriverErr.TabIndex = 27;
            this.label_OTPDriverErr.Text = "-";
            // 
            // label_TPSHighErr
            // 
            this.label_TPSHighErr.AutoSize = true;
            this.label_TPSHighErr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TPSHighErr.Location = new System.Drawing.Point(21, 138);
            this.label_TPSHighErr.Name = "label_TPSHighErr";
            this.label_TPSHighErr.Size = new System.Drawing.Size(15, 19);
            this.label_TPSHighErr.TabIndex = 26;
            this.label_TPSHighErr.Text = "-";
            // 
            // label_DcOCPErr
            // 
            this.label_DcOCPErr.AutoSize = true;
            this.label_DcOCPErr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DcOCPErr.Location = new System.Drawing.Point(113, 64);
            this.label_DcOCPErr.Name = "label_DcOCPErr";
            this.label_DcOCPErr.Size = new System.Drawing.Size(15, 19);
            this.label_DcOCPErr.TabIndex = 24;
            this.label_DcOCPErr.Text = "-";
            // 
            // label_OTPMotorErr
            // 
            this.label_OTPMotorErr.AutoSize = true;
            this.label_OTPMotorErr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_OTPMotorErr.Location = new System.Drawing.Point(21, 99);
            this.label_OTPMotorErr.Name = "label_OTPMotorErr";
            this.label_OTPMotorErr.Size = new System.Drawing.Size(15, 19);
            this.label_OTPMotorErr.TabIndex = 22;
            this.label_OTPMotorErr.Text = "-";
            // 
            // label_UVPErr
            // 
            this.label_UVPErr.AutoSize = true;
            this.label_UVPErr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_UVPErr.Location = new System.Drawing.Point(21, 64);
            this.label_UVPErr.Name = "label_UVPErr";
            this.label_UVPErr.Size = new System.Drawing.Size(15, 19);
            this.label_UVPErr.TabIndex = 20;
            this.label_UVPErr.Text = "-";
            // 
            // label_OVPErr
            // 
            this.label_OVPErr.AutoSize = true;
            this.label_OVPErr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_OVPErr.Location = new System.Drawing.Point(113, 31);
            this.label_OVPErr.Name = "label_OVPErr";
            this.label_OVPErr.Size = new System.Drawing.Size(15, 19);
            this.label_OVPErr.TabIndex = 18;
            this.label_OVPErr.Text = "-";
            // 
            // label_PhaseOCPErr
            // 
            this.label_PhaseOCPErr.AutoSize = true;
            this.label_PhaseOCPErr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PhaseOCPErr.Location = new System.Drawing.Point(21, 31);
            this.label_PhaseOCPErr.Name = "label_PhaseOCPErr";
            this.label_PhaseOCPErr.Size = new System.Drawing.Size(15, 19);
            this.label_PhaseOCPErr.TabIndex = 16;
            this.label_PhaseOCPErr.Text = "-";
            // 
            // groupBox_Alarm
            // 
            this.groupBox_Alarm.Controls.Add(this.label_HighCurAlarm);
            this.groupBox_Alarm.Controls.Add(this.label_LowTempDriverAlarm);
            this.groupBox_Alarm.Controls.Add(this.label_HighTempDriverAlarm);
            this.groupBox_Alarm.Controls.Add(this.label_DeratingAlarm);
            this.groupBox_Alarm.Controls.Add(this.label_LowTempMotorAlarm);
            this.groupBox_Alarm.Controls.Add(this.label_LowVoltAlarm);
            this.groupBox_Alarm.Controls.Add(this.label_HighSpeedAlarm);
            this.groupBox_Alarm.Controls.Add(this.label_HighTempMotorAlarm);
            this.groupBox_Alarm.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Alarm.Location = new System.Drawing.Point(1138, 306);
            this.groupBox_Alarm.Name = "groupBox_Alarm";
            this.groupBox_Alarm.Size = new System.Drawing.Size(236, 179);
            this.groupBox_Alarm.TabIndex = 16;
            this.groupBox_Alarm.TabStop = false;
            this.groupBox_Alarm.Text = "Alarm";
            // 
            // label_HighCurAlarm
            // 
            this.label_HighCurAlarm.AutoSize = true;
            this.label_HighCurAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_HighCurAlarm.Location = new System.Drawing.Point(112, 35);
            this.label_HighCurAlarm.Name = "label_HighCurAlarm";
            this.label_HighCurAlarm.Size = new System.Drawing.Size(15, 19);
            this.label_HighCurAlarm.TabIndex = 39;
            this.label_HighCurAlarm.Text = "-";
            // 
            // label_LowTempDriverAlarm
            // 
            this.label_LowTempDriverAlarm.AutoSize = true;
            this.label_LowTempDriverAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LowTempDriverAlarm.Location = new System.Drawing.Point(112, 70);
            this.label_LowTempDriverAlarm.Name = "label_LowTempDriverAlarm";
            this.label_LowTempDriverAlarm.Size = new System.Drawing.Size(15, 19);
            this.label_LowTempDriverAlarm.TabIndex = 38;
            this.label_LowTempDriverAlarm.Text = "-";
            // 
            // label_HighTempDriverAlarm
            // 
            this.label_HighTempDriverAlarm.AutoSize = true;
            this.label_HighTempDriverAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_HighTempDriverAlarm.Location = new System.Drawing.Point(112, 106);
            this.label_HighTempDriverAlarm.Name = "label_HighTempDriverAlarm";
            this.label_HighTempDriverAlarm.Size = new System.Drawing.Size(15, 19);
            this.label_HighTempDriverAlarm.TabIndex = 37;
            this.label_HighTempDriverAlarm.Text = "-";
            // 
            // label_DeratingAlarm
            // 
            this.label_DeratingAlarm.AutoSize = true;
            this.label_DeratingAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DeratingAlarm.Location = new System.Drawing.Point(21, 140);
            this.label_DeratingAlarm.Name = "label_DeratingAlarm";
            this.label_DeratingAlarm.Size = new System.Drawing.Size(15, 19);
            this.label_DeratingAlarm.TabIndex = 36;
            this.label_DeratingAlarm.Text = "-";
            // 
            // label_LowTempMotorAlarm
            // 
            this.label_LowTempMotorAlarm.AutoSize = true;
            this.label_LowTempMotorAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LowTempMotorAlarm.Location = new System.Drawing.Point(21, 70);
            this.label_LowTempMotorAlarm.Name = "label_LowTempMotorAlarm";
            this.label_LowTempMotorAlarm.Size = new System.Drawing.Size(15, 19);
            this.label_LowTempMotorAlarm.TabIndex = 30;
            this.label_LowTempMotorAlarm.Text = "-";
            // 
            // label_LowVoltAlarm
            // 
            this.label_LowVoltAlarm.AutoSize = true;
            this.label_LowVoltAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LowVoltAlarm.Location = new System.Drawing.Point(21, 35);
            this.label_LowVoltAlarm.Name = "label_LowVoltAlarm";
            this.label_LowVoltAlarm.Size = new System.Drawing.Size(15, 19);
            this.label_LowVoltAlarm.TabIndex = 28;
            this.label_LowVoltAlarm.Text = "-";
            // 
            // label_HighSpeedAlarm
            // 
            this.label_HighSpeedAlarm.AutoSize = true;
            this.label_HighSpeedAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_HighSpeedAlarm.Location = new System.Drawing.Point(112, 140);
            this.label_HighSpeedAlarm.Name = "label_HighSpeedAlarm";
            this.label_HighSpeedAlarm.Size = new System.Drawing.Size(15, 19);
            this.label_HighSpeedAlarm.TabIndex = 34;
            this.label_HighSpeedAlarm.Text = "-";
            // 
            // label_HighTempMotorAlarm
            // 
            this.label_HighTempMotorAlarm.AutoSize = true;
            this.label_HighTempMotorAlarm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_HighTempMotorAlarm.Location = new System.Drawing.Point(21, 106);
            this.label_HighTempMotorAlarm.Name = "label_HighTempMotorAlarm";
            this.label_HighTempMotorAlarm.Size = new System.Drawing.Size(15, 19);
            this.label_HighTempMotorAlarm.TabIndex = 32;
            this.label_HighTempMotorAlarm.Text = "-";
            // 
            // groupBox_Flag
            // 
            this.groupBox_Flag.Controls.Add(this.label_Restart);
            this.groupBox_Flag.Controls.Add(this.label_RestartValue);
            this.groupBox_Flag.Controls.Add(this.label_ProtectActivation);
            this.groupBox_Flag.Controls.Add(this.label_ProtectActivationValue);
            this.groupBox_Flag.Controls.Add(this.label_SideStand);
            this.groupBox_Flag.Controls.Add(this.label_SideStandValue);
            this.groupBox_Flag.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Flag.Location = new System.Drawing.Point(1138, 496);
            this.groupBox_Flag.Name = "groupBox_Flag";
            this.groupBox_Flag.Size = new System.Drawing.Size(250, 223);
            this.groupBox_Flag.TabIndex = 17;
            this.groupBox_Flag.TabStop = false;
            this.groupBox_Flag.Text = "Flag";
            // 
            // label_Restart
            // 
            this.label_Restart.AutoSize = true;
            this.label_Restart.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Restart.Location = new System.Drawing.Point(6, 110);
            this.label_Restart.Name = "label_Restart";
            this.label_Restart.Size = new System.Drawing.Size(52, 19);
            this.label_Restart.TabIndex = 42;
            this.label_Restart.Text = "Restart";
            // 
            // label_RestartValue
            // 
            this.label_RestartValue.AutoSize = true;
            this.label_RestartValue.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RestartValue.Location = new System.Drawing.Point(127, 110);
            this.label_RestartValue.Name = "label_RestartValue";
            this.label_RestartValue.Size = new System.Drawing.Size(28, 25);
            this.label_RestartValue.TabIndex = 41;
            this.label_RestartValue.Text = "✖";
            // 
            // label_ProtectActivation
            // 
            this.label_ProtectActivation.AutoSize = true;
            this.label_ProtectActivation.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ProtectActivation.Location = new System.Drawing.Point(6, 73);
            this.label_ProtectActivation.Name = "label_ProtectActivation";
            this.label_ProtectActivation.Size = new System.Drawing.Size(117, 19);
            this.label_ProtectActivation.TabIndex = 40;
            this.label_ProtectActivation.Text = "Protect Activation";
            // 
            // label_ProtectActivationValue
            // 
            this.label_ProtectActivationValue.AutoSize = true;
            this.label_ProtectActivationValue.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ProtectActivationValue.Location = new System.Drawing.Point(127, 73);
            this.label_ProtectActivationValue.Name = "label_ProtectActivationValue";
            this.label_ProtectActivationValue.Size = new System.Drawing.Size(28, 25);
            this.label_ProtectActivationValue.TabIndex = 39;
            this.label_ProtectActivationValue.Text = "✖";
            // 
            // label_SideStand
            // 
            this.label_SideStand.AutoSize = true;
            this.label_SideStand.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SideStand.Location = new System.Drawing.Point(6, 37);
            this.label_SideStand.Name = "label_SideStand";
            this.label_SideStand.Size = new System.Drawing.Size(75, 19);
            this.label_SideStand.TabIndex = 38;
            this.label_SideStand.Text = "Side Stand";
            // 
            // label_SideStandValue
            // 
            this.label_SideStandValue.AutoSize = true;
            this.label_SideStandValue.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SideStandValue.Location = new System.Drawing.Point(127, 37);
            this.label_SideStandValue.Name = "label_SideStandValue";
            this.label_SideStandValue.Size = new System.Drawing.Size(28, 25);
            this.label_SideStandValue.TabIndex = 37;
            this.label_SideStandValue.Text = "✖";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 749);
            this.Controls.Add(this.simCanStop);
            this.Controls.Add(this.groupBox_Flag);
            this.Controls.Add(this.simCanStart);
            this.Controls.Add(this.groupBox_Alarm);
            this.Controls.Add(this.groupBox_Error);
            this.Controls.Add(this.groupBox_Status);
            this.Controls.Add(this.groupBox_Parameters);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "模擬馬達FOC軟體";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox_GainSet.ResumeLayout(false);
            this.groupBox_GainSet.PerformLayout();
            this.groupBox_SettingAlarm.ResumeLayout(false);
            this.groupBox_SettingAlarm.PerformLayout();
            this.groupBox_Protection.ResumeLayout(false);
            this.groupBox_Protection.PerformLayout();
            this.groupBox_Function.ResumeLayout(false);
            this.groupBox_Function.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.groupBox_Parameters.ResumeLayout(false);
            this.groupBox_Parameters.PerformLayout();
            this.groupBox_Status.ResumeLayout(false);
            this.groupBox_Status.PerformLayout();
            this.groupBox_Error.ResumeLayout(false);
            this.groupBox_Error.PerformLayout();
            this.groupBox_Alarm.ResumeLayout(false);
            this.groupBox_Alarm.PerformLayout();
            this.groupBox_Flag.ResumeLayout(false);
            this.groupBox_Flag.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ComboBox comboBox_CANIndex;
        private System.Windows.Forms.ComboBox comboBox_DevIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Time1;
        private System.Windows.Forms.TextBox textBox_AccMask;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Time0;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_AccCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Mode;
        private System.Windows.Forms.ComboBox comboBox_Filter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_StartCAN;
        private System.Windows.Forms.Button button_StopCAN;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox_FrameFormat;
        private System.Windows.Forms.ComboBox comboBox_FrameType;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_SendType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_Data;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBox_Info;
        private System.Windows.Forms.Timer timer_rec;
        private System.Windows.Forms.ComboBox comboBox_devtype;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox_BaudRate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button_ClearAll;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.GroupBox groupBox_Parameters;
        private System.Windows.Forms.Label label_DriverTempValue;
        private System.Windows.Forms.Label label_DriverTemp;
        private System.Windows.Forms.Label label_SpeedValue;
        private System.Windows.Forms.Label label_Speed;
        private System.Windows.Forms.Label label_PhaseCurValue;
        private System.Windows.Forms.Label label_PhaseCur;
        private System.Windows.Forms.Label label_DcCurValue;
        private System.Windows.Forms.Label label_DcCur;
        private System.Windows.Forms.Label label_BusVoltValue;
        private System.Windows.Forms.Label label_BusVolt;
        private System.Windows.Forms.GroupBox groupBox_Status;
        private System.Windows.Forms.GroupBox groupBox_Error;
        private System.Windows.Forms.GroupBox groupBox_Alarm;
        private System.Windows.Forms.GroupBox groupBox_Flag;
        private System.Windows.Forms.Label label_CANConnectValue;
        private System.Windows.Forms.Label label_CANConnect;
        private System.Windows.Forms.Label label_CANStatusValue;
        private System.Windows.Forms.Label label_CANStatus;
        private System.Windows.Forms.Label label_TPSHighErr;
        private System.Windows.Forms.Label label_DcOCPErr;
        private System.Windows.Forms.Label label_OTPMotorErr;
        private System.Windows.Forms.Label label_UVPErr;
        private System.Windows.Forms.Label label_OVPErr;
        private System.Windows.Forms.Label label_PhaseOCPErr;
        private System.Windows.Forms.Label label_LowVoltAlarm;
        private System.Windows.Forms.Label label_DeratingAlarm;
        private System.Windows.Forms.Label label_LowTempMotorAlarm;
        private System.Windows.Forms.Label label_HighSpeedAlarm;
        private System.Windows.Forms.Label label_HighTempMotorAlarm;
        private System.Windows.Forms.Label label_SideStand;
        private System.Windows.Forms.Label label_SideStandValue;
        private System.Windows.Forms.CheckBox checkBox_KeyOnFunc;
        private System.Windows.Forms.Label label_PISet;
        private System.Windows.Forms.Label label_DriverTempSet;
        private System.Windows.Forms.Label label_PhaseCurSet;
        private System.Windows.Forms.Label label_BusVoltSet;
        private System.Windows.Forms.Label label_TPSSet;
        private System.Windows.Forms.TextBox textBox_PISetValue;
        private System.Windows.Forms.TextBox textBox_DriverTempSetValue;
        private System.Windows.Forms.TextBox textBox_PhaseCurSetValue;
        private System.Windows.Forms.TextBox textBox_BusVoltSetValue;
        private System.Windows.Forms.TextBox textBox_TPSSetValue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox_SettingAlarm;
        private System.Windows.Forms.GroupBox groupBox_Protection;
        private System.Windows.Forms.CheckBox checkBox_OTPDriverProtect;
        private System.Windows.Forms.CheckBox checkBox_DcOCPProtect;
        private System.Windows.Forms.CheckBox checkBox_OTPMoterProtect;
        private System.Windows.Forms.CheckBox checkBox_UVPProtect;
        private System.Windows.Forms.CheckBox checkBox_OVPProtect;
        private System.Windows.Forms.CheckBox checkBox_PhaseOCPProtect;
        private System.Windows.Forms.GroupBox groupBox_Function;
        private System.Windows.Forms.CheckBox checkBox_HighBrakeFunc;
        private System.Windows.Forms.CheckBox checkBox_LowBrakeFunc;
        private System.Windows.Forms.CheckBox checkBox_SideStandFunc;
        private System.Windows.Forms.CheckBox checkBox_CruiseFunc;
        private System.Windows.Forms.CheckBox checkBox_StartFunc;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label_Series3;
        private System.Windows.Forms.Label label_Series3Value;
        private System.Windows.Forms.Label label_Series2;
        private System.Windows.Forms.Label label_Series2Value;
        private System.Windows.Forms.Label label_Series1;
        private System.Windows.Forms.Label label_Series1Value;
        private System.Windows.Forms.Label label_Series0;
        private System.Windows.Forms.Label label_Series0Value;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button button_ConfigConfirm;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_SlavePeriod;
        private System.Windows.Forms.Button simCanStart;
        private System.Windows.Forms.Label label_MotorTempValue;
        private System.Windows.Forms.Label label_MotorTemp;
        private System.Windows.Forms.Label label_MotorAngleValue;
        private System.Windows.Forms.Label label_MotorAngle;
        private System.Windows.Forms.Label label_HighTempDriverAlarm;
        private System.Windows.Forms.Label label_LowTempDriverAlarm;
        private System.Windows.Forms.Label label_OTPDriverErr;
        private System.Windows.Forms.TextBox textBox_MotorTempSetValue;
        private System.Windows.Forms.Label label_MotorTempSet;
        private System.Windows.Forms.Button simCanStop;
        private System.Windows.Forms.GroupBox groupBox_GainSet;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Button button_Confirm;
        private System.Windows.Forms.CheckBox checkBox_AngleWriteControl;
        private System.Windows.Forms.CheckBox checkBox_DutyControl;
        private System.Windows.Forms.CheckBox checkBox_PhaseCurControl;
        private System.Windows.Forms.CheckBox checkBox_TPSControl;
        private System.Windows.Forms.Button button_EMS;
        private System.Windows.Forms.TextBox textBox_AngleWriteControl;
        private System.Windows.Forms.Label label_AngleWriteControl;
        private System.Windows.Forms.TextBox textBox_DutyControl;
        private System.Windows.Forms.Label label_DutyControl;
        private System.Windows.Forms.TextBox textBox_PhaseCurControl;
        private System.Windows.Forms.Label label_PhaseCurControl;
        private System.Windows.Forms.TextBox textBox_TPSControl;
        private System.Windows.Forms.Label label_TPSControl;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.CheckBox checkBox_HighSpeedProtect;
        private System.Windows.Forms.CheckBox checkBox_TPSHighProtect;
        private System.Windows.Forms.Label label_HighSpeedErr;
        private System.Windows.Forms.Label label_HighCurAlarm;
        private System.Windows.Forms.CheckBox checkBox_ParkFunc;
        private System.Windows.Forms.CheckBox checkBox_BoostFunc;
        private System.Windows.Forms.Label label_TPSValue;
        private System.Windows.Forms.Label label_TPS;
        private System.Windows.Forms.CheckBox checkBox_HighSpeedAlarm;
        private System.Windows.Forms.CheckBox checkBox_LowVoltAlarm;
        private System.Windows.Forms.CheckBox checkBox_DeratingAlarm;
        private System.Windows.Forms.CheckBox checkBox_HighCurAlarm;
        private System.Windows.Forms.CheckBox checkBox_HighTempDriverAlarm;
        private System.Windows.Forms.CheckBox checkBox_LowTempMotorAlarm;
        private System.Windows.Forms.CheckBox checkBox_LowTempDriverAlarm;
        private System.Windows.Forms.CheckBox checkBox_HighTempMotorAlarm;
        private System.Windows.Forms.Label label_Restart;
        private System.Windows.Forms.Label label_RestartValue;
        private System.Windows.Forms.Label label_ProtectActivation;
        private System.Windows.Forms.Label label_ProtectActivationValue;
        private System.Windows.Forms.Button button_SettingDisableProtection;
        private System.Windows.Forms.Button button_SettingRestartMotor;
        private System.Windows.Forms.Button button_SettingDisableAlarm;
        private System.Windows.Forms.Button button_SettingStartMotor;
    }
}

