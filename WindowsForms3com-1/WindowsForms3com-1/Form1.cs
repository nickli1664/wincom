using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Web.Script.Serialization;
using System.IO;

namespace WindowsForms3com_1
{
    public partial class Form1 : Form
    {
        public delegate void MyInvoke(string str);
        public SerialPort com1,com2,com3;
        public bool comopen1 = false;
        public bool comopen2 = false;
        public bool comopen3 = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comopen1 == false)
                {
                    this.com1 = new SerialPort(comboBox1.Text, 9600, Parity.None, 8, StopBits.One);
                    com1.Open();
                    this.comopen1 = true;

                    Thread comRead1 = new Thread(new ThreadStart(ReadCom1));
                    comRead1.IsBackground = true;
                    comRead1.Name = "nickcomread1";
                    comRead1.Start();
                   
                    button2.Text = "关闭串口";
                    this.comboBox1.Enabled = false;
                }
                else
                {
                    com1.Close();
                    this.comopen1 = false;
                    button2.Text = "打开串口";
                    this.comboBox1.Enabled = true;
                }
            }
            catch(Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comopen1 == true)
                {
                    string str = textBox2.Text;
                    this.com1.Write(str);
                }
            }
            catch(Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comopen1 == true)
                {
                    string str = textBox3.Text;
                    this.com1.Write(str);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void ReadCom1()
        {
            while (this.comopen1 == true)
            {
                byte[] data = new byte[com1.BytesToRead];
                int a = com1.Read(data, 0, data.Length);
                MyInvoke mi = new MyInvoke(SetTxt);
                this.BeginInvoke(mi, new object[] { Encoding.ASCII.GetString(data, 0, a) });
                Thread.Sleep(100);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        public void SetTxt(string str)
        {
            this.textBox1.Text += str;
        }

        private void button6_Click(object sender, EventArgs e)                                            //第2个选项卡从这里开始
        {
            try
            {
                if (this.comopen2 == false)
                {
                    this.com2 = new SerialPort(comboBox3.Text, 9600, Parity.None, 8, StopBits.One);
                    com2.Open();
                    this.comopen2 = true;

                    Thread comRead2 = new Thread(new ThreadStart(ReadCom2));
                    comRead2.IsBackground = true;
                    comRead2.Name = "nickcomread2";
                    comRead2.Start();

                    button6.Text = "关闭串口";
                    this.comboBox3.Enabled = false;
                }
                else
                {
                    com2.Close();
                    this.comopen2 = false;
                    button6.Text = "打开串口";
                    this.comboBox3.Enabled = true;
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comopen2 == true)
                {
                    string str = textBox5.Text;
                    this.com2.Write(str);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comopen2 == true)
                {
                    string str = textBox4.Text;
                    this.com2.Write(str);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void ReadCom2()
        {
            while (this.comopen2 == true)
            {
                byte[] data = new byte[com2.BytesToRead];
                int a = com2.Read(data, 0, data.Length);
                MyInvoke mi = new MyInvoke(SetTxt2);
                this.BeginInvoke(mi, new object[] { Encoding.ASCII.GetString(data, 0, a) });
                Thread.Sleep(100);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.textBox6.Text = "";
        }

        public void SetTxt2(string str)
        {
            this.textBox6.Text += str;
        }

        private void button8_Click(object sender, EventArgs e)                                   //第3个选项卡从这里开始
        {
            try
            {
                if (this.comopen3 == false)
                {
                    this.com3 = new SerialPort(comboBox2.Text, 9600, Parity.None, 8, StopBits.One);
                    com3.Open();
                    this.comopen3 = true;

                    Thread comRead3 = new Thread(new ThreadStart(ReadCom3));
                    comRead3.IsBackground = true;
                    comRead3.Name = "nickcomread3";
                    comRead3.Start();

                    button8.Text = "关闭串口";
                    this.comboBox2.Enabled = false;
                }
                else
                {
                    com3.Close();
                    this.comopen3 = false;
                    button8.Text = "打开串口";
                    this.comboBox2.Enabled = true;
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comopen3 == true)
                {
                    string str = textBox8.Text;
                    this.com3.Write(str);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comopen3 == true)
                {
                    string str = textBox7.Text;
                    this.com3.Write(str);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void ReadCom3()
        {
            while (this.comopen3 == true)
            {
                byte[] data = new byte[com3.BytesToRead];
                int a = com3.Read(data, 0, data.Length);
                MyInvoke mi = new MyInvoke(SetTxt3);
                this.BeginInvoke(mi, new object[] { Encoding.ASCII.GetString(data, 0, a) });
                Thread.Sleep(100);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.textBox9.Text = "";
        }

        public void SetTxt3(string str)
        {
            this.textBox9.Text += str;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            CodeAndComport cac = new CodeAndComport();
            cac.comport1 = "";
            cac.openscreen1 = this.textBox2.Text;
            cac.closescreen1 = this.textBox3.Text;
            cac.comport2 = "";
            cac.openscreen2 = this.textBox5.Text;
            cac.closescreen2 = this.textBox4.Text;
            cac.comport3 = "";
            cac.openscreen3 = this.textBox8.Text;
            cac.closescreen3 = this.textBox7.Text;

            string output = new JavaScriptSerializer().Serialize(cac);

            FileStream fs = new FileStream(@"cac.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(output);
            sw.Close();
            fs.Close();
            MessageBox.Show(output + "----保存成功!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string strduqu = File.ReadAllText(@"cac.txt");
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            CodeAndComport cacduqu = js2.Deserialize<CodeAndComport>(strduqu);
            this.textBox2.Text = cacduqu.openscreen1;
            this.textBox3.Text = cacduqu.closescreen1;
            this.textBox5.Text = cacduqu.openscreen2;
            this.textBox4.Text = cacduqu.closescreen2;
            this.textBox8.Text = cacduqu.openscreen3;
            this.textBox7.Text = cacduqu.closescreen3;
        }
    }
}
