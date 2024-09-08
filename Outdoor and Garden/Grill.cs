using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;

namespace Webapp_Lagersystem_Intervju
{
    internal class Grill : OutdoorAndGarden, IProduct
    {
        internal string GasBurners;
        internal string PowerSupply;
        internal List<Grill> listGrills = new List<Grill>();
        public Grill(string name, double height, double width, double depth, double weight, string color,
            string gasburners, string portable, string material, int stock, string powersupply, int itemnumber)
        {
            Name = name; 
            Height = height;
            Width = width;
            Depth = depth;
            Weight = weight;
            Color = color;
            GasBurners = gasburners;
            Portable = portable;
            Material = material;
            Stock = stock;
            PowerSupply = powersupply;
            ItemNumber = itemnumber;                                 
        }

        public Grill()
        {

        }

        public void WriteOutInfo()
        {
            Console.WriteLine($"{Name}, {Height}, {Width}, {Depth}, {Weight}, {Color}, {GasBurners}," +
                $" {Portable}, {Material}, {Stock}, {PowerSupply}, {ItemNumber}");
        }

        public void RetriveFromDatabase()
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader dr;
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            string sql = "select * from grill";
            con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                cmd = new MySqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Grill grill = new Grill();
                    grill.Name = dr.GetString(0);
                    grill.Height = dr.GetDouble(1);
                    grill.Width = dr.GetDouble(2);
                    grill.Depth = dr.GetDouble(3);
                    grill.Weight = dr.GetDouble(4);
                    grill.Color = dr.GetString(5);
                    grill.GasBurners = dr.GetString(6);
                    grill.Portable = dr.GetString(7);
                    grill.Material = dr.GetString(8);
                    grill.Stock = dr.GetInt32(9);
                    grill.PowerSupply = dr.GetString(10);
                    grill.ItemNumber = dr.GetInt32(11);

                    listGrills.Add(grill);
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
