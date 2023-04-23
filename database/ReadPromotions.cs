using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{


    public class ReadPromotions : IReadPromotions
    {


        public List<Promotion> GetPromotions()
        {
            List<Promotion> allPromotions = new List<Promotion>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM promotion";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Promotion temp = new Promotion() { ID = rdr.GetInt32(0), promoterID = rdr.GetInt32(1), promoteeID = rdr.GetInt32(2), promotionDate = DateOnly.FromDateTime(rdr.GetDateTime(3)), newRole = rdr.GetInt32(4) };
                allPromotions.Add(temp);
            }


            return allPromotions;
        }
    }

}
