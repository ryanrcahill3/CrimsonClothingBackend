using CrimsonClothingBackend.models;

namespace CrimsonClothingBackend.interfaces
{
    public interface IReadClothing
    {
        public List<Clothing> GetAllClothes();
    }
}