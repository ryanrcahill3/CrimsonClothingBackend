using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class SavePromotion : ISavePromotions
    {
        public void CreatePromotion(Promotion myPromotion)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "INSERT INTO promotions(promoterID, promoteeID, promotionDate, newRole) VALUES (@promoterID, @promoteeIDID, @promotionDate, @newRole)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@promoterID", myPromotion.promoterID);
            cmd.Parameters.AddWithValue("@promoteeIDID", myPromotion.promoteeID);
            cmd.Parameters.AddWithValue("@promotionDate", myPromotion.promotionDate);
            cmd.Parameters.AddWithValue("@newRole", myPromotion.newRole);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}