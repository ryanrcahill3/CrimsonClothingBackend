using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class ReadOffers : IReadOffers
    {
        public List<Offer> GetOffers()
        {
            List<Offer> allOffers = new List<Offer>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM offers";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Offer temp = new Offer()
                {
                    ID = rdr.GetInt32(0),
                    CustomerID = rdr.GetInt32(1),
                    ClothingID = rdr.GetInt32(2),

                };
                allOffers.Add(temp);
            }


            return allOffers;
        }
    }
}