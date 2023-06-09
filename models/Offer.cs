using api.database;
using api.interfaces;

namespace api.models
{
    public class Offer
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        public int ClothingID { get; set; }

        public string ImageURL { get; set; }

        public ISaveOffers Save { get; set; }

        public IUpdateOffers Update { get; set; }

        public Offer()
        {
            Save = new SaveOffers();
            Update = new UpdateOffers();
        }

        public override string ToString()
        {
            return "Offer ID: " + ID + ", customer ID: " + CustomerID + ", clothing ID: " + ClothingID;
        }
    }
}