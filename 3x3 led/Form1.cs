using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using AForge;
using AForge.Imaging.Filters;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Math.Geometry;
using System.IO.Ports;
//Remove ambiguousness between AForge.Image and System.Drawing.Image
using Point = System.Drawing.Point; //Remove ambiguousness between AForge.Point and System.Drawing.Point
using System.Data;
using System.Linq;

namespace _3x3_led
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection VideoCapTureDevices;
        private VideoCaptureDevice Finalvideo;
        SerialPort ardino = new SerialPort();
        public Form1()
        {
            InitializeComponent();
        }
        int R;
        int G;
        int B;
        private void Form1_Load(object sender, EventArgs e)
        {
            VideoCapTureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCapTureDevices)
            {

                comboBox1.Items.Add(VideoCaptureDevice.Name);

            }

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Finalvideo = new VideoCaptureDevice(VideoCapTureDevices[comboBox1.SelectedIndex].MonikerString);
            Finalvideo.NewFrame += new NewFrameEventHandler(Finalvideo_NewFrame);
            Finalvideo.DesiredFrameRate = 20;//saniyede kaç görüntü alsın istiyorsanız. FPS
            Finalvideo.DesiredFrameSize = new Size(330, 300);//görüntü boyutları
            Finalvideo.Start();
        }
        void Finalvideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {

            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            Bitmap image1 = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = image;


            if (rdiobtnKirmizi.Checked)
            {

                // create filter
                EuclideanColorFiltering filter = new EuclideanColorFiltering();
                // set center colol and radius
                filter.CenterColor = new RGB(Color.FromArgb(215, 0, 0));
                filter.Radius = 100;
                // apply the filter
                filter.ApplyInPlace(image1);


                nesnebul(image1);

            }

            if (rdiobtnMavi.Checked)
            {

                // create filter
                EuclideanColorFiltering filter = new EuclideanColorFiltering();
                // set center color and radius
                filter.CenterColor = new RGB(Color.FromArgb(30, 144, 255));
                filter.Radius = 100;
                // apply the filter
                filter.ApplyInPlace(image1);

                nesnebul(image1);

            }
            if (rdiobtnYesil.Checked)
            {

                // create filter
                EuclideanColorFiltering filter = new EuclideanColorFiltering();
                // set center color and radius
                filter.CenterColor = new RGB(Color.FromArgb(0, 215, 0));
                filter.Radius = 100;
                // apply the filter
                filter.ApplyInPlace(image1);

                nesnebul(image1);



            }


            if (rdbtnElleBelirleme.Checked)
            {

                // create filter
                EuclideanColorFiltering filter = new EuclideanColorFiltering();
                // set center colol and radius
                filter.CenterColor = new RGB(Color.FromArgb(R, G, B));
                filter.Radius = 100;
                // apply the filter
                filter.ApplyInPlace(image1);

                nesnebul(image1);

            }


        }

        public void nesnebul(Bitmap image)
        {
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.MinWidth = 5;
            blobCounter.MinHeight = 5;
            blobCounter.FilterBlobs = true;
            blobCounter.ObjectsOrder = ObjectsOrder.Size;
            BitmapData objectsData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);
            Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            UnmanagedImage grayImage = grayscaleFilter.Apply(new UnmanagedImage(objectsData));
            image.UnlockBits(objectsData);


            blobCounter.ProcessImage(image);
            Rectangle[] rects = blobCounter.GetObjectsRectangles();
            Blob[] blobs = blobCounter.GetObjectsInformation();
            pictureBox2.Image = image;

            foreach (Rectangle recs in rects)
            {
                if (rects.Length > 0)
                {
                    Rectangle objectRect = rects[0];
                    //Graphics g = Graphics.FromImage(image);
                    Graphics g = pictureBox1.CreateGraphics();
                    using (Pen pen = new Pen(Color.FromArgb(252, 3, 26), 2))
                    {
                        g.DrawRectangle(pen, objectRect);
                    }
                    //Cizdirilen Dikdörtgenin Koordinatlari aliniyor.
                    int objectX = objectRect.X + (objectRect.Width / 2);
                    int objectY = objectRect.Y + (objectRect.Height / 2);
                    //  g.DrawString(objectX.ToString() + "X" + objectY.ToString(), new Font("Arial", 12), Brushes.Red, new System.Drawing.Point(250, 1));

                    g.Dispose();

                    if (objectX <= 110 && objectY <= 100)
                    {
                        ardino.Write("1");
                    }
                    else if (objectX <= 220 && objectX > 110 && objectY <= 100)
                    {
                        ardino.Write("2");
                    }
                    else if (objectX > 220 && objectY <= 100)
                    {
                        ardino.Write("3");
                    }
                    else if (objectX <= 110 && objectY > 100 && objectY <= 200)
                    {
                        ardino.Write("4");
                    }
                    else if (objectX <= 220 && objectX > 110 && objectY > 100 && objectY <= 200)
                    {
                        ardino.Write("5");
                    }
                    else if (objectX > 220 && objectY > 100 && objectY <= 200)
                    {
                        ardino.Write("6");
                    }
                    else if (objectX <= 110 && objectY > 200)
                    {
                        ardino.Write("7");
                    }
                    else if (objectX <= 220 && objectX > 110 && objectY > 200)
                    {
                        ardino.Write("8");
                    }
                    else if (objectX > 220 && objectY > 200)
                    {
                        ardino.Write("9");
                    }
                }


            }
        }

            private void baglan_Click(object sender, EventArgs e)
        {

            try
            {
                String portName = comboBox2.Text;
                ardino.PortName = portName;
                ardino.BaudRate = 9600;
                ardino.Open();
                toolStripLabel1.Text = "bağlandı";
            }
            catch (Exception)
            {

                toolStripLabel1.Text = " Porta bağlanmadı ,uygun portu seçin";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (Finalvideo.IsRunning)
            {
                Finalvideo.Stop();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Finalvideo.IsRunning)
            {
                Finalvideo.Stop();

            }

            Application.Exit();
        }

        private void bagkes_Click(object sender, EventArgs e)
        {
            try
            {
                ardino.Close();
                toolStripLabel1.Text = "Port bağlantısı kesildi ";
            }
            catch (Exception)
            {

                toolStripLabel1.Text = "İlk önce bağlan sonra bağlantıyı kes";
            }

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            G = trackBar2.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            R = trackBar1.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            B = trackBar3.Value;
        }
    }
}
