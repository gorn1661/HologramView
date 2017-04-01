using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace HologramViewOnCameras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        private VideoCaptureDevice cam1;
        private VideoCaptureDevice cam2;
        private VideoCaptureDevice cam3;

        String[] s;

        private void Form1_Load(object sender, EventArgs e)
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo fi in webcam)
                comboBox1.Items.Add(fi.Name);
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Items.Count != 4)
            {
                cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
                cam.NewFrame += Cam_NewFrame;
                cam.Start();
            }
           
            if(comboBox1.Items.Count == 4)
            {
                cam = new VideoCaptureDevice(webcam[0].MonikerString);
                cam.NewFrame += Cam_NewFrame;
                cam1 = new VideoCaptureDevice(webcam[1].MonikerString);
                cam1.NewFrame += Cam1_NewFrame;
                cam2 = new VideoCaptureDevice(webcam[2].MonikerString);
                cam2.NewFrame += Cam2_NewFrame;
                cam3 = new VideoCaptureDevice(webcam[3].MonikerString);
                cam3.NewFrame += Cam3_NewFrame;
                cam.Start();
                cam1.Start();
                cam2.Start();
                cam3.Start();
            }
        }

        private void Cam3_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox4.Image = bitmap;
        }

        private void Cam2_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox3.Image = bitmap;
        }

        private void Cam1_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox2.Image = bitmap;
        }

        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cam.IsRunning)
            {
                cam.Stop();
            }
        }
    }
}
