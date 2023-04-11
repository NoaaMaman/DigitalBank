using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAPI.Models
{
    [Table("Spair")]
    public class Spair
    {
        [Key]
        public int ID { get; set; }
    }
}
