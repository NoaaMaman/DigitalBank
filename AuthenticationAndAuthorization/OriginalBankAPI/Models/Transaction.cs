﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace BankApI.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public int ID { get; set; }

        public string TransactionUniqueReference{ get; set; }

        public decimal TransactionAmount { get; set; }

        public TransStatus TrnsactionStatus { get; set; }

        public bool isSucceful => TrnsactionStatus.Equals(TransStatus.Success);

        public string TrnsactionSourceAccount { get; set; }

        public string TransactionDestinationAccount{ get; set; }

        public string TrnsactionParticulars { get; set; }

        public TransType TransactionType { get; set; }

        public DateTime TransactionDate{ get; set; }

        public Transaction()
        {
            TransactionUniqueReference = $"{Guid.NewGuid().ToString().Replace("-"," ").Substring(1,27)}";
        }
        
    }
    public enum TransStatus
    {
        Failed,
        Success,
        Error
    }
    public enum TransType
    {
        Deposite,
        Withdrawl,
        Transfer
    }
}