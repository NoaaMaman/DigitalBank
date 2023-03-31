using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankproject.Common.Model
{
    [Table("Transactions")]
    public class Transaction : BaseEntity
    {
        [Key]
        public int _Id { get; set; } = default!;

        public string TransactionUniqueReference { get; set; } = default!;

        public decimal TransactionAmount { get; set; } = default!;

        public TransStatus TrnsactionStatus { get; set; } = default!;

        public bool isSucceful => TrnsactionStatus.Equals(TransStatus.Success);

        public string TrnsactionSourceAccount { get; set; } = default!;

        public string TransactionDestinationAccount { get; set; } = default!;

        public string TrnsactionParticulars { get; set; } = default!;

        public TransType TransactionType { get; set; } = default!;

        public DateTime TransactionDate { get; set; } = default!;

        public Transaction()
        {
            TransactionUniqueReference = $"{Guid.NewGuid().ToString().Replace("-", " ").Substring(1, 27)}";
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
