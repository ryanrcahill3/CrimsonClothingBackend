using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class SaveClothing : ISaveClothing
    {

        public void CreateClothing(Clothing myClothing)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO clothing(title, size, imageURL, userID) VALUES(@title, @size, @image, @userID)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@title", myClothing.Title);
            System.Console.WriteLine(myClothing.Title);
            cmd.Parameters.AddWithValue("@size", myClothing.Size);
            System.Console.WriteLine(myClothing.Size);
            cmd.Parameters.AddWithValue("@imageURL", myClothing.ImageURL);
            System.Console.WriteLine(myClothing.ImageURL);
            cmd.Parameters.AddWithValue("@userID", myClothing.UserID);
            System.Console.WriteLine(myClothing.UserID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }


    }
}