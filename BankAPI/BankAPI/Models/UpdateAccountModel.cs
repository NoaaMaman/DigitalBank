using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class UpdateAccountModel
    {
        [Key]
        public int Id { get; set; }

        

        public string PhoneNumber { get; set; } = default!;

        public string Email { get; set; } = default!;

        public DateTime DateLastUpdated { get; set; } = default!;

        [Required]
        [RegularExpression(@"^[0-9]/d{4}$", ErrorMessage = "Pin must be more than 4 digits")]
        public string Pin { get; set; } = default!;

        [Required]
        [Compare("Pin", ErrorMessage = "Pins do not match")]
        public string ConfirmPin { get; set; }
    }
}
