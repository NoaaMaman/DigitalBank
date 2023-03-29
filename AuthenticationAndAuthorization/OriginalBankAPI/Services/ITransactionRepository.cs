using BankApI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OriginalBankAPI.Services
{
    public interface ITransactionRepository
    {
        Task<int> CraeteTrasactionAsync(Transaction transaction);
        Task<List<Transaction>> GatAllTransactionsAsync();
        Task<Transaction?> GetTransactionByIdAsync(int id);

        Task UpdateTransactionAsync(Transaction transaction);

        Task DeleteTransactionAsync(int transactionID);

    }
}
