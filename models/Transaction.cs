namespace api.models
{
    public class Transaction
    {
        public int ID { get; set; } // primary key

        public double Price { get; set; }

        public string Date { get; set; }

        public int UserID { get; set; } // foreign key

        public int ClothingID { get; set; } // foreign key



    }
}