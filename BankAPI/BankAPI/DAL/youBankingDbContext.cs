using BankAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.DAL
{
    public class youBankingDbContext  : DbContext
    {
        public youBankingDbContext(DbContextOptions<youBankingDbContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        //public DbSet<TransactionTypes> TransactionTyes { get; set; }

        //public DbSet<Response> Responses{ get; set; }
    }
}
