using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSPD
{

    class PortControlHelper
    {
        //创建串口对象
        private SerialPort sp;

        /// <summary>
        /// 端口名称数组
        /// </summary>
        public string[] PortNameArr { get; set; }

        /// <summary>
        /// 串口通信开启状态
        /// </summary>
        //public bool PortState { get; set; } = false;

        /// <summary>
        /// 编码类型
        /// </summary>
        public Encoding EncodingType { get; set; } = Encoding.ASCII;

        /// <summary>
        /// 串口接收数据委托
        /// </summary>
        public delegate void ComReceiveDataHandler(string data);

        public ComReceiveDataHandler OnComReceiveDataHandler = null;

        public PortControlHelper()
        {
            PortNameArr = SerialPort.GetPortNames();
            sp = new SerialPort();
            //sp.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sendData"></param>
        public void SendData(string sendData)
        {
            try
            {
                sp.Encoding = EncodingType;
                sp.Write(sendData);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 打开窗口
        /// </summary>
        public void openPort(string name) {
            //string portName, int boudRate = 115200, int dataBit = 8, int stopBit = 1, int timeout = 5000
            sp.PortName = name;
            sp.BaudRate = 110;
            sp.DataBits = 8;
            sp.StopBits = (StopBits)1;
            sp.ReadTimeout = 5000;
            sp.Open();

        }

        /// <summary>
        /// 关闭端口
        /// </summary>
        public void ClosePort()
        {
            try
            {
                sp.Close();
                //PortState = false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 接收数据回调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[sp.BytesToRead];
            sp.Read(buffer, 0, buffer.Length);
            string str = EncodingType.GetString(buffer);
            if (OnComReceiveDataHandler != null)
            {
                OnComReceiveDataHandler(str);
            }
        }

    }
}
