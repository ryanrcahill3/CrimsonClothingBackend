using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class UpdateClothing : IUpdateClothing
    {
        public void EditClothing(Clothing value)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE clothing set Title = @title, Type = @type, Occasion = @occasion, Size = @size, UserID = @userid, TransactionID = @transactionid, buyPrice = @buyprice, ImageURL = @imageurl, IsNew = @isnew, IsDeleted = @isdeleted where ID = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", value.ID);
            cmd.Parameters.AddWithValue("@title", value.Title);
            cmd.Parameters.AddWithValue("@type", value.Type);
            cmd.Parameters.AddWithValue("@occasion", value.Occasion);
            cmd.Parameters.AddWithValue("@size", value.Size);
            cmd.Parameters.AddWithValue("@userid", value.UserID);
            cmd.Parameters.AddWithValue("@transactionid", value.TransactionID);
            cmd.Parameters.AddWithValue("@buyprice", value.buyPrice);
            cmd.Parameters.AddWithValue("@imageurl", value.ImageURL);
            cmd.Parameters.AddWithValue("@isnew", value.IsNew);
            cmd.Parameters.AddWithValue("@isdeleted", value.IsDeleted);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}