using BankAPI.Models;

namespace BankAPI.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<Response> CreateNewTransactionAsync(Transaction transaction);

        Task<Response> FindTransactionByDateAsync(DateTime date);

        Task<Response> MakeDepositeAsync(string AccountNumber, decimal Amount, string TransactionPin);

        Task<Response> MakeWithdrawlAsync(string AccountNumber, decimal Amount, string TransactionPin);

        Task<Response> MakeFundsTransferAsync(string FromAccount, string ToAccount, decimal Amount, string TransactionPin);

    
    }
}
