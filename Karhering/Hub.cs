using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System;
using System.Windows.Forms;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using System.Data.Entity;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.Logging;

namespace Karhering
{
    public partial class Hub : Form
    {
        public Hub()
        {
            InitializeComponent();
            label6.Text = DataBank.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = CzechTuristMapProvider.Instance;
            gMapControl1.CacheLocation = Application.StartupPath + @"\maps\OSMCache";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.MouseWheelZoomEnabled = true;
            gMapControl1.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            gMapControl1.MinZoom = 10;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 15;
            gMapControl1.Position = new PointLatLng(59.9386, 30.3141);
            gMapControl1.ShowCenter = false;
            Createmarker();
        }

        private void Createmarker()
        {
            GMapOverlay ListOfCar = new GMapOverlay("Car");

            // Загружаем изображение
            Bitmap originalImage = new Bitmap(@"C:\Users\Павел\source\repos\Karhering\Karhering\Icon\car.png");

            // Уменьшаем размер изображения (например, до 50% от оригинала)
            int newWidth = (int)(originalImage.Width * 0.03);
            int newHeight = (int)(originalImage.Height * 0.03);
            Bitmap resizedImage = new Bitmap(originalImage, new Size(newWidth, newHeight));

            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(59.9386, 30.3142), resizedImage);
            marker.ToolTip = new GMapRoundedToolTip(marker);
            marker.ToolTipText = "Машина";
            ListOfCar.Markers.Add(marker);


            GMarkerGoogle marker2 = new GMarkerGoogle(new PointLatLng(60.0565, 30.4381), resizedImage);
            marker2.ToolTip = new GMapRoundedToolTip(marker2);
            marker2.ToolTipText = "Машина";
            ListOfCar.Markers.Add(marker2);

            GMarkerGoogle marker3 = new GMarkerGoogle(new PointLatLng(60.017090, 30.375103), resizedImage);
            marker3.ToolTip = new GMapRoundedToolTip(marker3);
            marker3.ToolTipText = "Машина";
            ListOfCar.Markers.Add(marker3);

            GMarkerGoogle marker4 = new GMarkerGoogle(new PointLatLng(60.023986, 30.229229), resizedImage);
            marker4.ToolTip = new GMapRoundedToolTip(marker4);
            marker4.ToolTipText = "Машина";
            ListOfCar.Markers.Add(marker4);

            GMarkerGoogle marker5 = new GMarkerGoogle(new PointLatLng(59.986873, 30.288179), resizedImage);
            marker5.ToolTip = new GMapRoundedToolTip(marker5);
            marker5.ToolTipText = "Машина";
            ListOfCar.Markers.Add(marker5);

            GMarkerGoogle marker6 = new GMarkerGoogle(new PointLatLng(59.959662, 30.344648), resizedImage);
            marker6.ToolTip = new GMapRoundedToolTip(marker6);
            marker6.ToolTipText = "Машина";
            ListOfCar.Markers.Add(marker6);

            GMarkerGoogle marker7 = new GMarkerGoogle(new PointLatLng(59.902714, 30.322929), resizedImage);
            marker7.ToolTip = new GMapRoundedToolTip(marker7);
            marker7.ToolTipText = "Машина";
            ListOfCar.Markers.Add(marker7);

            GMarkerGoogle marker8 = new GMarkerGoogle(new PointLatLng(59.797313, 30.275145), resizedImage);
            marker8.ToolTip = new GMapRoundedToolTip(marker8);
            marker8.ToolTipText = "Машина";
            ListOfCar.Markers.Add(marker8);

            GMarkerGoogle marker9 = new GMarkerGoogle(new PointLatLng(59.958434, 30.439293), resizedImage);
            marker9.ToolTip = new GMapRoundedToolTip(marker9);
            marker9.ToolTipText = "Машина";
            ListOfCar.Markers.Add(marker9);

            GMarkerGoogle marker10 = new GMarkerGoogle(new PointLatLng(59.938397, 30.262207), resizedImage);
            marker10.ToolTip = new GMapRoundedToolTip(marker10);
            marker10.ToolTipText = "Машина";
            ListOfCar.Markers.Add(marker10);

            GMarkerGoogle marker11 = new GMarkerGoogle(new PointLatLng(60.023826, 30.228222), GMarkerGoogleType.red_small);
            marker11.ToolTip = new GMapRoundedToolTip(marker11);
            marker11.ToolTipText = "Мое место положение";
            ListOfCar.Markers.Add(marker11);

            gMapControl1.Overlays.Add(ListOfCar);
        }
        private void label6_Click(object sender, EventArgs e)
        {
            label6.Text = DataBank.Text;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Auto log1 = new Auto();
            this.Hide();
            log1.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Poderjka log2 = new Poderjka();
            this.Hide();
            log2.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Nastroiki log = new Nastroiki();
            this.Hide();
            log.Show();
        }
    }
}