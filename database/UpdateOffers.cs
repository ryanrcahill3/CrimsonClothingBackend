using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class UpdateOffers : IUpdateOffers
    {
        public void EditOffer(Offer value)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE offers set CustomerID = @customerid, ClothingID = @clothingid where ID = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", value.ID);
            cmd.Parameters.AddWithValue("@customerid", value.CustomerID);
            cmd.Parameters.AddWithValue("@clothingid", value.ClothingID);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}