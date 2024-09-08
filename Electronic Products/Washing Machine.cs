using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
namespace Webapp_Lagersystem_Intervju
{
    internal class Washing_Machine : Electronic_Products, IProduct
    {
        internal int Centrifugespeed;
        internal string Energyclass;
        public List<Washing_Machine> listWMs = new List<Washing_Machine>();
        public Washing_Machine(string name, double height, double width, double depth, double weight,
            string color, string powersupply, int stock, int centrifugespeed, string hz, string energyclass, int itemnumber)
        {
            Name = name;
            Height = height;
            Width = width;
            Depth = depth;
            Weight = weight;
            Color = color;
            PowerSupply = powersupply;
            Stock = stock;
            Centrifugespeed = centrifugespeed;
            HZ = hz;
            Energyclass = energyclass;
            ItemNumber = itemnumber;
        }

        public Washing_Machine()
        {

        }

        public void WriteOutInfo()
        {
            Console.WriteLine($"{Name}, {Height}, {Width}, {Depth}, {Weight}, {Color}, {PowerSupply}, {Stock}," +
                $"{Centrifugespeed}, {HZ}, {Energyclass}, {ItemNumber}");
        }

        public void RetriveFromDatabase()
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader dr;
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            string sql = "select * from washingmachine";
            con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                cmd = new MySqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Washing_Machine wm  = new Washing_Machine();
                    wm.Name = dr.GetString(0);
                    wm.Height = dr.GetDouble(1);
                    wm.Width = dr.GetDouble(2);
                    wm.Depth = dr.GetDouble(3);
                    wm.Weight = dr.GetDouble(4);
                    wm.Color = dr.GetString(5);
                    wm.PowerSupply = dr.GetString(6);
                    wm.Stock = dr.GetInt32(7);
                    wm.Centrifugespeed = dr.GetInt32(8);
                    wm.HZ = dr.GetString(9);
                    wm.Energyclass = dr.GetString(10);
                    wm.ItemNumber = dr.GetInt32(11);

                    listWMs.Add(wm);
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
