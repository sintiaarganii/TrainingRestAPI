using System.ComponentModel.DataAnnotations;

namespace Training2.Models.DB
{
    public class Item
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Item Name cannot be empty")]
        [MaxLength(100, ErrorMessage = "Max Length 100")]
        [MinLength(4, ErrorMessage = "Min Length 4")]
        public required string ItemName { get; set; }

        [Required (ErrorMessage = "Qty Cannot be empty")]
        [Range (1, 500, ErrorMessage = "Min = 1, Max = 500")]
        public int Quantity { get; set; }

        [Required (ErrorMessage = "Date Exp cannot be empty")]
        public DateTime DateExp { get; set; }

        [Required (ErrorMessage = "Supplier cannot be empty")]
        [MaxLength(100, ErrorMessage = "Max Length 100")]
        [MinLength(3, ErrorMessage = "Min Length 4")]
        public required string Supplier { get; set; }

        [MaxLength(100, ErrorMessage = "Max Length 100")]
        public string? AddressSupp { get; set; }
    }
}
