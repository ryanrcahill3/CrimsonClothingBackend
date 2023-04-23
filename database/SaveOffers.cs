using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class SaveOffers : ISaveOffers
    {
        public void CreateOffer(Offer myOffer)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO offers(customerID, clothingID) VALUES(@customerID, @clothingID)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@customerID", myOffer.CustomerID);
            System.Console.WriteLine(myOffer.CustomerID);
            cmd.Parameters.AddWithValue("@clothingID", myOffer.ClothingID);
            System.Console.WriteLine(myOffer.ClothingID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}