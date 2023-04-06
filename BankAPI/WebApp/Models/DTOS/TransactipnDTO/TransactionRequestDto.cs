using BankAPI;

namespace WebApp.Models.DTOS.TransactipnDTO
{
    public class TransactionRequestDto
    {

        public decimal TransactionAmount { get; set; } = default!;

        public string TrnsactionSourceAccount { get; set; } = default!;

        public string TransactionDestinationAccount { get; set; } = default!;


        public TransType TransactionType { get; set; } = default!;

        public DateTime TransactionDate { get; set; } = default!;
    }


}

