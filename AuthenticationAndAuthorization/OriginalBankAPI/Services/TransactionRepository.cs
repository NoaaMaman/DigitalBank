using BankApI.Data;
using BankApI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using Transaction = BankApI.Models.Transaction;

namespace OriginalBankAPI.Services
{
    public class TransactionRepository : ITransactionRepository
    {
        private List<Transaction> _transactions;
        private BankingDbContext DbContext { get; set; }
        //public TransactionRepository()
        //{
        //    _transactions = new List<Transaction>()
        //    {
        //        new Transaction() {
        //            ID  = 1,
        //            TransactionAmount = 100,
        //            TrnsactionStatus = TransStatus.Success,
        //            TrnsactionSourceAccount = "me",
        //            TransactionDestinationAccount="yosi",
        //            TrnsactionParticulars="holiday gift",
        //            TransactionType = TransType.Transfer,
        //            TransactionDate = new DateTime(2023, 3, 27, 13, 30, 0, DateTimeKind.Local)
        //        }
        //    };
        //}
        public TransactionRepository(BankingDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<int> CreateTransactionAsync(Transaction transaction)
        {
            DbContext.Transactions.Add(transaction);
            await DbContext.SaveChangesAsync();
            return transaction.ID;
            

        }

        public async Task DeleteTransactionAsync(int transactionID)
        {
            var transaction = await DbContext.Transactions.FindAsync(transactionID);
            if (transaction != null) 
            {
                DbContext.Transactions.Remove(transaction);
                await DbContext.SaveChangesAsync();
            }
            //throw new InvalidOperationException("Id not found!");
        }

        public async Task<Transaction?> GetTransactionByIdAsync(int id)
        {
            return await DbContext.Transactions.FindAsync(id);
        }
        public async Task<List<Transaction>> GatAllTransactionsAsync()
        {
            return await DbContext.Transactions.ToListAsync();
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            DbContext.Transactions.Attach(transaction);
            DbContext.Entry(transaction).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        Task<int> ITransactionRepository.CraeteTrasactionAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}

