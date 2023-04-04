using BankAPI.Models;

namespace BankAPI.Services.Interfaces
{
    public interface ITransactionService
    {
        Response CreateNewTransaction(Transaction transaction);

        Response FindTransactionByDate(DateTime date);

        Response MakeDeposite(string AccountNumber, decimal Amount, string TransactionPin);

        Response MakeWithdrawl(string AccountNumber, decimal Amount, string TransactionPin);

        Response MakeFundsTransfer(string FromAccount, string ToAccount, decimal Amount, string TransactionPin);

    
    }
}
