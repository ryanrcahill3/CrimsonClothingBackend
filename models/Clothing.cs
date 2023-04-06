using CrimsonClothingBackend.database;
using CrimsonClothingBackend.interfaces;

namespace CrimsonClothingBackend.models
{
    public class Clothing
    {

        public int ID { get; set; } // primary key
        public string Title { get; set; }

        public string Type { get; set; }

        public string Occasion { get; set; }

        public double Discount { get; set; }

        public string Size { get; set; }

        public int UserID { get; set; } // foreign key

        public int TransactionID { get; set; } // foreign key

        public ISaveClothing Save { get; set; }
        public Clothing()
        {
            Save = new SaveClothing();

        }

        public override string ToString()
        {
            return "ID: " + ID + " " + Title + ", type: " + Type + ", occasion: " + Occasion + ", discount: " + Discount + ", size: " + Size + ", user ID: " + UserID + ", transaction ID: " + TransactionID;
        }

    }
}