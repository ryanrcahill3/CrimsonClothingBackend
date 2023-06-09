using api.database;
using api.interfaces;

namespace api.models
{
    public class Clothing
    {

        public int ID { get; set; } // primary key
        public string Title { get; set; }

        public string Type { get; set; }

        public string Occasion { get; set; }

        public string Size { get; set; }

        public int? UserID { get; set; } // foreign key

        public int? TransactionID { get; set; } // foreign key

        public double? buyPrice { get; set; }

        public double? sellPrice { get; set; }

        public string ImageURL { get; set; }

        public ISaveClothing Save { get; set; }

        public IUpdateClothing Update { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDeleted { get; set; }
        public Clothing()
        {
            Save = new SaveClothing();
            Update = new UpdateClothing();

        }

        public override string ToString()
        {
            return "Clothing ID: " + ID + ", title: " + Title + ", type: " + Type + ", occasion: " + Occasion + ", size: " + Size + ", user ID: " + UserID + ", transaction ID: " + TransactionID + ", buy price: " + buyPrice + ", image URL: " + ImageURL + ", is approved: " + IsApproved + ", is deleted: " + IsDeleted;
        }
    }
}