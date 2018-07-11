using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSPD
{


    public partial class Form1 : Form
    {
        //创建串口接收输入对象
        private PortControlHelper pchSend;
        private PortControlHelper pchReceive;



        public Form1()
        {
            InitializeComponent();
            pchSend = new PortControlHelper();
            pchReceive = new PortControlHelper();
            VSPDopen();
        }


        /// <summary>
        /// 打开串口
        /// </summary>
        /// 
        void VSPDopen()
        {

            //pchSend.ClosePort();
            //pchReceive.ClosePort();

            pchSend.openPort("COM2");
            pchReceive.openPort("COM3");

            pchReceive.OnComReceiveDataHandler += new PortControlHelper.ComReceiveDataHandler(ComReceiveData);
        }


        /// <summary>
        /// 接收到的数据，写入文本框内
        /// </summary>
        /// <param name="data"></param>
        private void ComReceiveData(string data)
        {
            this.Invoke(new EventHandler(delegate
            {
                textBox2.AppendText($"接收：{data}\n");
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pchSend.SendData(textBox1.Text);
        }

        /// <summary>
        /// 关闭端口
        /// </summary>




    }
}
