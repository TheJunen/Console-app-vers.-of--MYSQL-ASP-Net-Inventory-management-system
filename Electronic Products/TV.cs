using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Webapp_Lagersystem_Intervju
{
    public class TV : Electronic_Products, IProduct
    {
        public List<TV> listTVs = new List<TV>();
        public TV(string name, double height, double width, double depth, double weight, int releaseyear,
            string color, double inches, string resolution, string processor, string powersupply, int stock, string hdr, int hdmi, string ms, string hz, int itemnumber)
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
            PowerSupply = powersupply;
            Stock = stock;
            HDR = hdr;
            HDMI = hdmi;
            MS = ms;
            HZ = hz;
            ItemNumber = itemnumber;

        }

        public TV()
        {

        }

        public void WriteOutInfo()
        {
            Console.WriteLine($"{Name}, {Height}, {Width}, {Depth}, {Weight}, {ReleaseYear}, {Color}, {Inches}, {Resolution}," +
                $" {Processor}, {PowerSupply}, {Stock}, {HDR}, {HDMI}, {MS}, {HZ}, {ItemNumber}");
        }

        public void RetriveFromDatabase()
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader dr;
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            string sql = "select * from tv";
            con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                cmd = new MySqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TV tv = new TV();
                    tv.Name = dr.GetString(0);
                    tv.Height = dr.GetDouble(1);
                    tv.Width = dr.GetDouble(2);
                    tv.Depth = dr.GetDouble(3);
                    tv.Weight = dr.GetDouble(4);
                    tv.ReleaseYear = dr.GetInt32(5);
                    tv.Color = dr.GetString(6);
                    tv.Inches = dr.GetDouble(7);
                    tv.Resolution = dr.GetString(8);
                    tv.Processor = dr.GetString(9);
                    tv.PowerSupply = dr.GetString(10);
                    tv.Stock = dr.GetInt32(11);
                    tv.HDR = dr.GetString(12);
                    tv.HDMI = dr.GetInt32(13);
                    tv.MS = dr.GetString(14);
                    tv.HZ = dr.GetString(15);
                    tv.ItemNumber = dr.GetInt32(16);

                    listTVs.Add(tv);
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
