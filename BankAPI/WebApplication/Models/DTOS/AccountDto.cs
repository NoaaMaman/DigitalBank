
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.DTOS
{
    public class AccountDTO
    {

        public int AccountId { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string AccountName { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public string Email { get; set; } = default!;

        public decimal CurrentAccountBalance { get; set; } = default!;

        //public AccountType AccountType { get; set; } = default!;

        public string AccountNumberGenerated { get; set; } = default!;


        public DateTime DateCreated { get; set; } = default!;

        public DateTime DateLastUpdated { get; set; } = default!;
    }
}
