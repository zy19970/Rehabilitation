namespace Rehabilitation
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AngleChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.M8128Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.PreReadyBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.HDT串口 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ledMCU = new LED.LED();
            this.SerialDisconnectBtn = new System.Windows.Forms.Button();
            this.SerialConnectBtn = new System.Windows.Forms.Button();
            this.SerialScanBtn = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboM8128Baud = new System.Windows.Forms.ComboBox();
            this.comboM8128Com = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboMCUBaud = new System.Windows.Forms.ComboBox();
            this.comboMCUCom = new System.Windows.Forms.ComboBox();
            this.ledHDT = new LED.LED();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.SerialScanTimer = new System.Windows.Forms.Timer(this.components);
            this.ChartFTTimer = new System.Windows.Forms.Timer(this.components);
            this.PreReadyLed = new LED.LED();
            this.StartLed = new LED.LED();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ChartAngleTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AngleChart)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M8128Chart)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AngleChart);
            this.groupBox1.Location = new System.Drawing.Point(533, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 344);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "实时角度数据";
            // 
            // AngleChart
            // 
            chartArea1.Name = "ChartArea1";
            this.AngleChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.AngleChart.Legends.Add(legend1);
            this.AngleChart.Location = new System.Drawing.Point(6, 20);
            this.AngleChart.Name = "AngleChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.AngleChart.Series.Add(series1);
            this.AngleChart.Size = new System.Drawing.Size(608, 318);
            this.AngleChart.TabIndex = 0;
            this.AngleChart.Text = "chart1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.M8128Chart);
            this.groupBox2.Location = new System.Drawing.Point(533, 362);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(620, 344);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "实时六维数据";
            // 
            // M8128Chart
            // 
            chartArea2.Name = "ChartArea1";
            this.M8128Chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.M8128Chart.Legends.Add(legend2);
            this.M8128Chart.Location = new System.Drawing.Point(6, 20);
            this.M8128Chart.Name = "M8128Chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.M8128Chart.Series.Add(series2);
            this.M8128Chart.Size = new System.Drawing.Size(608, 318);
            this.M8128Chart.TabIndex = 0;
            this.M8128Chart.Text = "chart2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.StartLed);
            this.groupBox3.Controls.Add(this.PreReadyLed);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(515, 318);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "参数配置";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 336);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(515, 370);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(507, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "系统配置";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button13);
            this.groupBox8.Controls.Add(this.button14);
            this.groupBox8.Controls.Add(this.button11);
            this.groupBox8.Controls.Add(this.button12);
            this.groupBox8.Controls.Add(this.button10);
            this.groupBox8.Controls.Add(this.button9);
            this.groupBox8.Controls.Add(this.button8);
            this.groupBox8.Controls.Add(this.button7);
            this.groupBox8.Location = new System.Drawing.Point(249, 182);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(252, 156);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "手动调整";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(132, 113);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 7;
            this.button13.Text = "跖屈";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(40, 113);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 6;
            this.button14.Text = "背伸";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(132, 84);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 5;
            this.button11.Text = "外展";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(40, 84);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 4;
            this.button12.Text = "内收";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(132, 55);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 3;
            this.button10.Text = "外翻";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(40, 55);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 2;
            this.button9.Text = "内翻";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(132, 25);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 1;
            this.button8.Text = "回零";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(40, 25);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 0;
            this.button7.Text = "使能";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox1);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.button6);
            this.groupBox7.Controls.Add(this.StartBtn);
            this.groupBox7.Controls.Add(this.PreReadyBtn);
            this.groupBox7.Location = new System.Drawing.Point(249, 62);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(252, 113);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(49, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "20";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "速度：";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(132, 62);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 2;
            this.button6.Text = "提交速度";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(132, 20);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 1;
            this.StartBtn.Text = "开始";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // PreReadyBtn
            // 
            this.PreReadyBtn.Location = new System.Drawing.Point(32, 20);
            this.PreReadyBtn.Name = "PreReadyBtn";
            this.PreReadyBtn.Size = new System.Drawing.Size(75, 23);
            this.PreReadyBtn.TabIndex = 0;
            this.PreReadyBtn.Text = "预准备";
            this.PreReadyBtn.UseVisualStyleBackColor = true;
            this.PreReadyBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Location = new System.Drawing.Point(249, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 39);
            this.panel1.TabIndex = 1;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("宋体", 12F);
            this.radioButton2.Location = new System.Drawing.Point(132, 8);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "右脚";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 12F);
            this.radioButton1.Location = new System.Drawing.Point(32, 8);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "左脚";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.HDT串口);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.ledMCU);
            this.groupBox4.Controls.Add(this.SerialDisconnectBtn);
            this.groupBox4.Controls.Add(this.SerialConnectBtn);
            this.groupBox4.Controls.Add(this.SerialScanBtn);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.ledHDT);
            this.groupBox4.Location = new System.Drawing.Point(7, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 331);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "串口配置";
            // 
            // HDT串口
            // 
            this.HDT串口.AutoSize = true;
            this.HDT串口.Location = new System.Drawing.Point(160, 250);
            this.HDT串口.Name = "HDT串口";
            this.HDT串口.Size = new System.Drawing.Size(47, 12);
            this.HDT串口.TabIndex = 7;
            this.HDT串口.Text = "HDT串口";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "MCU串口";
            // 
            // ledMCU
            // 
            this.ledMCU.AutoSize = true;
            this.ledMCU.Location = new System.Drawing.Point(7, 238);
            this.ledMCU.Name = "ledMCU";
            this.ledMCU.Size = new System.Drawing.Size(43, 44);
            this.ledMCU.TabIndex = 0;
            // 
            // SerialDisconnectBtn
            // 
            this.SerialDisconnectBtn.Location = new System.Drawing.Point(80, 302);
            this.SerialDisconnectBtn.Name = "SerialDisconnectBtn";
            this.SerialDisconnectBtn.Size = new System.Drawing.Size(75, 23);
            this.SerialDisconnectBtn.TabIndex = 4;
            this.SerialDisconnectBtn.Text = "断开";
            this.SerialDisconnectBtn.UseVisualStyleBackColor = true;
            this.SerialDisconnectBtn.Click += new System.EventHandler(this.SerialDisconnectBtn_Click);
            // 
            // SerialConnectBtn
            // 
            this.SerialConnectBtn.Location = new System.Drawing.Point(156, 302);
            this.SerialConnectBtn.Name = "SerialConnectBtn";
            this.SerialConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.SerialConnectBtn.TabIndex = 3;
            this.SerialConnectBtn.Text = "连接";
            this.SerialConnectBtn.UseVisualStyleBackColor = true;
            this.SerialConnectBtn.Click += new System.EventHandler(this.SerialConnectBtn_Click);
            // 
            // SerialScanBtn
            // 
            this.SerialScanBtn.Location = new System.Drawing.Point(2, 302);
            this.SerialScanBtn.Name = "SerialScanBtn";
            this.SerialScanBtn.Size = new System.Drawing.Size(75, 23);
            this.SerialScanBtn.TabIndex = 2;
            this.SerialScanBtn.Text = "扫描";
            this.SerialScanBtn.UseVisualStyleBackColor = true;
            this.SerialScanBtn.Click += new System.EventHandler(this.SerialScanBtn_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.comboM8128Baud);
            this.groupBox6.Controls.Add(this.comboM8128Com);
            this.groupBox6.Location = new System.Drawing.Point(7, 128);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(222, 100);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "HDT串口";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "波特率：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "COM口：";
            // 
            // comboM8128Baud
            // 
            this.comboM8128Baud.FormattingEnabled = true;
            this.comboM8128Baud.Location = new System.Drawing.Point(90, 60);
            this.comboM8128Baud.Name = "comboM8128Baud";
            this.comboM8128Baud.Size = new System.Drawing.Size(121, 20);
            this.comboM8128Baud.TabIndex = 5;
            // 
            // comboM8128Com
            // 
            this.comboM8128Com.FormattingEnabled = true;
            this.comboM8128Com.Location = new System.Drawing.Point(90, 21);
            this.comboM8128Com.Name = "comboM8128Com";
            this.comboM8128Com.Size = new System.Drawing.Size(121, 20);
            this.comboM8128Com.TabIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.comboMCUBaud);
            this.groupBox5.Controls.Add(this.comboMCUCom);
            this.groupBox5.Location = new System.Drawing.Point(7, 21);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(222, 100);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "MCU串口";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "波特率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "COM口：";
            // 
            // comboMCUBaud
            // 
            this.comboMCUBaud.FormattingEnabled = true;
            this.comboMCUBaud.Location = new System.Drawing.Point(95, 59);
            this.comboMCUBaud.Name = "comboMCUBaud";
            this.comboMCUBaud.Size = new System.Drawing.Size(121, 20);
            this.comboMCUBaud.TabIndex = 1;
            // 
            // comboMCUCom
            // 
            this.comboMCUCom.FormattingEnabled = true;
            this.comboMCUCom.Location = new System.Drawing.Point(95, 20);
            this.comboMCUCom.Name = "comboMCUCom";
            this.comboMCUCom.Size = new System.Drawing.Size(121, 20);
            this.comboMCUCom.TabIndex = 0;
            // 
            // ledHDT
            // 
            this.ledHDT.AutoSize = true;
            this.ledHDT.Location = new System.Drawing.Point(110, 238);
            this.ledHDT.Name = "ledHDT";
            this.ledHDT.Size = new System.Drawing.Size(43, 44);
            this.ledHDT.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(507, 344);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "主动训练";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(507, 344);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "被动训练";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(507, 344);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // SerialScanTimer
            // 
            this.SerialScanTimer.Interval = 500;
            this.SerialScanTimer.Tick += new System.EventHandler(this.SerialScanTimer_Tick);
            // 
            // ChartFTTimer
            // 
            this.ChartFTTimer.Interval = 2;
            this.ChartFTTimer.Tick += new System.EventHandler(this.ChartScanTimer_Tick);
            // 
            // PreReadyLed
            // 
            this.PreReadyLed.AutoSize = true;
            this.PreReadyLed.Location = new System.Drawing.Point(11, 21);
            this.PreReadyLed.Name = "PreReadyLed";
            this.PreReadyLed.Size = new System.Drawing.Size(43, 44);
            this.PreReadyLed.TabIndex = 0;
            // 
            // StartLed
            // 
            this.StartLed.AutoSize = true;
            this.StartLed.Location = new System.Drawing.Point(11, 56);
            this.StartLed.Name = "StartLed";
            this.StartLed.Size = new System.Drawing.Size(43, 44);
            this.StartLed.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "预准备";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "开始";
            // 
            // ChartAngleTimer
            // 
            this.ChartAngleTimer.Interval = 2;
            this.ChartAngleTimer.Tick += new System.EventHandler(this.ChartAngleTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 716);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AngleChart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.M8128Chart)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart AngleChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart M8128Chart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button SerialDisconnectBtn;
        private System.Windows.Forms.Button SerialConnectBtn;
        private System.Windows.Forms.Button SerialScanBtn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboM8128Baud;
        private System.Windows.Forms.ComboBox comboM8128Com;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboMCUBaud;
        private System.Windows.Forms.ComboBox comboMCUCom;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button PreReadyBtn;
        private LED.LED ledMCU;
        private System.Windows.Forms.Label HDT串口;
        private System.Windows.Forms.Label label6;
        private LED.LED ledHDT;
        private System.Windows.Forms.Timer SerialScanTimer;
        private System.Windows.Forms.Timer ChartFTTimer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private LED.LED StartLed;
        private LED.LED PreReadyLed;
        private System.Windows.Forms.Timer ChartAngleTimer;
    }
}

