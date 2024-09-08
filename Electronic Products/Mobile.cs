using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Webapp_Lagersystem_Intervju
{
    public class Mobile : Electronic_Products, IProduct
    {
        internal string Battery;
        internal int GB;
        internal string Chargertype;
        public List<Mobile> listMobiles = new List<Mobile>();
        public Mobile(string name, double height, double width, double depth, double weight, int releaseyear, string color, double inches, string resolution, string processor,
            string waterproof, string battery, int stock, string hdr, string chargertype, string hz, int gb, int itemnumber)
        {
            Name = name; 
            Height = height; 
            Width = width;
            Depth = depth;
            Weight = weight;
            ReleaseYear = releaseyear;
            Color = color;
            Inches = inches;
            Resolution = resolution;
            Processor = processor;
            Waterproof = waterproof;
            Battery = battery;
            Stock = stock;
            HDR = hdr;
            Chargertype = chargertype;
            HZ = hz;
            GB = gb;
            ItemNumber = itemnumber;
        }
        public Mobile()
        {

        }
        public void WriteOutInfo()
        {
            Console.WriteLine($"{Name}, {Height}, {Width}, {Depth}, {Weight}, {ReleaseYear}, {Color}, {Inches}, {Resolution}," +
                $" {Processor},{Waterproof}, {Battery}, {Stock}, {HDR}, {Chargertype}, {HZ}, {GB}, {ItemNumber}");
        }

        public void RetriveFromDatabase()
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader dr;
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            string sql = "select * from mobile";
            con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                cmd = new MySqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Mobile mobile = new Mobile();
                    mobile.Name = dr.GetString(0);
                    mobile.Height = dr.GetDouble(1);
                    mobile.Width = dr.GetDouble(2);
                    mobile.Depth = dr.GetDouble(3);
                    mobile.Weight = dr.GetDouble(4);
                    mobile.ReleaseYear = dr.GetInt32(5);
                    mobile.Color = dr.GetString(6);
                    mobile.Inches = dr.GetDouble(7);
                    mobile.Resolution = dr.GetString(8);
                    mobile.Processor = dr.GetString(9);
                    mobile.Waterproof = dr.GetString(10);
                    mobile.Battery = dr.GetString(11);
                    mobile.Stock = dr.GetInt32(12);
                    mobile.HDR = dr.GetString(13);
                    mobile.Chargertype = dr.GetString(14);
                    mobile.HZ = dr.GetString(15);
                    mobile.GB = dr.GetInt32(16);
                    mobile.ItemNumber = dr.GetInt32(17);

                    listMobiles.Add(mobile);
                }
                dr.Close();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                
            }     
        }
    }
}
