using System;
using MySql.Data.MySqlClient;


namespace testMobile
{
    class Program
    {
        static void Main(string[] args)
        {
            var mobile = new Mobile();
            mobile.TestRetriveFromDatabase();
        }
    }
    public class Mobile
    {
        public void TestRetriveFromDatabase()
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
                    Console.WriteLine(dr.GetValue(0) + "-" + dr.GetValue(1) + "-" + dr.GetValue(2) + "-" + dr.GetValue(3) + "-" + dr.GetValue(4) + "-" + dr.GetValue(5) + "-" + dr.GetValue(6) + "-" + dr.GetValue(7));
                }
                dr.Close();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection failed");
            }


        }
    }
}
