using api.models;

namespace api.interfaces
{
    public interface ISaveTransactions
    {
        public void CreateTransaction(Transaction myTransaction);
    }
}