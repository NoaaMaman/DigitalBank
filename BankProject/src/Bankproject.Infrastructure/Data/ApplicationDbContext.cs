using Bankproject.Common.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankproject.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser,IdentityRole, string>
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts{ get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-VN7GPNR;Initial Catalog=BankingDb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>().HasKey(e => e.Id);
            builder.Entity<Transaction>().HasKey(e => e.Id);

            
            base.OnModelCreating(builder);
        }

    }
}
