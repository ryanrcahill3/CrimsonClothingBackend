using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class UpdatePromotions
    {
        public void EditPromotion(Promotion value)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE promotion set CustomerID = @customerid, ClothingID = @clothingid where ID = @id";

            using var cmd = new MySqlCommand(stm, con);



            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}