using api.database;
using api.interfaces;

namespace api.models
{
    public class User
    {
        public int UserID { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int Role { get; set; }

        public bool IsBanned { get; set; }

        public ISaveUser Save { get; set; }

        public User()
        {
            Save = new SaveUser();
        }

        public override string ToString()
        {
            return "User ID: " + UserID + ", full name: " + FullName + ", password: " + Password + ", email: " + Email + ", role: " + Role + ", is banned: " + IsBanned;
        }

    }
}