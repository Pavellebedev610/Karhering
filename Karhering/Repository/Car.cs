using System.Data.Entity;
namespace Karhering.Repository
  
{
    public class Car
    {
        public int id_car { get; set; }
        public string marka_auto { get; set; }
        public string model_auto { get; set; }
        public string number { get; set; }
        public string god_vipuska { get; set; }
        public string probeg { get; set; }
        public string toplivo { get; set; }
        public double cordinat_x { get; set; }
        public double cordinat_y { get; set; }
        public required byte[] PhotoCar { get; set; }

    }
    public class Client
    {
        public object id_polz { get; internal set; }
        public string FIO { get;  set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string number_prav { get; set; }
        public string telefon { get; set; }

        public string rating { get; set; }
    }
}
