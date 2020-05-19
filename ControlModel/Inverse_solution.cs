using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlModel
{
    class Inverse_solution
    {
        public Thread Inverse_solution_Thread;//创建位置逆解线程
        public float degree_x = 0;
        public float degree_y = 0;
        public float degree_z = 0;
        private float angle_x1;
        private float angle_y1;
        private float angle_z1;
        public float L1 = 0;
        public float L2 = 0;
        public float L1_variation = 0;
        public float L2_variation = 0;
        public float L1_variation_last = 0;
        public float L2_variation_last = 0;
        private const float l_right_1 = 438.0037f;//背向开口，确定方向
        private const float l_left_2 = 438.0037f;//背向开口，确定方向
        public Matrix B1 = new Matrix(3, 1);
        private Matrix B2 = new Matrix(3, 1);
        private Matrix A1 = new Matrix(3, 1);
        private Matrix A2 = new Matrix(3, 1);
        public Matrix ROM = new Matrix(3, 3);
        public Matrix R1 = new Matrix(3, 1);
        public Matrix R2 = new Matrix(3, 1);
        Matrix Rz = new Matrix(3, 3);
        Matrix Rx = new Matrix(3, 3);
        Matrix Ry = new Matrix(3, 3);
        private double[,] B01 = { { 120 }, { 110 }, { -4.5 } };
        private double[,] B02 = { { -120 }, { 110 }, { -4.5 } };
        private double[,] A01 = { { 175 }, { 80 }, { -438 } };
        private double[,] A02 = { { -175 }, { 80 }, { -438 } };
        double[,] Rz0;
        double[,] Rx0;
        double[,] Ry0;
        /// <summary>
        /// 启动线程
        /// </summary>
        public void Inverse_solution_ThreadStart()
        {
            Inverse_solution_Thread = new Thread(threadout);
            Inverse_solution_Thread.IsBackground = true;
            Inverse_solution_Thread.Start();
        }
        /// <summary>
        /// 挂起线程
        /// </summary>
        public void Inverse_solution_ThreadStop()
        {
            Inverse_solution_Thread.Suspend();
        }
        private void parameterInit()
        {
            angle_x1 = (float)(degree_x / 180 * Math.PI); // 转为弧度
            angle_y1 = (float)(degree_y / 180 * Math.PI);
            angle_z1 = (float)(degree_z / 180 * Math.PI); // 转为弧度

            B1.Detail = B01;
            B2.Detail = B02;
            A1.Detail = A01;
            A2.Detail = A02;
        }
        private void matriInit()
        {
            Rz0 = new double[,]                 //二维嵌套数组
                                    { { Math.Cos(angle_z1),-Math.Sin(angle_z1), 0},
                                      {Math.Sin(angle_z1) , Math.Cos(angle_z1), 0},
                                      {0                  ,                  0, 1}};
            Rx0 = new double[,]
                                    { {1,                  0,                  0},
                                      {0, Math.Cos(angle_x1),-Math.Sin(angle_x1)},
                                      {0, Math.Sin(angle_x1) ,Math.Cos(angle_x1)}};
            Ry0 = new double[,]
                                    { { Math.Cos(angle_y1),0,Math.Sin(angle_y1)},
                                      {0                  ,1,                 0},
                                      {-Math.Sin(angle_y1),0,Math.Cos(angle_y1)}};
            Rz.Detail = Rz0;
            Rx.Detail = Rx0;
            Ry.Detail = Ry0;
            ROM = MatrixOperator.MatrixMulti(Rz, Ry);
            ROM = MatrixOperator.MatrixMulti(ROM, Rx);
        }
        private void get_result()
        {
            Matrix R01 = new Matrix(3, 1);
            Matrix R02 = new Matrix(3, 1);
            R01 = MatrixOperator.MatrixMulti(ROM, B1);
            R02 = MatrixOperator.MatrixMulti(ROM, B2);
            R1 = MatrixOperator.MatrixSub(R01, A1);
            R2 = MatrixOperator.MatrixSub(R02, A2);
            L1 = (float)(getlength(R1));
            L2 = (float)(getlength(R2));
            L1_variation = L1 - l_right_1;
            L2_variation = L2 - l_left_2;
        }
        private double getlength(Matrix T)//求模函数
        {
            double length = 0;
            double sum = 0;
            int m = T.getM;
            int n = T.getN;
            double[,] a = T.Detail;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    sum += Math.Pow(a[i, j], 2);
            }
            length = Math.Sqrt(sum);
            return length;
        }
        public void threadout()
        {
            while (true)
            {
                for (; true;)
                {
                    parameterInit();
                    matriInit();
                    L1_variation_last = L1_variation;
                    L2_variation_last = L2_variation;
                    get_result();
                    Thread.Sleep(1);
                }
            }
        }
    }
}
