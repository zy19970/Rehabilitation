using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlModel
{
    class TypeOneSystem
    {
        public float _xout = 0;                                     //输出结果
        public float _nowSteadyStateValue = 0;                      //当前输入产生稳态值
        public float _steadyStateCumulativeValue = 0;               //稳态累加值
        public float _M = 0.2f;                                     //惯性系数
        public float _D = 0.8f;                                     //阻尼系数
        public float _Ts;                                           //调整时间
        public float _nowTorque = 0;                                //当前采集力矩
        private Thread _myThread;                                   //线程
        public bool _flowFlag = false;                              //溢出标志
        public float[] _extractedData = new float[32];                //提取的数据
        private float[] _timeCoordinate = new float[32];            //时间坐标
        private float _torqueIn = 0;                                  //系统输入力矩
        private float _timeSpan = 0.04f;                            //离散化的时间跨度
        public float[][] _storedData = new float[32][];             //存储的数据
        private float[] _storedSteadyStateData = new float[32];     //存储的稳态数据
        private Int16 _serialNumber = 32;                           //离散化的个数  大于32时有问题  原因：在算法上，将力矩进行了消逗处理，导致力矩出现跳动，形成输出微回调，但最总输出是没问题的。
        public float _conversionRatio = 57.3f / 5.73f;               //弧度转角度比例
        public Int16 _arrangementNumber = 0;                        //排列号
        public float _positionAngleLimit = 32f;                     //正限位
        public float _nagetiveAngleLimit = -32f;                    //负限位

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void Init()
        {
            for (Int16 i = 0; i < _serialNumber; i++)
            {
                _storedData[i] = new float[_serialNumber];
                _extractedData[i] = 0;
                _storedSteadyStateData[i] = 0;
            }
            for (Int16 k = 0; k < _serialNumber; k++)
            {
                for (Int16 p = 0; p < _serialNumber; p++)
                    _storedData[k][p] = 0;
            }
        }
        /// <summary>
        /// 启动线程
        /// </summary>
        public void StartThread()
        {
            _myThread = new Thread(ThreadOut);
            _myThread.IsBackground = true;
            _myThread.Start();
        }
        /// <summary>
        /// 恢复线程
        /// </summary>
        public void ResumeThread()
        {
            _myThread.Resume();
        }
        /// <summary>
        /// 暂停线程
        /// </summary>
        public void PauseThread()
        {
            _myThread.Suspend();
        }
        /// <summary>
        /// 系统输出（离散后）
        /// </summary>
        /// <param name="M"></param>
        /// <param name="D"></param>
        /// <param name="Ti"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public float SystemOutput(float M, float D, float Ti, float t)
        {
            float _xo = 0;
            _xo = (float)(t - M / D + M / D * Math.Exp(-D / M * t)) / D * Ti;
            return _xo * _conversionRatio;
        }
        /// <summary>
        /// 下载数据
        /// </summary>
        /// <param name="M"></param>
        /// <param name="D"></param>
        /// <param name="Ti"></param>
        private void LoadData(float M, float D, float Ti)
        {
            float[] A = new float[_serialNumber];
            float[] B = new float[_serialNumber];
            B[0] = 0;
            for (int i = 0; i < (_serialNumber - 1); i++)
            {
                _timeCoordinate[i] = _timeSpan * (i + 1);
                A[i] = SystemOutput(M, D, Ti, _timeCoordinate[i]);
                B[i + 1] = SystemOutput(M, D, Ti, _timeCoordinate[i]);
            }
            A[_serialNumber - 1] = SystemOutput(M, D, Ti, _timeSpan * _serialNumber);
            for (int i = 0; i < _serialNumber; i++)
                _extractedData[i] = A[i] - B[i];
            _nowSteadyStateValue = Ti * _timeSpan * _conversionRatio / D; //稳态部分
        }
        /// <summary>
        /// 排列数据
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <param name="k"></param>
        private void ArrangingData(float[] data1, float[] data2, int k)
        {
            for (int i = 0; i < (_serialNumber - k); i++)
            {
                data1[i + k] = data2[i];
            }
            for (int i = 0; i < k; i++)
            {
                data1[i] = data2[_serialNumber - k + i];
            }
        }
        /// <summary>
        /// 累加数据
        /// </summary>
        /// <param name="t"></param>
        public void CumulativeData(int t)
        {
            float sum = 0;
            _steadyStateCumulativeValue += _storedSteadyStateData[t];
            ArrangingData(_storedData[t], _extractedData, t);
            for (int i = 0; i < _serialNumber; i++)
                sum += _storedData[i][t];
            _xout = sum + _steadyStateCumulativeValue;
            _storedSteadyStateData[t] = _nowSteadyStateValue;
        }
        /// <summary>
        /// 输入力矩处理
        /// </summary>
        private void TorqueInputProcessing()
        {
            if (_nowTorque < 20 && _nowTorque > -20)
                if (_nowTorque < 0.3 & _nowTorque > -0.3)
                    _torqueIn = 0;//消去抖动偏移误差 
                else
                    _torqueIn = _nowTorque;

            if (_xout > _positionAngleLimit || _xout == _positionAngleLimit)
            {
                if (_torqueIn > 0)
                    _torqueIn = 0;
            }
            else if (_xout < _nagetiveAngleLimit || _xout == _nagetiveAngleLimit)
            {
                if (_torqueIn < 0)
                    _torqueIn = 0;
            }
        }
        /// <summary>
        /// 软件限位
        /// </summary>
        private void LimitAngle()
        {
            if (_xout > _positionAngleLimit || _xout == _positionAngleLimit)
            {
                _xout = _positionAngleLimit;
            }
            else if (_xout < _nagetiveAngleLimit || _xout == _nagetiveAngleLimit)
            {
                _xout = _nagetiveAngleLimit;
            }
        }
        /// <summary>
        /// 线程入口
        /// </summary>
        private void ThreadOut()
        {
            Init();//初始化
            while (true)
            {
                for (; true;)
                {
                    if (_flowFlag)
                    {
                        _arrangementNumber++;
                        TorqueInputProcessing();
                        LoadData(_M, _D, _torqueIn);
                        CumulativeData(_arrangementNumber);
                        if (_arrangementNumber == _serialNumber - 1)
                            _arrangementNumber = -1;
                        _flowFlag = false;
                    }
                    Thread.Sleep(1);        //线程睡眠，避免线程执行完循环之后继续占用CPU
                }
            }
        }
    }
}
