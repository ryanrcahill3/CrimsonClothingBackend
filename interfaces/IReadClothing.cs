using api.models;

namespace api.interfaces
{
    public interface IReadClothing
    {
        public List<Clothing> GetAllClothing();
    }
}