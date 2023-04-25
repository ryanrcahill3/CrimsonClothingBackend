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
                    UserID = rdr.IsDBNull(5) ? null : rdr.GetInt32(5),
                    TransactionID = rdr.IsDBNull(6) ? null : rdr.GetInt32(6),
                    IsApproved = rdr.GetBoolean(7),
                    IsDeleted = rdr.GetBoolean(8),
                    ImageURL = rdr.IsDBNull(9) ? null : rdr.GetString(9),
                    buyPrice = rdr.IsDBNull(10) ? null : rdr.GetDouble(10)


                };
                allClothing.Add(temp);
            }


            return allClothing;
        }
    }

}