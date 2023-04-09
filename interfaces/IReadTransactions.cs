using api.models;

namespace api.interfaces
{
    public interface IReadTransactions
    {
        public List<Transaction> GetAllTransactions();
    }
}