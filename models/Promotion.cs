using api.database;
using api.interfaces;

namespace api.models
{
    public class Promotion
    {
        public int ID { get; set; }

        public int promoterID { get; set; }

        public int promoteeID { get; set; }

        public DateOnly promotionDate { get; set; }

        public int newRole { get; set; }

        public ISavePromotions Save { get; set; }

        public Promotion()
        {
            Save = new SavePromotion();
        }

        public override string ToString()
        {
            return "ID: " + ID + ", promoter ID: " + promoterID + ", promotee ID: " + promoteeID + ", promotion date: " + promotionDate + ", new role: " + newRole;
        }


    }
}