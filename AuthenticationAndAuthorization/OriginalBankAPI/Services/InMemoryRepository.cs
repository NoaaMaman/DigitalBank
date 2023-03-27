using BankApI.Models;
using Microsoft.Identity.Client;
using System.Transactions;
using Transaction = BankApI.Models.Transaction;

namespace OriginalBankAPI.Services
{
    public class InMemoryRepository : IRepository
    {
        private List<Transaction> _transactions;
        public InMemoryRepository()
        {
            _transactions = new List<Transaction>()
            {
                new Transaction() {
                    ID  = 1,
                    TransactionAmount = 100,
                    TrnsactionStatus = TransStatus.Success,
                    TrnsactionSourceAccount = "me",
                    TransactionDestinationAccount="yosi",
                    TrnsactionParticulars="holiday gift",
                    TransactionType = TransType.Transfer,
                    TransactionDate = new DateTime(2023, 3, 27, 13, 30, 0, DateTimeKind.Local)
                }
            };
        }

        public List<Transaction> GatAllTransactions()
        {
            return _transactions;
        }

        public Transaction GetTransactionById(int id)
        {
            return _transactions.FirstOrDefault(x => x.ID == id);
        }
    }
}
