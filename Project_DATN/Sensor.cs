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
    public partial class Sensor : Form
    {

        int count = 0;
        double sensor1, sensor2, sensor3, sensor4, sensor5;

        private void Sensor_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        public Sensor()
        {
            InitializeComponent();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if(serialPort1.IsOpen)
            //{
                if(count % 200 == 0)
                {
                    count++;
                    chart1.Series["Sensor1"].Points.Clear();
                    chart1.Series["Sensor2"].Points.Clear();
                    chart1.Series["Sensor3"].Points.Clear();
                    chart1.Series["Sensor4"].Points.Clear();
                    chart1.Series["Sensor5"].Points.Clear();
                    chart1.Series["Sensor1"].Points.AddXY(count, sensor1);
                    chart1.Series["Sensor2"].Points.AddXY(count, sensor2);
                    chart1.Series["Sensor3"].Points.AddXY(count, sensor3);
                    chart1.Series["Sensor4"].Points.AddXY(count, sensor4);
                    chart1.Series["Sensor5"].Points.AddXY(count, sensor5);
                }    
                else
                {
                    count++;
                    chart1.Series["Sensor1"].Points.AddXY(count, sensor1);
                    chart1.Series["Sensor2"].Points.AddXY(count, sensor2);
                    chart1.Series["Sensor3"].Points.AddXY(count, sensor3);
                    chart1.Series["Sensor4"].Points.AddXY(count, sensor4);
                    chart1.Series["Sensor5"].Points.AddXY(count, sensor5);
                }    
            //}    
        }
    }
}
