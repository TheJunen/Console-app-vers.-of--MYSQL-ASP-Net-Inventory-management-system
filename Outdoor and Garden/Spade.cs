using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Webapp_Lagersystem_Intervju
{
    internal class Spade : OutdoorAndGarden, IProduct
    {
        internal double Length;
        internal List<Spade> listSpades = new List<Spade>();
        public Spade(string name, double length, double width, double height, double weight, string foldable, int stock, int itemnumber)
        {
            Name = name;
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
            Foldable = foldable;
            Stock = stock;
            ItemNumber = itemnumber;
        }

        public Spade()
        {

        }

        public void WriteOutInfo()
        {
            Console.WriteLine($"{Name}, {Length}, {Width}, {Height}, {Weight}, {Foldable}, {Stock}, {ItemNumber}");
        }

        public void RetriveFromDatabase()
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader dr;
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            string sql = "select * from spade";
            con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                cmd = new MySqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Spade spade = new Spade();
                    spade.Name = dr.GetString(0);
                    spade.Length = dr.GetDouble(1);
                    spade.Width = dr.GetDouble(2);
                    spade.Height = dr.GetDouble(3);
                    spade.Weight = dr.GetDouble(4);
                    spade.Foldable = dr.GetString(5);
                    spade.Stock = dr.GetInt32(6);
                    spade.ItemNumber = dr.GetInt32(7);

                    listSpades.Add(spade);
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
