using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class UpdateTransactions : IUpdateTransactions
    {
        public void EditTransaction(Transaction value)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE transactions set Price = @price, UserID = @userid, ClothingID = @clothing, Date = @date where ID = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", value.ID);
            cmd.Parameters.AddWithValue("@price", value.Price);
            cmd.Parameters.AddWithValue("@userid", value.UserID);
            cmd.Parameters.AddWithValue("@clothingid", value.ClothingID);


            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

    }
}