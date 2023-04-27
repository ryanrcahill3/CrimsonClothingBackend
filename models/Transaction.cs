using api.database;
using api.interfaces;

namespace api.models
{
    public class Transaction
    {
        public int ID { get; set; } // primary key

        public double Price { get; set; }

        public DateOnly Date { get; set; }

        public int UserID { get; set; } // foreign key


        public ISaveTransactions Save { get; set; }

        public IUpdateTransactions Update { get; set; }

        public Transaction()
        {
            Save = new SaveTransactions();
            Update = new UpdateTransactions();
        }



    }
}