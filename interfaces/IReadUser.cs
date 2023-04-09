using api.models;

namespace api.interfaces
{
    public interface IReadUser
    {
        public List<User> GetAllUsers();
    }
}