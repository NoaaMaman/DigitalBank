using Bankproject.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankproject.Common.Dtos;

public record AccountCreate(string FirstName,
                            string LastName ,
                            string AccountName, 
                            string PhoneNumber, 
                            string Email,
                            decimal CurrentAccountBalance,
                            AccountType AccountType,
                            string AccountNumberGenerated,
                            byte[] PinHas,
                            DateTime DateCreated,
                            DateTime DateLastUpdated);




//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Bankproject.Common.Model
//{
//    [Table("Accounts")]
//    public class Account : BaseEntity
//    {
//        public readonly object Transactions;

//        [Key]
//        public int AccountId { get; set; }

//        public string FirstName { get; set; } = default!;

//        public string LastName { get; set; } = default!;

//        public string AccountName { get; set; } = default!;

//        public string PhoneNumber { get; set; } = default!;

//        public string Email { get; set; } = default!;

//        public decimal CurrentAccountBalance { get; set; } = default!;

//        public AccountType AccountType { get; set; } = default!;

//        public string AccountNumberGenerated { get; set; } = default!;

//        [Column("PinHash")]
//        public byte[] PinHash { get; set; } = default!;

//        public string PinSalt { get; set; } = default!;

//        public DateTime DateCreated { get; set; } = default!;

//        public DateTime DateLastUpdated { get; set; } = default!;

//        public Account()
//        {
//            Random random = new Random();
//            long accountNumber = (long)(Math.Floor(random.NextDouble() * 9_000_000_000L) + 1_000_000_000L);
//            AccountNumberGenerated = accountNumber.ToString();

//            AccountName = $"{FirstName} {LastName}";
//        }
//    }

//    public enum AccountType
//    {
//        Savings,
//        Current,
//        Corporate,
//        Government
//    }
//}

