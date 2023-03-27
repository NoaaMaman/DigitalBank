using Microsoft.AspNetCore.Mvc.ApplicationModels;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApI.Models
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AccountName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public decimal CurrentAccountBalance { get; set; }

        public AccountType AccountType { get; set; }
        
        public string AccountNumberGenerated { get; set; }

        public byte[] PinHash { get; set; }

        public string PinSalt { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public Account()
        {
            Random random = new Random();
            long accountNumber = (long)(Math.Floor(random.NextDouble() * 9_000_000_000L) + 1_000_000_000L);
            AccountNumberGenerated = accountNumber.ToString();

            AccountName = $"{FirstName} {LastName}";


        }
    }

    public enum AccountType
    {
        Savings,
        Current,
        Corporate,
        Government

    }
}
