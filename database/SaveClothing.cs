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

            string stm = @"INSERT INTO clothing(title, type, occasion, size) VALUES(@title, @type, @occasion, @size)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@title", myClothing.Title);
            System.Console.WriteLine(myClothing.Title);
            cmd.Parameters.AddWithValue("@type", myClothing.Type);
            System.Console.WriteLine(myClothing.Type);
            cmd.Parameters.AddWithValue("@occasion", myClothing.Occasion);
            System.Console.WriteLine(myClothing.Occasion);
            cmd.Parameters.AddWithValue("@size", myClothing.Size);
            System.Console.WriteLine(myClothing.Size);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }


    }
}