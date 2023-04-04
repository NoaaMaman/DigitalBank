using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BankAPI
{
    [Table("Accounts")]
    public class Account 
    {
        public readonly object Transactions;

        [Key]
        public int AccountId { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string AccountName { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public string Email { get; set; } = default!;

        public decimal CurrentAccountBalance { get; set; } = default!;

        public AccountType AccountType { get; set; } = default!;

        public string AccountNumberGenerated { get; set; } = default!;

        [JsonIgnore]
        public byte[] PinHash { get; set; } = default!;

        [JsonIgnore]
        public byte[] PinSalt { get; set; } = default!;

        public DateTime DateCreated { get; set; } = default!;

        public DateTime DateLastUpdated { get; set; } = default!;

        Random rand = new Random();
        public Account()
        {

            //long accountNumber = (long)(Math.Floor(random.NextDouble() * 9_000_000_000L) + 1_000_000_000L);
            //AccountNumberGenerated = accountNumber.ToString();

            AccountNumberGenerated = Convert.ToString((long)Math.Floor((rand.NextDouble() * 9_000_000_000L) + 1_000_000_000L));
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
