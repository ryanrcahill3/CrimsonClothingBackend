using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class ReadUser : IReadUser
    {
        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM users";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                User temp = new User() { UserID = rdr.GetInt32(0), FullName = rdr.GetString(1), Password = rdr.GetString(2), Email = rdr.GetString(3), Role = rdr.GetInt32(4), IsBanned = rdr.GetBoolean(5) };
                allUsers.Add(temp);
            }


            return allUsers;
        }
    }
}