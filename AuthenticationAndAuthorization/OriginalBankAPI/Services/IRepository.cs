using BankApI.Models;

namespace OriginalBankAPI.Services
{
    public interface IRepository
    {
        public List<Transaction> GatAllTransactions();
        Transaction GetTransactionById(int id);
    }
}
