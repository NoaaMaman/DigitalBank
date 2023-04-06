using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class RegisterNewAccountModel
    {
        // [Key]
        // public int AccountId { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        //public string AccountName { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public string Email { get; set; } = default!;

        //public decimal CurrentAccountBalance { get; set; } = default!;

        //public AccountType AccountType { get; set; } = default!;

        //public string AccountNumberGenerated { get; set; } = default!;

        // [Column("PinHash")]
        //public byte[] PinHash { get; set; } = default!;

        //public byte[] PinSalt { get; set; } = default!;

        public DateTime DateCreated { get; set; } = default!;

        public DateTime DateLastUpdated { get; set; } = default!;

        [Required]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Pin must not be more than 4 digits")]
        public string Pin { get; set; } = default!;

        [Required]
        [Compare("Pin", ErrorMessage = "Pins do not match")]
        public string ConfirmPin { get; set; }
    }
}
