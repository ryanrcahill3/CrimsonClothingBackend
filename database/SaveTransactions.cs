using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class SaveTransactions : ISaveTransactions
    {
        public void CreateTransaction(Transaction myTransaction)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO transactions(price, userID, date) VALUES(@price, @userid, @date)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@price", myTransaction.Price);
            cmd.Parameters.AddWithValue("@userid", myTransaction.UserID);
            cmd.Parameters.AddWithValue("@date", myTransaction.Date);


            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}