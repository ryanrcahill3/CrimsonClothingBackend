using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class SaveUser : ISaveUsers
    {
        public void CreateUser(User myUser)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO users(fullname, password, email, role) VALUES(@fullname, @password, @email, @role)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@fullname", myUser.FullName);
            cmd.Parameters.AddWithValue("@password", myUser.Password);
            cmd.Parameters.AddWithValue("@email", myUser.Email);
            cmd.Parameters.AddWithValue("@role", myUser.Role);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}