using System.Globalization;
using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class ReadClothing : IReadClothing
    {
        public List<Clothing> GetAllClothing()
        {
            List<Clothing> allClothing = new List<Clothing>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM clothing";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Clothing temp = new Clothing()
                {
                    ID = rdr.GetInt32(0),
                    Title = rdr.GetString(1),
                    Type = rdr.GetString(2),
                    Occasion = rdr.GetString(3),
                    Size = rdr.GetString(4),
                    buyPrice = rdr.GetDouble(5),
                    ImageURL = rdr.GetString(6)
                };
                allClothing.Add(temp);
            }


            return allClothing;
        }
    }

}