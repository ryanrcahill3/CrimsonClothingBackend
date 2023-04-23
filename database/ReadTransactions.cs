using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class ReadTransactions : IReadTransactions
    {
        public List<Transaction> GetAllTransactions()
        {
            List<Transaction> allTransactions = new List<Transaction>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM transactions";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Transaction temp = new Transaction() { ID = rdr.GetInt32(0), Price = rdr.GetDouble(1), Date = DateOnly.FromDateTime(rdr.GetDateTime(2)), UserID = rdr.GetInt32(3), ClothingID = rdr.GetInt32(4) };
                allTransactions.Add(temp);
            }


            return allTransactions;
        }
    }
}