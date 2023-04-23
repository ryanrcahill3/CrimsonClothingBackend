using api.models;

namespace api.interfaces
{
    public interface IReadPromotions
    {
        public List<Promotion> GetPromotions();
    }
}