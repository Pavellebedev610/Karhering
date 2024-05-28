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
using System.Diagnostics.Eventing.Reader;
using System.Data.SqlClient;
using System.Data;
using Karhering.Repository;
using System.Reflection.Emit;
using System.Management;
using System.Data.Entity.Core.Mapping;
using System.Drawing;
using System.Text;


namespace Karhering
{
    public partial class Hub : Form
    {
        //private Timer timer;
        public Client ClientInfo { get; set; }
        public Hub()
        {
            InitializeComponent();
            label6.Text = DataBank.Text;
            Load += new EventHandler(Hub_Load);
        }

        System.Timers.Timer Timer;
        System.Timers.Timer Timer2;
        int c, m, s;
        int d = 60;
        int v = 14;

        private Car curentCar;


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GoogleMapProvider.Instance;
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

        private GMapOverlay ListOfCar; // Объявляем переменную для оверлея ListOfCar на уровне класса

        private void Createmarker()
        {
            if (ListOfCar != null)
            {
                // Удаляем предыдущие маркеры перед созданием новых
                gMapControl1.Overlays.Remove(ListOfCar);
            }

            ListOfCar = new GMapOverlay("Car");

            Bitmap originalImage = new Bitmap(@"C:\Users\Павел\source\repos\Karhering\Karhering\Icon\car.png");
            int newWidth = (int)(originalImage.Width * 0.03);
            int newHeight = (int)(originalImage.Height * 0.03);
            Bitmap resizedImage = new Bitmap(originalImage, new Size(newWidth, newHeight));

            var repos = new CarRepos();
            var cars = repos.GetCars();

            foreach (var coordinat in cars)
            {
                var marker = new CarMarker(new PointLatLng((double)coordinat.cordinat_x, (double)coordinat.cordinat_y), resizedImage);
                marker.ToolTip = new GMapRoundedToolTip(marker);
                marker.CarInfo = coordinat;

                ListOfCar.Markers.Add(marker);
            }

            GMarkerGoogle marker11 = new GMarkerGoogle(new PointLatLng(60.023826, 30.228222), GMarkerGoogleType.red_small);
            marker11.ToolTip = new GMapRoundedToolTip(marker11);
            marker11.ToolTipText = "Мое место положение";
            ListOfCar.Markers.Add(marker11);

            gMapControl1.Overlays.Add(ListOfCar);
            gMapControl1.OnMarkerClick += GMapControl1_OnMarkerClick;
            gMapControl1.OnMapClick += GMapControl1_OnMapClick;
        }



        public class CarMarker : GMarkerGoogle
        {
            public CarMarker(PointLatLng p, Bitmap bitmap) : base(p, bitmap)
            {

            }
            public Car CarInfo { get; set; }

            public Bitmap image { get; set; }
        }

        private void GMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            CarInfo.Visible = false;
            if (item is not CarMarker car)
            {
                return;

            }
            CarInfo.Visible = true;
            CarNumber.Text = car.CarInfo.marka_auto;
            label30.Text = car.CarInfo.model_auto;
            label26.Text = car.CarInfo.toplivo;
            label24.Text = car.CarInfo.probeg;
            label22.Text = car.CarInfo.number;
            GAS.Text = car.CarInfo.toplivo;
            Probeg.Text = car.CarInfo.probeg;
            Number.Text = car.CarInfo.number;
            label17.Text = car.CarInfo.number;
            GAS2.Text = car.CarInfo.toplivo;
            label32.Text = car.CarInfo.number;
            CarImage.Image = car.image;
            CarImage2.Image = car.image;
            CarImage3.Image = car.image;
            CarImage4.Image = car.image;
            CarName.Text = car.CarInfo.marka_auto;
            label33.Text = car.CarInfo.model_auto;
            label27.Text = car.CarInfo.model_auto;
            label34.Text = car.CarInfo.marka_auto;

            curentCar = car.CarInfo;
            string photoPath = Encoding.UTF8.GetString(car.CarInfo.PhotoCar);
            LoadCarPhoto(photoPath, CarImage);
            LoadCarPhoto(photoPath, CarImage2);
            LoadCarPhoto(photoPath, CarImage3);
            LoadCarPhoto(photoPath, CarImage4);
        }
        private void LoadCarPhoto(string photoPath, PictureBox pictureBox)
        {
            try
            {

                // Загрузка фотографии машины из указанного пути и отображение ее в PictureBox
                using (MemoryStream ms = new MemoryStream(curentCar.PhotoCar))
                {
                    CarImage.Image = Image.FromStream(ms);
                    CarImage2.Image = Image.FromStream(ms);
                    CarImage3.Image = Image.FromStream(ms);
                    CarImage4.Image = Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок, если фотография не может быть загружена
                MessageBox.Show($"Ошибка загрузки фотографии: {ex.Message}");
            }
        }
        private void GMapControl1_OnMapClick(PointLatLng pointClick, MouseEventArgs e)
        {
            CarInfo.Visible = false;

            panel1.Visible = false;
            pictureBox6.Visible = true;
            curentCar = null;
        }

        private void label6_Click(object sender, EventArgs e)
        {

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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Bonus log = new Bonus();
            this.Hide();
            log.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CarImage_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            CarInfo.Visible = false;
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            Minutes.Visible = !Minutes.Visible;
            hidePanels();
            Minutes.Visible = true;


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void CarInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void time_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            Auto log = new Auto();
            this.Hide();
            log.Show();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        public void hidePanels()
        {
            panel1.Visible = false;
            Minutes.Visible = false;
            CarInfo.Visible = false;
            ArendaBron.Visible = false;
            FinalPrice.Visible = false;
            Arenda.Visible = false;


        }

        private void Hub_Load(object sender, EventArgs e)
        {
            hidePanels();
            ojid.Visible = false;
            ButtonGo.Visible = false;
            label15.Text = DateTime.Now.ToString("dd.MM.yyyy, HH.mm");



        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
            hidePanels();
            panel1.Visible = true;
            pictureBox6.Visible = false;
        }

        private void none(object sender, EventArgs e)
        {

        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            hidePanels();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Arenda.Visible = !Arenda.Visible;
            hidePanels();
            Arenda.Visible = true;

            Timer = new System.Timers.Timer();
            Timer.Interval = 1000;
            Timer.Elapsed += timer1_Tick;
            Timer.Start();


            string querystring = $@"INSERT INTO [dbo].[Arenda]
           ([beginning_time]
           ,[end_time]
           ,[Travel_time]
           ,[car_id]
           ,[id_client])
     VALUES
           (@beginning_time
           ,@end_time
           ,@Travel_time
           ,@car_id
           ,@id_client)";

            try
            {
                Baza baza = new Baza();
                SqlCommand command = new SqlCommand(querystring, baza.getConnection());

                command.Parameters.AddWithValue("beginning_time", TimeSpan.FromSeconds(1));
                command.Parameters.AddWithValue("end_time", TimeSpan.FromSeconds(1));
                command.Parameters.AddWithValue("Travel_time", TimeSpan.FromSeconds(1));
                command.Parameters.AddWithValue("car_id", curentCar.id_car);
                command.Parameters.AddWithValue("id_client", ClientInfo.id_polz);
                baza.openConnection();
                command.ExecuteNonQuery();
                baza.closeConnection();
            }
            catch (Exception ex)
            {
            }

        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            ojid.Visible = !ojid.Visible;
            go.Visible = false;
            ojid.Visible = true;

            ButtonOjid.Visible = !ButtonOjid.Visible;
            ButtonGo.Visible = true;
            ButtonOjid.Visible = false;

        }

        private void ButtonGo_Click(object sender, EventArgs e)
        {
            go.Visible = !go.Visible;
            ojid.Visible = false;
            go.Visible = true;

            ButtonGo.Visible = !ButtonGo.Visible;
            ButtonOjid.Visible = true;
            ButtonGo.Visible = false;


        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            ArendaBron.Visible = !ArendaBron.Visible;
            hidePanels();
            ArendaBron.Visible = true;

            Timer2 = new System.Timers.Timer();
            Timer2.Interval = 1000;
            Timer2.Elapsed += timer4_Tick;
            Timer2.Start();

        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            Finish.Visible = !Finish.Visible;
            Finish.Visible = true;
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            Finish.Visible = false;
        }

        private void guna2Button14_Click_1(object sender, EventArgs e)
        {

            FinalPrice.Visible = !FinalPrice.Visible;
            hidePanels();
            FinalPrice.Visible = true;
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            hidePanels();
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            Trips log = new Trips();
            this.Hide();
            log.Show();
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            CreateCar log = new CreateCar();
            this.Hide();
            log.Show();

        }

        private void panel2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {


        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                s = s + 1;
                if (s == 60)
                {
                    m = m + 01;
                    s = 00;
                }

                if (m == 60)
                {
                    c = c + 01;
                    m = 00; s = 00;
                }
                ArendaTime.Text = c + ":" + m + ":" + s;


            }

            ));
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                d = d - 01;
                if (d == 00)
                {
                    v = v - 01;
                    d = 59;
                }

                label36.Text = v + ":" + d;


            }

                        ));
        }

    }
}
