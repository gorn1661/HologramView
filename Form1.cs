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
            cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += Cam_NewFrame;cam.Start();
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
