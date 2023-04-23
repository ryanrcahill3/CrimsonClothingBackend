using api.database;
using api.interfaces;

namespace api.models
{
    public class User
    {
        public int ID { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int Role { get; set; }

        public bool IsBanned { get; set; }

        public ISaveUsers Save { get; set; }

        public IUpdateUsers Update { get; set; }

        public User()
        {
            Save = new SaveUser();
            Update = new UpdateUser();
        }

        public override string ToString()
        {
            return "User ID: " + ID + ", full name: " + FullName + ", password: " + Password + ", email: " + Email + ", role: " + Role + ", is banned: " + IsBanned;
        }

    }
}