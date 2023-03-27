using BankApI.Models;

namespace AuthenticationAndAuthorization.DTO
{
    public class TransactionsDTO
    {
        public int ID { get; set; }

        public string TransactionUniqueReference { get; set; }

        public decimal TransactionAmount { get; set; }

        public TransStatus TrnsactionStatus { get; set; }

        public bool isSucceful => TrnsactionStatus.Equals(TransStatus.Success);
    }
}
