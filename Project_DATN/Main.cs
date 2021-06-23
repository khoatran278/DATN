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

namespace Project_DATN
{
    public partial class Main : Form
    {
        string ReceiveData;
        string[] RevData_array;
        public double Sensor1, Sensor2, Sensor3, Sensor4, Sensor5;
        double Percent_SS1, Percent_SS2, Percent_SS3, Percent_SS4, Percent_SS5, Temp;

        

        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            cbBaudrate.SelectedIndex = 1;
            string[] ComPortName = SerialPort.GetPortNames();
            cbPort.Items.AddRange(ComPortName);
            //cbPort.SelectedIndex = 0;
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;

            //timer1.Enabled = true;
        }



        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }
        private void btnSensor_Click(object sender, EventArgs e)
        {
            Sensor frmSS = new Sensor(this);
            frmSS.Show();
        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cbPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(cbBaudrate.Text);
                serialPort1.Open();
                MessageBox.Show("Connection is successful");
                if (serialPort1.IsOpen)
                {
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                }
                Sensor frmSS = new Sensor();
                frmSS.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection is false\n" + ex.Message);
            }
        }
        private void btnDisconnect_Click_1(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                MessageBox.Show("Disconnection is successful");
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Disconnection is false\n" + ex.Message);
            }
        }

        private void serialPort1_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            
            ReceiveData = serialPort1.ReadExisting();
            RevData_array = ReceiveData.Split('\n');
            //Sensor1 = Convert.ToDouble(RevData_array[0]);
            //Sensor2 = Convert.ToDouble(RevData_array[1]);
            //Sensor3 = Convert.ToDouble(RevData_array[2]);
            //Sensor4 = Convert.ToDouble(RevData_array[3]);
            //Sensor5 = Convert.ToDouble(RevData_array[4]);
            //this.Invoke(new EventHandler(ShowSS1));
            //this.Invoke(new EventHandler(ShowSS2));
            //this.Invoke(new EventHandler(ShowSS3));
            //this.Invoke(new EventHandler(ShowSS4));
            //this.Invoke(new EventHandler(ShowSS5));
        }

        //private void ShowSS5(object sender, EventArgs e)
        //{
        //    if (Sensor5 < 11)
        //    {
        //        Percent_SS5 = 100;
        //    }
        //    else if (Sensor5 > 49)
        //    {
        //        Percent_SS5 = 0;
        //    }
        //    else
        //    {
        //        Temp = 100 - (Sensor5 - 10) / 0.4;
        //        if (Temp < 10)
        //        {
        //            Percent_SS5 = 0;
        //        }
        //        if ((Temp < 20) && (Temp > 9))
        //        {
        //            Percent_SS5 = 10;
        //        }
        //        if ((Temp < 30) && (Temp > 19))
        //        {
        //            Percent_SS5 = 20;
        //        }
        //        if ((Temp < 40) && (Temp > 29))
        //        {
        //            Percent_SS5 = 30;
        //        }
        //        if ((Temp < 50) && (Temp > 39))
        //        {
        //            Percent_SS5 = 40;
        //        }
        //        if ((Temp < 60) && (Temp > 49))
        //        {
        //            Percent_SS5 = 50;
        //        }
        //        if ((Temp < 70) && (Temp > 59))
        //        {
        //            Percent_SS5 = 60;
        //        }
        //        if ((Temp < 80) && (Temp > 69))
        //        {
        //            Percent_SS5 = 70;
        //        }
        //        if ((Temp < 90) && (Temp > 79))
        //        {
        //            Percent_SS5 = 80;
        //        }
        //        if (Temp > 89)
        //        {
        //            Percent_SS5 = 90;
        //        }
        //    }
        //    switch (Percent_SS5)
        //    {
        //        case 0:
        //            tBox1SS5.BackColor = Color.White;
        //            tBox2SS5.BackColor = Color.White;
        //            tBox3SS5.BackColor = Color.White;
        //            tBox4SS5.BackColor = Color.White;
        //            tBox5SS5.BackColor = Color.White;
        //            tBox6SS5.BackColor = Color.White;
        //            tBox7SS5.BackColor = Color.White;
        //            tBox8SS5.BackColor = Color.White;
        //            tBox9SS5.BackColor = Color.White;
        //            tBox10SS5.BackColor = Color.White;
        //            break;
        //        case 10:
        //            tBox1SS5.BackColor = Color.Red;
        //            tBox2SS5.BackColor = Color.White;
        //            tBox3SS5.BackColor = Color.White;
        //            tBox4SS5.BackColor = Color.White;
        //            tBox5SS5.BackColor = Color.White;
        //            tBox6SS5.BackColor = Color.White;
        //            tBox7SS5.BackColor = Color.White;
        //            tBox8SS5.BackColor = Color.White;
        //            tBox9SS5.BackColor = Color.White;
        //            tBox10SS5.BackColor = Color.White;
        //            break;
        //        case 20:
        //            tBox1SS5.BackColor = Color.Red;
        //            tBox2SS5.BackColor = Color.Red;
        //            tBox3SS5.BackColor = Color.White;
        //            tBox4SS5.BackColor = Color.White;
        //            tBox5SS5.BackColor = Color.White;
        //            tBox6SS5.BackColor = Color.White;
        //            tBox7SS5.BackColor = Color.White;
        //            tBox8SS5.BackColor = Color.White;
        //            tBox9SS5.BackColor = Color.White;
        //            tBox10SS5.BackColor = Color.White;
        //            break;
        //        case 30:
        //            tBox1SS5.BackColor = Color.Red;
        //            tBox2SS5.BackColor = Color.Red;
        //            tBox3SS5.BackColor = Color.Red;
        //            tBox4SS5.BackColor = Color.White;
        //            tBox5SS5.BackColor = Color.White;
        //            tBox6SS5.BackColor = Color.White;
        //            tBox7SS5.BackColor = Color.White;
        //            tBox8SS5.BackColor = Color.White;
        //            tBox9SS5.BackColor = Color.White;
        //            tBox10SS5.BackColor = Color.White;
        //            break;
        //        case 40:
        //            tBox1SS5.BackColor = Color.Red;
        //            tBox2SS5.BackColor = Color.Red;
        //            tBox3SS5.BackColor = Color.Red;
        //            tBox4SS5.BackColor = Color.Red;
        //            tBox5SS5.BackColor = Color.White;
        //            tBox6SS5.BackColor = Color.White;
        //            tBox7SS5.BackColor = Color.White;
        //            tBox8SS5.BackColor = Color.White;
        //            tBox9SS5.BackColor = Color.White;
        //            tBox10SS5.BackColor = Color.White;
        //            break;
        //        case 50:
        //            tBox1SS5.BackColor = Color.Red;
        //            tBox2SS5.BackColor = Color.Red;
        //            tBox3SS5.BackColor = Color.Red;
        //            tBox4SS5.BackColor = Color.Red;
        //            tBox5SS5.BackColor = Color.Red;
        //            tBox6SS5.BackColor = Color.White;
        //            tBox7SS5.BackColor = Color.White;
        //            tBox8SS5.BackColor = Color.White;
        //            tBox9SS5.BackColor = Color.White;
        //            tBox10SS5.BackColor = Color.White;
        //            break;
        //        case 60:
        //            tBox1SS5.BackColor = Color.Red;
        //            tBox2SS5.BackColor = Color.Red;
        //            tBox3SS5.BackColor = Color.Red;
        //            tBox4SS5.BackColor = Color.Red;
        //            tBox5SS5.BackColor = Color.Red;
        //            tBox6SS5.BackColor = Color.Red;
        //            tBox7SS5.BackColor = Color.White;
        //            tBox8SS5.BackColor = Color.White;
        //            tBox9SS5.BackColor = Color.White;
        //            tBox10SS5.BackColor = Color.White;
        //            break;
        //        case 70:
        //            tBox1SS5.BackColor = Color.Red;
        //            tBox2SS5.BackColor = Color.Red;
        //            tBox3SS5.BackColor = Color.Red;
        //            tBox4SS5.BackColor = Color.Red;
        //            tBox5SS5.BackColor = Color.Red;
        //            tBox6SS5.BackColor = Color.Red;
        //            tBox7SS5.BackColor = Color.Red;
        //            tBox8SS5.BackColor = Color.White;
        //            tBox9SS5.BackColor = Color.White;
        //            tBox10SS5.BackColor = Color.White;
        //            break;
        //        case 80:
        //            tBox1SS5.BackColor = Color.Red;
        //            tBox2SS5.BackColor = Color.Red;
        //            tBox3SS5.BackColor = Color.Red;
        //            tBox4SS5.BackColor = Color.Red;
        //            tBox5SS5.BackColor = Color.Red;
        //            tBox6SS5.BackColor = Color.Red;
        //            tBox7SS5.BackColor = Color.Red;
        //            tBox8SS5.BackColor = Color.Red;
        //            tBox9SS5.BackColor = Color.White;
        //            tBox10SS5.BackColor = Color.White;
        //            break;
        //        case 90:
        //            tBox1SS5.BackColor = Color.Red;
        //            tBox2SS5.BackColor = Color.Red;
        //            tBox3SS5.BackColor = Color.Red;
        //            tBox4SS5.BackColor = Color.Red;
        //            tBox5SS5.BackColor = Color.Red;
        //            tBox6SS5.BackColor = Color.Red;
        //            tBox7SS5.BackColor = Color.Red;
        //            tBox8SS5.BackColor = Color.Red;
        //            tBox9SS5.BackColor = Color.Red;
        //            tBox10SS5.BackColor = Color.White;
        //            break;
        //        case 100:
        //            tBox1SS5.BackColor = Color.Red;
        //            tBox2SS5.BackColor = Color.Red;
        //            tBox3SS5.BackColor = Color.Red;
        //            tBox4SS5.BackColor = Color.Red;
        //            tBox5SS5.BackColor = Color.Red;
        //            tBox6SS5.BackColor = Color.Red;
        //            tBox7SS5.BackColor = Color.Red;
        //            tBox8SS5.BackColor = Color.Red;
        //            tBox9SS5.BackColor = Color.Red;
        //            tBox10SS5.BackColor = Color.Red;
        //            break;
        //    }
        //}

        //private void ShowSS4(object sender, EventArgs e)
        //{
        //    if (Sensor4 < 11)
        //    {
        //        Percent_SS4 = 100;
        //    }
        //    else if (Sensor4 > 49)
        //    {
        //        Percent_SS4 = 0;
        //    }
        //    else
        //    {
        //        Temp = 100 - (Sensor4 - 10) / 0.4;
        //        if (Temp < 10)
        //        {
        //            Percent_SS4 = 0;
        //        }
        //        if ((Temp < 20) && (Temp > 9))
        //        {
        //            Percent_SS4 = 10;
        //        }
        //        if ((Temp < 30) && (Temp > 19))
        //        {
        //            Percent_SS4 = 20;
        //        }
        //        if ((Temp < 40) && (Temp > 29))
        //        {
        //            Percent_SS4 = 30;
        //        }
        //        if ((Temp < 50) && (Temp > 39))
        //        {
        //            Percent_SS4 = 40;
        //        }
        //        if ((Temp < 60) && (Temp > 49))
        //        {
        //            Percent_SS4 = 50;
        //        }
        //        if ((Temp < 70) && (Temp > 59))
        //        {
        //            Percent_SS4 = 60;
        //        }
        //        if ((Temp < 80) && (Temp > 69))
        //        {
        //            Percent_SS4 = 70;
        //        }
        //        if ((Temp < 90) && (Temp > 79))
        //        {
        //            Percent_SS4 = 80;
        //        }
        //        if (Temp > 89)
        //        {
        //            Percent_SS4 = 90;
        //        }
        //    }
        //    switch (Percent_SS4)
        //    {
        //        case 0:
        //            tBox1SS4.BackColor = Color.White;
        //            tBox2SS4.BackColor = Color.White;
        //            tBox3SS4.BackColor = Color.White;
        //            tBox4SS4.BackColor = Color.White;
        //            tBox5SS4.BackColor = Color.White;
        //            tBox6SS4.BackColor = Color.White;
        //            tBox7SS4.BackColor = Color.White;
        //            tBox8SS4.BackColor = Color.White;
        //            tBox9SS4.BackColor = Color.White;
        //            tBox10SS4.BackColor = Color.White;
        //            break;
        //        case 10:
        //            tBox1SS4.BackColor = Color.Red;
        //            tBox2SS4.BackColor = Color.White;
        //            tBox3SS4.BackColor = Color.White;
        //            tBox4SS4.BackColor = Color.White;
        //            tBox5SS4.BackColor = Color.White;
        //            tBox6SS4.BackColor = Color.White;
        //            tBox7SS4.BackColor = Color.White;
        //            tBox8SS4.BackColor = Color.White;
        //            tBox9SS4.BackColor = Color.White;
        //            tBox10SS4.BackColor = Color.White;
        //            break;
        //        case 20:
        //            tBox1SS4.BackColor = Color.Red;
        //            tBox2SS4.BackColor = Color.Red;
        //            tBox3SS4.BackColor = Color.White;
        //            tBox4SS4.BackColor = Color.White;
        //            tBox5SS4.BackColor = Color.White;
        //            tBox6SS4.BackColor = Color.White;
        //            tBox7SS4.BackColor = Color.White;
        //            tBox8SS4.BackColor = Color.White;
        //            tBox9SS4.BackColor = Color.White;
        //            tBox10SS4.BackColor = Color.White;
        //            break;
        //        case 30:
        //            tBox1SS4.BackColor = Color.Red;
        //            tBox2SS4.BackColor = Color.Red;
        //            tBox3SS4.BackColor = Color.Red;
        //            tBox4SS4.BackColor = Color.White;
        //            tBox5SS4.BackColor = Color.White;
        //            tBox6SS4.BackColor = Color.White;
        //            tBox7SS4.BackColor = Color.White;
        //            tBox8SS4.BackColor = Color.White;
        //            tBox9SS4.BackColor = Color.White;
        //            tBox10SS4.BackColor = Color.White;
        //            break;
        //        case 40:
        //            tBox1SS4.BackColor = Color.Red;
        //            tBox2SS4.BackColor = Color.Red;
        //            tBox3SS4.BackColor = Color.Red;
        //            tBox4SS4.BackColor = Color.Red;
        //            tBox5SS4.BackColor = Color.White;
        //            tBox6SS4.BackColor = Color.White;
        //            tBox7SS4.BackColor = Color.White;
        //            tBox8SS4.BackColor = Color.White;
        //            tBox9SS4.BackColor = Color.White;
        //            tBox10SS4.BackColor = Color.White;
        //            break;
        //        case 50:
        //            tBox1SS4.BackColor = Color.Red;
        //            tBox2SS4.BackColor = Color.Red;
        //            tBox3SS4.BackColor = Color.Red;
        //            tBox4SS4.BackColor = Color.Red;
        //            tBox5SS4.BackColor = Color.Red;
        //            tBox6SS4.BackColor = Color.White;
        //            tBox7SS4.BackColor = Color.White;
        //            tBox8SS4.BackColor = Color.White;
        //            tBox9SS4.BackColor = Color.White;
        //            tBox10SS4.BackColor = Color.White;
        //            break;
        //        case 60:
        //            tBox1SS4.BackColor = Color.Red;
        //            tBox2SS4.BackColor = Color.Red;
        //            tBox3SS4.BackColor = Color.Red;
        //            tBox4SS4.BackColor = Color.Red;
        //            tBox5SS4.BackColor = Color.Red;
        //            tBox6SS4.BackColor = Color.Red;
        //            tBox7SS4.BackColor = Color.White;
        //            tBox8SS4.BackColor = Color.White;
        //            tBox9SS4.BackColor = Color.White;
        //            tBox10SS4.BackColor = Color.White;
        //            break;
        //        case 70:
        //            tBox1SS4.BackColor = Color.Red;
        //            tBox2SS4.BackColor = Color.Red;
        //            tBox3SS4.BackColor = Color.Red;
        //            tBox4SS4.BackColor = Color.Red;
        //            tBox5SS4.BackColor = Color.Red;
        //            tBox6SS4.BackColor = Color.Red;
        //            tBox7SS4.BackColor = Color.Red;
        //            tBox8SS4.BackColor = Color.White;
        //            tBox9SS4.BackColor = Color.White;
        //            tBox10SS4.BackColor = Color.White;
        //            break;
        //        case 80:
        //            tBox1SS4.BackColor = Color.Red;
        //            tBox2SS4.BackColor = Color.Red;
        //            tBox3SS4.BackColor = Color.Red;
        //            tBox4SS4.BackColor = Color.Red;
        //            tBox5SS4.BackColor = Color.Red;
        //            tBox6SS4.BackColor = Color.Red;
        //            tBox7SS4.BackColor = Color.Red;
        //            tBox8SS4.BackColor = Color.Red;
        //            tBox9SS4.BackColor = Color.White;
        //            tBox10SS4.BackColor = Color.White;
        //            break;
        //        case 90:
        //            tBox1SS4.BackColor = Color.Red;
        //            tBox2SS4.BackColor = Color.Red;
        //            tBox3SS4.BackColor = Color.Red;
        //            tBox4SS4.BackColor = Color.Red;
        //            tBox5SS4.BackColor = Color.Red;
        //            tBox6SS4.BackColor = Color.Red;
        //            tBox7SS4.BackColor = Color.Red;
        //            tBox8SS4.BackColor = Color.Red;
        //            tBox9SS4.BackColor = Color.Red;
        //            tBox10SS4.BackColor = Color.White;
        //            break;
        //        case 100:
        //            tBox1SS4.BackColor = Color.Red;
        //            tBox2SS4.BackColor = Color.Red;
        //            tBox3SS4.BackColor = Color.Red;
        //            tBox4SS4.BackColor = Color.Red;
        //            tBox5SS4.BackColor = Color.Red;
        //            tBox6SS4.BackColor = Color.Red;
        //            tBox7SS4.BackColor = Color.Red;
        //            tBox8SS4.BackColor = Color.Red;
        //            tBox9SS4.BackColor = Color.Red;
        //            tBox10SS4.BackColor = Color.Red;
        //            break;
        //    }
        //}

        //private void ShowSS3(object sender, EventArgs e)
        //{
        //    if (Sensor3 < 11)
        //    {
        //        Percent_SS3 = 100;
        //    }
        //    else if (Sensor3 > 49)
        //    {
        //        Percent_SS3 = 0;
        //    }
        //    else
        //    {
        //        Temp = 100 - (Sensor3 - 10) / 0.4;
        //        if (Temp < 10)
        //        {
        //            Percent_SS3 = 0;
        //        }
        //        if ((Temp < 20) && (Temp > 9))
        //        {
        //            Percent_SS3 = 10;
        //        }
        //        if ((Temp < 30) && (Temp > 19))
        //        {
        //            Percent_SS3 = 20;
        //        }
        //        if ((Temp < 40) && (Temp > 29))
        //        {
        //            Percent_SS3 = 30;
        //        }
        //        if ((Temp < 50) && (Temp > 39))
        //        {
        //            Percent_SS3 = 40;
        //        }
        //        if ((Temp < 60) && (Temp > 49))
        //        {
        //            Percent_SS3 = 50;
        //        }
        //        if ((Temp < 70) && (Temp > 59))
        //        {
        //            Percent_SS3 = 60;
        //        }
        //        if ((Temp < 80) && (Temp > 69))
        //        {
        //            Percent_SS3 = 70;
        //        }
        //        if ((Temp < 90) && (Temp > 79))
        //        {
        //            Percent_SS3 = 80;
        //        }
        //        if (Temp > 89)
        //        {
        //            Percent_SS3 = 90;
        //        }
        //    }
        //    switch (Percent_SS3)
        //    {
        //        case 0:
        //            tBox1SS3.BackColor = Color.White;
        //            tBox2SS3.BackColor = Color.White;
        //            tBox3SS3.BackColor = Color.White;
        //            tBox4SS3.BackColor = Color.White;
        //            tBox5SS3.BackColor = Color.White;
        //            tBox6SS3.BackColor = Color.White;
        //            tBox7SS3.BackColor = Color.White;
        //            tBox8SS3.BackColor = Color.White;
        //            tBox9SS3.BackColor = Color.White;
        //            tBox10SS3.BackColor = Color.White;
        //            break;
        //        case 10:
        //            tBox1SS3.BackColor = Color.Red;
        //            tBox2SS3.BackColor = Color.White;
        //            tBox3SS3.BackColor = Color.White;
        //            tBox4SS3.BackColor = Color.White;
        //            tBox5SS3.BackColor = Color.White;
        //            tBox6SS3.BackColor = Color.White;
        //            tBox7SS3.BackColor = Color.White;
        //            tBox8SS3.BackColor = Color.White;
        //            tBox9SS3.BackColor = Color.White;
        //            tBox10SS3.BackColor = Color.White;
        //            break;
        //        case 20:
        //            tBox1SS3.BackColor = Color.Red;
        //            tBox2SS3.BackColor = Color.Red;
        //            tBox3SS3.BackColor = Color.White;
        //            tBox4SS3.BackColor = Color.White;
        //            tBox5SS3.BackColor = Color.White;
        //            tBox6SS3.BackColor = Color.White;
        //            tBox7SS3.BackColor = Color.White;
        //            tBox8SS3.BackColor = Color.White;
        //            tBox9SS3.BackColor = Color.White;
        //            tBox10SS3.BackColor = Color.White;
        //            break;
        //        case 30:
        //            tBox1SS3.BackColor = Color.Red;
        //            tBox2SS3.BackColor = Color.Red;
        //            tBox3SS3.BackColor = Color.Red;
        //            tBox4SS3.BackColor = Color.White;
        //            tBox5SS3.BackColor = Color.White;
        //            tBox6SS3.BackColor = Color.White;
        //            tBox7SS3.BackColor = Color.White;
        //            tBox8SS3.BackColor = Color.White;
        //            tBox9SS3.BackColor = Color.White;
        //            tBox10SS3.BackColor = Color.White;
        //            break;
        //        case 40:
        //            tBox1SS3.BackColor = Color.Red;
        //            tBox2SS3.BackColor = Color.Red;
        //            tBox3SS3.BackColor = Color.Red;
        //            tBox4SS3.BackColor = Color.Red;
        //            tBox5SS3.BackColor = Color.White;
        //            tBox6SS3.BackColor = Color.White;
        //            tBox7SS3.BackColor = Color.White;
        //            tBox8SS3.BackColor = Color.White;
        //            tBox9SS3.BackColor = Color.White;
        //            tBox10SS3.BackColor = Color.White;
        //            break;
        //        case 50:
        //            tBox1SS3.BackColor = Color.Red;
        //            tBox2SS3.BackColor = Color.Red;
        //            tBox3SS3.BackColor = Color.Red;
        //            tBox4SS3.BackColor = Color.Red;
        //            tBox5SS3.BackColor = Color.Red;
        //            tBox6SS3.BackColor = Color.White;
        //            tBox7SS3.BackColor = Color.White;
        //            tBox8SS3.BackColor = Color.White;
        //            tBox9SS3.BackColor = Color.White;
        //            tBox10SS3.BackColor = Color.White;
        //            break;
        //        case 60:
        //            tBox1SS3.BackColor = Color.Red;
        //            tBox2SS3.BackColor = Color.Red;
        //            tBox3SS3.BackColor = Color.Red;
        //            tBox4SS3.BackColor = Color.Red;
        //            tBox5SS3.BackColor = Color.Red;
        //            tBox6SS3.BackColor = Color.Red;
        //            tBox7SS3.BackColor = Color.White;
        //            tBox8SS3.BackColor = Color.White;
        //            tBox9SS3.BackColor = Color.White;
        //            tBox10SS3.BackColor = Color.White;
        //            break;
        //        case 70:
        //            tBox1SS3.BackColor = Color.Red;
        //            tBox2SS3.BackColor = Color.Red;
        //            tBox3SS3.BackColor = Color.Red;
        //            tBox4SS3.BackColor = Color.Red;
        //            tBox5SS3.BackColor = Color.Red;
        //            tBox6SS3.BackColor = Color.Red;
        //            tBox7SS3.BackColor = Color.Red;
        //            tBox8SS3.BackColor = Color.White;
        //            tBox9SS3.BackColor = Color.White;
        //            tBox10SS3.BackColor = Color.White;
        //            break;
        //        case 80:
        //            tBox1SS3.BackColor = Color.Red;
        //            tBox2SS3.BackColor = Color.Red;
        //            tBox3SS3.BackColor = Color.Red;
        //            tBox4SS3.BackColor = Color.Red;
        //            tBox5SS3.BackColor = Color.Red;
        //            tBox6SS3.BackColor = Color.Red;
        //            tBox7SS3.BackColor = Color.Red;
        //            tBox8SS3.BackColor = Color.Red;
        //            tBox9SS3.BackColor = Color.White;
        //            tBox10SS3.BackColor = Color.White;
        //            break;
        //        case 90:
        //            tBox1SS3.BackColor = Color.Red;
        //            tBox2SS3.BackColor = Color.Red;
        //            tBox3SS3.BackColor = Color.Red;
        //            tBox4SS3.BackColor = Color.Red;
        //            tBox5SS3.BackColor = Color.Red;
        //            tBox6SS3.BackColor = Color.Red;
        //            tBox7SS3.BackColor = Color.Red;
        //            tBox8SS3.BackColor = Color.Red;
        //            tBox9SS3.BackColor = Color.Red;
        //            tBox10SS3.BackColor = Color.White;
        //            break;
        //        case 100:
        //            tBox1SS3.BackColor = Color.Red;
        //            tBox2SS3.BackColor = Color.Red;
        //            tBox3SS3.BackColor = Color.Red;
        //            tBox4SS3.BackColor = Color.Red;
        //            tBox5SS3.BackColor = Color.Red;
        //            tBox6SS3.BackColor = Color.Red;
        //            tBox7SS3.BackColor = Color.Red;
        //            tBox8SS3.BackColor = Color.Red;
        //            tBox9SS3.BackColor = Color.Red;
        //            tBox10SS3.BackColor = Color.Red;
        //            break;
        //    }
        //}

        //private void ShowSS2(object sender, EventArgs e)
        //{
        //    if (Sensor2 < 11)
        //    {
        //        Percent_SS2 = 100;
        //    }
        //    else if (Sensor2 > 49)
        //    {
        //        Percent_SS2 = 0;
        //    }
        //    else
        //    {
        //        Temp = 100 - (Sensor2 - 10) / 0.4;
        //        if (Temp < 10)
        //        {
        //            Percent_SS2 = 0;
        //        }
        //        if ((Temp < 20) && (Temp > 9))
        //        {
        //            Percent_SS2 = 10;
        //        }
        //        if ((Temp < 30) && (Temp > 19))
        //        {
        //            Percent_SS2 = 20;
        //        }
        //        if ((Temp < 40) && (Temp > 29))
        //        {
        //            Percent_SS2 = 30;
        //        }
        //        if ((Temp < 50) && (Temp > 39))
        //        {
        //            Percent_SS2 = 40;
        //        }
        //        if ((Temp < 60) && (Temp > 49))
        //        {
        //            Percent_SS2 = 50;
        //        }
        //        if ((Temp < 70) && (Temp > 59))
        //        {
        //            Percent_SS2 = 60;
        //        }
        //        if ((Temp < 80) && (Temp > 69))
        //        {
        //            Percent_SS2 = 70;
        //        }
        //        if ((Temp < 90) && (Temp > 79))
        //        {
        //            Percent_SS2 = 80;
        //        }
        //        if (Temp > 89)
        //        {
        //            Percent_SS2 = 90;
        //        }
        //    }
        //    switch (Percent_SS2)
        //    {
        //        case 0:
        //            tBox1SS2.BackColor = Color.White;
        //            tBox2SS2.BackColor = Color.White;
        //            tBox3SS2.BackColor = Color.White;
        //            tBox4SS2.BackColor = Color.White;
        //            tBox5SS2.BackColor = Color.White;
        //            tBox6SS2.BackColor = Color.White;
        //            tBox7SS2.BackColor = Color.White;
        //            tBox8SS2.BackColor = Color.White;
        //            tBox9SS2.BackColor = Color.White;
        //            tBox10SS2.BackColor = Color.White;
        //            break;
        //        case 10:
        //            tBox1SS2.BackColor = Color.Red;
        //            tBox2SS2.BackColor = Color.White;
        //            tBox3SS2.BackColor = Color.White;
        //            tBox4SS2.BackColor = Color.White;
        //            tBox5SS2.BackColor = Color.White;
        //            tBox6SS2.BackColor = Color.White;
        //            tBox7SS2.BackColor = Color.White;
        //            tBox8SS2.BackColor = Color.White;
        //            tBox9SS2.BackColor = Color.White;
        //            tBox10SS2.BackColor = Color.White;
        //            break;
        //        case 20:
        //            tBox1SS2.BackColor = Color.Red;
        //            tBox2SS2.BackColor = Color.Red;
        //            tBox3SS2.BackColor = Color.White;
        //            tBox4SS2.BackColor = Color.White;
        //            tBox5SS2.BackColor = Color.White;
        //            tBox6SS2.BackColor = Color.White;
        //            tBox7SS2.BackColor = Color.White;
        //            tBox8SS2.BackColor = Color.White;
        //            tBox9SS2.BackColor = Color.White;
        //            tBox10SS2.BackColor = Color.White;
        //            break;
        //        case 30:
        //            tBox1SS2.BackColor = Color.Red;
        //            tBox2SS2.BackColor = Color.Red;
        //            tBox3SS2.BackColor = Color.Red;
        //            tBox4SS2.BackColor = Color.White;
        //            tBox5SS2.BackColor = Color.White;
        //            tBox6SS2.BackColor = Color.White;
        //            tBox7SS2.BackColor = Color.White;
        //            tBox8SS2.BackColor = Color.White;
        //            tBox9SS2.BackColor = Color.White;
        //            tBox10SS2.BackColor = Color.White;
        //            break;
        //        case 40:
        //            tBox1SS2.BackColor = Color.Red;
        //            tBox2SS2.BackColor = Color.Red;
        //            tBox3SS2.BackColor = Color.Red;
        //            tBox4SS2.BackColor = Color.Red;
        //            tBox5SS2.BackColor = Color.White;
        //            tBox6SS2.BackColor = Color.White;
        //            tBox7SS2.BackColor = Color.White;
        //            tBox8SS2.BackColor = Color.White;
        //            tBox9SS2.BackColor = Color.White;
        //            tBox10SS2.BackColor = Color.White;
        //            break;
        //        case 50:
        //            tBox1SS2.BackColor = Color.Red;
        //            tBox2SS2.BackColor = Color.Red;
        //            tBox3SS2.BackColor = Color.Red;
        //            tBox4SS2.BackColor = Color.Red;
        //            tBox5SS2.BackColor = Color.Red;
        //            tBox6SS2.BackColor = Color.White;
        //            tBox7SS2.BackColor = Color.White;
        //            tBox8SS2.BackColor = Color.White;
        //            tBox9SS2.BackColor = Color.White;
        //            tBox10SS2.BackColor = Color.White;
        //            break;
        //        case 60:
        //            tBox1SS2.BackColor = Color.Red;
        //            tBox2SS2.BackColor = Color.Red;
        //            tBox3SS2.BackColor = Color.Red;
        //            tBox4SS2.BackColor = Color.Red;
        //            tBox5SS2.BackColor = Color.Red;
        //            tBox6SS2.BackColor = Color.Red;
        //            tBox7SS2.BackColor = Color.White;
        //            tBox8SS2.BackColor = Color.White;
        //            tBox9SS2.BackColor = Color.White;
        //            tBox10SS2.BackColor = Color.White;
        //            break;
        //        case 70:
        //            tBox1SS2.BackColor = Color.Red;
        //            tBox2SS2.BackColor = Color.Red;
        //            tBox3SS2.BackColor = Color.Red;
        //            tBox4SS2.BackColor = Color.Red;
        //            tBox5SS2.BackColor = Color.Red;
        //            tBox6SS2.BackColor = Color.Red;
        //            tBox7SS2.BackColor = Color.Red;
        //            tBox8SS2.BackColor = Color.White;
        //            tBox9SS2.BackColor = Color.White;
        //            tBox10SS2.BackColor = Color.White;
        //            break;
        //        case 80:
        //            tBox1SS2.BackColor = Color.Red;
        //            tBox2SS2.BackColor = Color.Red;
        //            tBox3SS2.BackColor = Color.Red;
        //            tBox4SS2.BackColor = Color.Red;
        //            tBox5SS2.BackColor = Color.Red;
        //            tBox6SS2.BackColor = Color.Red;
        //            tBox7SS2.BackColor = Color.Red;
        //            tBox8SS2.BackColor = Color.Red;
        //            tBox9SS2.BackColor = Color.White;
        //            tBox10SS2.BackColor = Color.White;
        //            break;
        //        case 90:
        //            tBox1SS2.BackColor = Color.Red;
        //            tBox2SS2.BackColor = Color.Red;
        //            tBox3SS2.BackColor = Color.Red;
        //            tBox4SS2.BackColor = Color.Red;
        //            tBox5SS2.BackColor = Color.Red;
        //            tBox6SS2.BackColor = Color.Red;
        //            tBox7SS2.BackColor = Color.Red;
        //            tBox8SS2.BackColor = Color.Red;
        //            tBox9SS2.BackColor = Color.Red;
        //            tBox10SS2.BackColor = Color.White;
        //            break;
        //        case 100:
        //            tBox1SS2.BackColor = Color.Red;
        //            tBox2SS2.BackColor = Color.Red;
        //            tBox3SS2.BackColor = Color.Red;
        //            tBox4SS2.BackColor = Color.Red;
        //            tBox5SS2.BackColor = Color.Red;
        //            tBox6SS2.BackColor = Color.Red;
        //            tBox7SS2.BackColor = Color.Red;
        //            tBox8SS2.BackColor = Color.Red;
        //            tBox9SS2.BackColor = Color.Red;
        //            tBox10SS2.BackColor = Color.Red;
        //            break;
        //    }
        //}

        //private void ShowSS1(object sender, EventArgs e)
        //{
        //    if (Sensor1 < 11)
        //    {
        //        Percent_SS1 = 100;
        //    }
        //    else if (Sensor1 > 49)
        //    {
        //        Percent_SS1 = 0;
        //    }
        //    else
        //    {
        //        Temp = 100 - (Sensor1 - 10) / 0.4;
        //        if (Temp < 10)
        //        {
        //            Percent_SS1 = 0;
        //        }
        //        if ((Temp < 20) && (Temp > 9))
        //        {
        //            Percent_SS1 = 10;
        //        }
        //        if ((Temp < 30) && (Temp > 19))
        //        {
        //            Percent_SS1 = 20;
        //        }
        //        if ((Temp < 40) && (Temp > 29))
        //        {
        //            Percent_SS1 = 30;
        //        }
        //        if ((Temp < 50) && (Temp > 39))
        //        {
        //            Percent_SS1 = 40;
        //        }
        //        if ((Temp < 60) && (Temp > 49))
        //        {
        //            Percent_SS1 = 50;
        //        }
        //        if ((Temp < 70) && (Temp > 59))
        //        {
        //            Percent_SS1 = 60;
        //        }
        //        if ((Temp < 80) && (Temp > 69))
        //        {
        //            Percent_SS1 = 70;
        //        }
        //        if ((Temp < 90) && (Temp > 79))
        //        {
        //            Percent_SS1 = 80;
        //        }
        //        if (Temp > 89)
        //        {
        //            Percent_SS1 = 90;
        //        }
        //    }
        //    switch (Percent_SS1)
        //    {
        //        case 0:
        //            tBox1SS1.BackColor = Color.White;
        //            tBox2SS1.BackColor = Color.White;
        //            tBox3SS1.BackColor = Color.White;
        //            tBox4SS1.BackColor = Color.White;
        //            tBox5SS1.BackColor = Color.White;
        //            tBox6SS1.BackColor = Color.White;
        //            tBox7SS1.BackColor = Color.White;
        //            tBox8SS1.BackColor = Color.White;
        //            tBox9SS1.BackColor = Color.White;
        //            tBox10SS1.BackColor = Color.White;
        //            break;
        //        case 10:
        //            tBox1SS1.BackColor = Color.Red;
        //            tBox2SS1.BackColor = Color.White;
        //            tBox3SS1.BackColor = Color.White;
        //            tBox4SS1.BackColor = Color.White;
        //            tBox5SS1.BackColor = Color.White;
        //            tBox6SS1.BackColor = Color.White;
        //            tBox7SS1.BackColor = Color.White;
        //            tBox8SS1.BackColor = Color.White;
        //            tBox9SS1.BackColor = Color.White;
        //            tBox10SS1.BackColor = Color.White;
        //            break;
        //        case 20:
        //            tBox1SS1.BackColor = Color.Red;
        //            tBox2SS1.BackColor = Color.Red;
        //            tBox3SS1.BackColor = Color.White;
        //            tBox4SS1.BackColor = Color.White;
        //            tBox5SS1.BackColor = Color.White;
        //            tBox6SS1.BackColor = Color.White;
        //            tBox7SS1.BackColor = Color.White;
        //            tBox8SS1.BackColor = Color.White;
        //            tBox9SS1.BackColor = Color.White;
        //            tBox10SS1.BackColor = Color.White;
        //            break;
        //        case 30:
        //            tBox1SS1.BackColor = Color.Red;
        //            tBox2SS1.BackColor = Color.Red;
        //            tBox3SS1.BackColor = Color.Red;
        //            tBox4SS1.BackColor = Color.White;
        //            tBox5SS1.BackColor = Color.White;
        //            tBox6SS1.BackColor = Color.White;
        //            tBox7SS1.BackColor = Color.White;
        //            tBox8SS1.BackColor = Color.White;
        //            tBox9SS1.BackColor = Color.White;
        //            tBox10SS1.BackColor = Color.White;
        //            break;
        //        case 40:
        //            tBox1SS1.BackColor = Color.Red;
        //            tBox2SS1.BackColor = Color.Red;
        //            tBox3SS1.BackColor = Color.Red;
        //            tBox4SS1.BackColor = Color.Red;
        //            tBox5SS1.BackColor = Color.White;
        //            tBox6SS1.BackColor = Color.White;
        //            tBox7SS1.BackColor = Color.White;
        //            tBox8SS1.BackColor = Color.White;
        //            tBox9SS1.BackColor = Color.White;
        //            tBox10SS1.BackColor = Color.White;
        //            break;
        //        case 50:
        //            tBox1SS1.BackColor = Color.Red;
        //            tBox2SS1.BackColor = Color.Red;
        //            tBox3SS1.BackColor = Color.Red;
        //            tBox4SS1.BackColor = Color.Red;
        //            tBox5SS1.BackColor = Color.Red;
        //            tBox6SS1.BackColor = Color.White;
        //            tBox7SS1.BackColor = Color.White;
        //            tBox8SS1.BackColor = Color.White;
        //            tBox9SS1.BackColor = Color.White;
        //            tBox10SS1.BackColor = Color.White;
        //            break;
        //        case 60:
        //            tBox1SS1.BackColor = Color.Red;
        //            tBox2SS1.BackColor = Color.Red;
        //            tBox3SS1.BackColor = Color.Red;
        //            tBox4SS1.BackColor = Color.Red;
        //            tBox5SS1.BackColor = Color.Red;
        //            tBox6SS1.BackColor = Color.Red;
        //            tBox7SS1.BackColor = Color.White;
        //            tBox8SS1.BackColor = Color.White;
        //            tBox9SS1.BackColor = Color.White;
        //            tBox10SS1.BackColor = Color.White;
        //            break;
        //        case 70:
        //            tBox1SS1.BackColor = Color.Red;
        //            tBox2SS1.BackColor = Color.Red;
        //            tBox3SS1.BackColor = Color.Red;
        //            tBox4SS1.BackColor = Color.Red;
        //            tBox5SS1.BackColor = Color.Red;
        //            tBox6SS1.BackColor = Color.Red;
        //            tBox7SS1.BackColor = Color.Red;
        //            tBox8SS1.BackColor = Color.White;
        //            tBox9SS1.BackColor = Color.White;
        //            tBox10SS1.BackColor = Color.White;
        //            break;
        //        case 80:
        //            tBox1SS1.BackColor = Color.Red;
        //            tBox2SS1.BackColor = Color.Red;
        //            tBox3SS1.BackColor = Color.Red;
        //            tBox4SS1.BackColor = Color.Red;
        //            tBox5SS1.BackColor = Color.Red;
        //            tBox6SS1.BackColor = Color.Red;
        //            tBox7SS1.BackColor = Color.Red;
        //            tBox8SS1.BackColor = Color.Red;
        //            tBox9SS1.BackColor = Color.White;
        //            tBox10SS1.BackColor = Color.White;
        //            break;
        //        case 90:
        //            tBox1SS1.BackColor = Color.Red;
        //            tBox2SS1.BackColor = Color.Red;
        //            tBox3SS1.BackColor = Color.Red;
        //            tBox4SS1.BackColor = Color.Red;
        //            tBox5SS1.BackColor = Color.Red;
        //            tBox6SS1.BackColor = Color.Red;
        //            tBox7SS1.BackColor = Color.Red;
        //            tBox8SS1.BackColor = Color.Red;
        //            tBox9SS1.BackColor = Color.Red;
        //            tBox10SS1.BackColor = Color.White;
        //            break;
        //        case 100:
        //            tBox1SS1.BackColor = Color.Red;
        //            tBox2SS1.BackColor = Color.Red;
        //            tBox3SS1.BackColor = Color.Red;
        //            tBox4SS1.BackColor = Color.Red;
        //            tBox5SS1.BackColor = Color.Red;
        //            tBox6SS1.BackColor = Color.Red;
        //            tBox7SS1.BackColor = Color.Red;
        //            tBox8SS1.BackColor = Color.Red;
        //            tBox9SS1.BackColor = Color.Red;
        //            tBox10SS1.BackColor = Color.Red;
        //            break;
        //    }
        //}


    }
}
