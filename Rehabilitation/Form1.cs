using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ControlModel;

namespace Rehabilitation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            SerialPortInit();
            STMSerial.DataReceived += new SerialDataReceivedEventHandler(STMDataReceivedHandler);
            M8128Serial.DataReceived += new SerialDataReceivedEventHandler(M8128DataReceivedHandler);
        }

        //--------------------------------------------------------//
        /*
         * 代码块功能：声明变量
         * 版本迭代：V1.0    初始代码
         * 作者：InTron
         * 日期：2020.05.18
         */

        //指示灯部分
        bool IsPreReady = false;
        bool IsStart = false;



        //串口部分
        public static SerialPort STMSerial = new SerialPort();//定义与MCU通信的串口
        public static SerialPort M8128Serial = new SerialPort();//定义与采集卡通讯的串口

        static byte[] M8128RevData = new byte[29];//定义采集卡接收的一帧的字节
        static byte[] STMRevData = new byte[14];//定义MCU接收的一帧的字节

        static Queue STMSendQueue = new Queue(104);//MCU发送队列
        static Queue M8128SendQueue = new Queue();//采集卡发送队列

        static bool TorqeIsUpdate = false;//力矩更新标识符
        static bool AngleIsUpdate = false;//角度更新标识符

        public static Object M8128Lock = new Object();//采集卡线程间安全锁
        public static Object STMLock = new Object();//MCU线程安全锁

        static Thread M8128SendMsgThread = new Thread(M8128SendMsg);//采集卡串口发送线程
        static Thread STMSendMsgThread = new Thread(STMSendMsg);//MCU串口发送线程


        //数据结构
        static From1.M8128 FTSensor = new From1.M8128();//定义采集卡的力和力矩的数据结构
        static From1.DeDetail DegreeSensor = new From1.DeDetail();//定义编码器三个角度的数据结构

        //消息队列部分
        static int NumOfPoint = 100;//曲线绘制点个数

        private Queue<double> XDegreedata = new Queue<double>(NumOfPoint);
        private Queue<double> YDegreedata = new Queue<double>(NumOfPoint);
        private Queue<double> ZDegreedata = new Queue<double>(NumOfPoint);

        static private Queue<double> XFdata = new Queue<double>(NumOfPoint);
        static private Queue<double> YFdata = new Queue<double>(NumOfPoint);
        static private Queue<double> ZFdata = new Queue<double>(NumOfPoint);

        static private Queue<double> XTdata = new Queue<double>(NumOfPoint);
        static private Queue<double> YTdata = new Queue<double>(NumOfPoint);
        static private Queue<double> ZTdata = new Queue<double>(NumOfPoint);

        //--------------------------------------------------------//



        //--------------------------------------------------------//
        /*
         * 代码块功能：串口
         * 版本迭代：V1.0    初始代码
         * 作者：InTron
         * 日期：2020.05.18
         * 尚存问题：Null
         */
        private void SerialPortInit()//串口参数初始化
        {
            comboMCUCom.Text = "COM25";
            comboMCUBaud.Text = "115200";
            comboM8128Com.Text = "COM26";
            comboM8128Baud.Text = "115200";
        }

        private void SearchAndAddSerialToComboBox(SerialPort MyPort, ComboBox MyBox)//扫描串口添加到Combobox
        {
            MyBox.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                MyBox.Items.Add(port);
            }

        }
        private void ScanSerialPort()//串口扫描
        {
            SearchAndAddSerialToComboBox(STMSerial, comboMCUCom);
            SearchAndAddSerialToComboBox(M8128Serial, comboM8128Com);
        }

        private void SerialPortConnect()//串口连接
        {
            try
            {
                STMSerial.PortName = comboMCUCom.Text;
                STMSerial.BaudRate = Convert.ToInt32(comboMCUBaud.Text, 10);

                M8128Serial.PortName = comboM8128Com.Text;
                M8128Serial.BaudRate = Convert.ToInt32(comboM8128Baud.Text, 10);

                STMSerial.Open();
                if (!STMSendMsgThread.IsAlive && STMSerial.IsOpen)
                {
                    STMSendMsgThread.Start();
                }
                

                //M8128Serial.Open();
                if (!M8128SendMsgThread.IsAlive && M8128Serial.IsOpen)
                {
                    M8128SendMsgThread.Start();
                }
                


                if(!SerialScanTimer.Enabled)
                { SerialScanTimer.Start(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SerialPortDisconnect()//断开连接
        {
            try
            {
                STMSerial.Close();
                if (!STMSendMsgThread.IsAlive && STMSerial.IsOpen)
                {
                    STMSendMsgThread.Abort();
                }

                M8128Serial.Close();
                if (!M8128SendMsgThread.IsAlive && M8128Serial.IsOpen)
                {
                    M8128SendMsgThread.Abort();
                }


                if (SerialScanTimer.Enabled)
                { SerialScanTimer.Start(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
            {
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            }
            return sb.ToString().ToUpper();
        }//用于测试串口功能的字节转换函数，在具体业务中不使用
        private static void M8128DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            TorqeIsUpdate = false;
            M8128RevData = new byte[29];
            SerialPort sp = (SerialPort)sender;
            if (sp.BytesToRead <= 0)
            {
                return;
            }
            _ = M8128RevData;
            lock (M8128Lock)
            {
                bool FirstIsOk = false;
                bool HeadIsOK = false;

                int RevNum = 0;

                for (; RevNum < 29;)
                {
                    byte RevData;
                    if (!sp.IsOpen) { return; }
                    RevData = Convert.ToByte(sp.ReadByte());


                    if (HeadIsOK)
                    {
                        M8128RevData[RevNum] = RevData;
                        RevNum++;
                    }
                    if (!FirstIsOk && RevData == 0xAA)
                    {
                        FirstIsOk = true;
                    }
                    if (FirstIsOk && RevData == 0x55 && !HeadIsOK)
                    {
                        HeadIsOK = true;
                    }
                }
            }

            _ = M8128RevData;
            if (M8128RevData == null)
            {
                Console.WriteLine(ByteArrayToHexString(M8128RevData));
                return;
            }
            FTSensor.forceX = BitConverter.ToSingle(M8128RevData, 4);
            FTSensor.torqueX = BitConverter.ToSingle(M8128RevData, 16);//实际力矩

            FTSensor.forceY = BitConverter.ToSingle(M8128RevData, 8);//实际力
            FTSensor.torqueY = BitConverter.ToSingle(M8128RevData, 20);//实际力矩

            FTSensor.forceZ = BitConverter.ToSingle(M8128RevData, 12);//实际力
            FTSensor.torqueZ = BitConverter.ToSingle(M8128RevData, 24);//实际力矩

            TorqeIsUpdate = true;

            Console.WriteLine("Fx=" + FTSensor.forceX + "Tx=" + FTSensor.torqueX
                + "Fy=" + FTSensor.forceY + "Ty=" + FTSensor.torqueY
                + "Fz=" + FTSensor.forceZ + "Tz=" + FTSensor.torqueZ
                );
        }//采集卡串口接收线程

        private static void STMDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            AngleIsUpdate = false;
            STMRevData = new byte[14];
            SerialPort sp = (SerialPort)sender;
            if (sp.BytesToRead <= 0)
            {
                return;
            }

            lock (STMLock)
            {

                bool FirstIsOk = false;
                bool HeadIsOK = false;

                int RevNum = 0;

                for (; RevNum < 14;)
                {
                    byte RevData;
                    if (!sp.IsOpen) { return; }
                    RevData = Convert.ToByte(sp.ReadByte());


                    if (HeadIsOK)
                    {
                        STMRevData[RevNum] = RevData;
                        RevNum++;
                    }
                    if (!FirstIsOk && RevData == 0x11)
                    {
                        FirstIsOk = true;
                    }
                    if (FirstIsOk && RevData == 0xFF && !HeadIsOK)
                    {
                        HeadIsOK = true;
                    }
                }
                DegreeSensor.degreeX = BitConverter.ToSingle(STMRevData, 1);
                DegreeSensor.degreeY = BitConverter.ToSingle(STMRevData, 5);
                DegreeSensor.degreeZ = BitConverter.ToSingle(STMRevData, 9);
                AngleIsUpdate = true;
            }
            Console.WriteLine("DegreeX=" + DegreeSensor.degreeX
                + "DegreeY=" + DegreeSensor.degreeY
                + "DegreeZ=" + DegreeSensor.degreeZ
                );
        }//MCU串口接收线程

        public static void M8128SendMsg()
        {
            while (true)
            {
                if (M8128SendQueue.Count > 0)
                {
                    byte[] send_data = (byte[])M8128SendQueue.Dequeue();
                    if (send_data != null && M8128Serial.IsOpen)
                    {
                        try { M8128Serial.Write(send_data, 0, send_data.Length); }
                        catch { }

                    }

                }
                Thread.Sleep(2);
            }

        }//PCto采集卡

        public static void STMSendMsg()
        {
            while (true)
            {
                if (STMSendQueue.Count > 0)
                {
                    byte[] send_data = (byte[])STMSendQueue.Dequeue();
                    if (send_data != null && STMSerial.IsOpen)
                    {
                        try { STMSerial.Write(send_data, 0, send_data.Length); }
                        catch { }
                    }
                }
                Thread.Sleep(2);
            }

        }//PCtoMCU
         //--------------------------------------------------------//



         //--------------------------------------------------------//
        /*
         * 代码块功能：通信协议消息队列
         * 版本迭代：V1.0    初始版本
         * 作者：InTron
         * 日期：2020.05.19
         * 尚存问题：Null
         */

        private void M8218MqInit()
        {
            string strCmd = "AT+SGDM=(A01,A02,A03,A04,A05,A06);E;1;(WMA:1)\r\n";
            byte[] byteCmd = Encoding.Default.GetBytes(strCmd);
            M8128SendQueue.Enqueue(byteCmd);
            strCmd = "AT+GSD\r\n";
            byteCmd = Encoding.Default.GetBytes(strCmd);
            M8128SendQueue.Enqueue(byteCmd);

        }
        //--------------------------------------------------------//


        //--------------------------------------------------------//
        /*
         * 代码块功能：实时曲线功能
         * 版本迭代：V1.0    初始版本
         * 作者：InTron
         * 日期：2020.05.19
         * 尚存问题：Null
         */
        private void ChartInit()
        {
            AngleChart.Titles.Add("Real Time Angle Data");

            AngleChart.Series.Clear();

            Series seriesX = new Series("X Degree");
            seriesX.ChartArea = "ChartArea1";
            AngleChart.Series.Add(seriesX);

            Series seriesY = new Series("Y Degree");
            seriesY.ChartArea = "ChartArea1";
            AngleChart.Series.Add(seriesY);

            Series seriesZ = new Series("Z Degree");
            seriesZ.ChartArea = "ChartArea1";
            AngleChart.Series.Add(seriesZ);

            for (int i = 0; i < 3; i++)
            {
                //                AngleChart.Series[i].Label = "#VAL";
                AngleChart.Series[i].ChartType = SeriesChartType.Spline;
                AngleChart.Series[i].BorderWidth = 1; //线条粗细
            }

            //添加的两组Test数据
            List<int> txData2 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> tyData2 = new List<int>() { 9, 6, 7, 4, 5, 4 };
            List<int> txData3 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> tyData3 = new List<int>() { 3, 8, 2, 5, 4, 9 };
            AngleChart.Series[0].Points.DataBindXY(txData2, tyData2); //添加数据
            AngleChart.Series[1].Points.DataBindXY(txData3, tyData3); //添加数据

            M8128Chart.Titles.Add("Real Time Torque Data");

            M8128Chart.Series.Clear();

            Series seriesFX = new Series("Force X");
            seriesFX.ChartArea = "ChartArea1";
            M8128Chart.Series.Add(seriesFX);

            Series seriesFY = new Series("Force Y");
            seriesFY.ChartArea = "ChartArea1";
            M8128Chart.Series.Add(seriesFY);

            Series seriesFZ = new Series("Force Z");
            seriesFZ.ChartArea = "ChartArea1";
            M8128Chart.Series.Add(seriesFZ);

            Series seriesTX = new Series("Torque X");
            seriesTX.ChartArea = "ChartArea1";
            M8128Chart.Series.Add(seriesTX);

            Series seriesTY = new Series("Torque Y");
            seriesTY.ChartArea = "ChartArea1";
            M8128Chart.Series.Add(seriesTY);

            Series seriesTZ = new Series("Torque Z");
            seriesTZ.ChartArea = "ChartArea1";
            M8128Chart.Series.Add(seriesTZ);


            for (int i = 0; i < 6; i++)
            {
                //Acqchart.Series[i].Label = "#VAL";
                M8128Chart.Series[i].ChartType = SeriesChartType.Spline;
                M8128Chart.Series[i].BorderWidth = 1; //线条粗细
            }

            M8128Chart.Series[3].Points.DataBindXY(txData2, tyData2); //添加数据
            M8128Chart.Series[5].Points.DataBindXY(txData3, tyData3); //添加数据

        }

        private void UpdateAngleQueue()
        {
            if (XDegreedata.Count > NumOfPoint)
            {
                XDegreedata.Dequeue();
                YDegreedata.Dequeue();
                ZDegreedata.Dequeue();
            }
            lock (STMLock)
            {
                XDegreedata.Enqueue(DegreeSensor.degreeX);
                YDegreedata.Enqueue(DegreeSensor.degreeY);
                ZDegreedata.Enqueue(DegreeSensor.degreeZ);
            }
            PaintAngle();
        }
        private void PaintAngle()
        {
            AngleIsUpdate = false;

            for (int i = 0; i < 3; i++)
            {
                AngleChart.Series[i].Points.Clear();
            }
            for (int i = 0; i < XDegreedata.Count; i++)
            {
                AngleChart.Series[0].Points.AddXY((i + 1), XDegreedata.ElementAt(i));
                AngleChart.Series[1].Points.AddXY((i + 1), YDegreedata.ElementAt(i));
                AngleChart.Series[2].Points.AddXY((i + 1), ZDegreedata.ElementAt(i));
            }

        }



        private void UpdateTorqeQueue()
        {

            Console.WriteLine(XTdata.Count);
            if (XFdata.Count > NumOfPoint)
            {
                XFdata.Dequeue();
                YFdata.Dequeue();
                ZFdata.Dequeue();
                XTdata.Dequeue();
                YTdata.Dequeue();
                ZTdata.Dequeue();
            }
            lock (M8128Lock)
            {
                XFdata.Enqueue(FTSensor.forceX);
                XTdata.Enqueue(FTSensor.torqueX);
                YFdata.Enqueue(FTSensor.forceY);
                YTdata.Enqueue(FTSensor.torqueY);
                ZFdata.Enqueue(FTSensor.forceZ);
                ZTdata.Enqueue(FTSensor.torqueZ);

                
            }
            PaintTorqe();

        }
        private void PaintTorqe()
        {
            TorqeIsUpdate = false;

            for (int i = 0; i < 6; i++)
            {
                M8128Chart.Series[i].Points.Clear();
            }
            for (int i = 0; i < XFdata.Count; i++)
            {
                M8128Chart.Series[0].Points.AddXY((i + 1), XFdata.ElementAt(i));

                M8128Chart.Series[1].Points.AddXY((i + 1), YFdata.ElementAt(i));

                M8128Chart.Series[2].Points.AddXY((i + 1), ZFdata.ElementAt(i));

                M8128Chart.Series[3].Points.AddXY((i + 1), XTdata.ElementAt(i));

                M8128Chart.Series[4].Points.AddXY((i + 1), YTdata.ElementAt(i));

                M8128Chart.Series[5].Points.AddXY((i + 1), ZTdata.ElementAt(i));
            }


        }

        //--------------------------------------------------------//


        private void Form1_Load(object sender, EventArgs e)
        {
            ChartInit();
        }

        private void SerialScanBtn_Click(object sender, EventArgs e)
        {
            Thread childThread = new Thread(ScanSerialPort);
            childThread.Start();
        }

        private void SerialConnectBtn_Click(object sender, EventArgs e)
        {
            SerialPortConnect();
            
            
        }

        private void SerialDisconnectBtn_Click(object sender, EventArgs e)
        {
            SerialPortDisconnect();
        }

        private void SerialScanTimer_Tick(object sender, EventArgs e)
        {
            if (STMSerial.IsOpen)
            {ledMCU.LedIsOn();}
            else{ledMCU.LedIsOff();}

            if (M8128Serial.IsOpen)
            {ledHDT.LedIsOn();}
            else{ledHDT.LedIsOff();}

            if (IsPreReady)
            {
                PreReadyLed.LedIsOn();
            }
            else
            {
                PreReadyLed.LedIsOff();
            }

            if (IsStart)
            {
                StartLed.LedIsOn();
            }
            else
            {
                StartLed.LedIsOff();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            M8218MqInit();
            IsPreReady = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChartFTTimer.Start();
            ChartAngleTimer.Start();
            IsStart = true;
        }

        private void ChartScanTimer_Tick(object sender, EventArgs e)
        {
            if (TorqeIsUpdate)
            {
                UpdateTorqeQueue();
            }
        }

        private void ChartAngleTimer_Tick(object sender, EventArgs e)
        {
            if (AngleIsUpdate)
            {
                UpdateAngleQueue();
            }
        }
    }
}
