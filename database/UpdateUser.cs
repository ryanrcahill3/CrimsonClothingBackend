using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class UpdateUser : IUpdateUsers
    {
        public void EditUser(User value)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE Users set FullName = @fullname, Password = @password, Email = @email, Role = @role where ID = @id IsBanned = @isbanned";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", value.ID);
            cmd.Parameters.AddWithValue("@fullname", value.FullName);
            cmd.Parameters.AddWithValue("@password", value.Password);
            cmd.Parameters.AddWithValue("@email", value.Email);
            cmd.Parameters.AddWithValue("@role", value.Role);
            cmd.Parameters.AddWithValue("@isbanned", value.IsBanned);



            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}