using System.ComponentModel.DataAnnotations;

namespace RazorPagesBook.Models
{
    public class Book
    {
        public int Id { get; set; }
        [StringLength(10, MinimumLength = 3)]
        [Required]
        public string ProductNo { get; set; }
        [StringLength(120, MinimumLength = 3)]
        [Required]
        public string ProductName { get; set; }

        [Range(1, 999999)]
        [DataType(DataType.Currency)]
        public int Price { get; set; }

        [Display(Name = "Publication Date")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
        // only use letters, The first letter must be uppercase. White spaces are allowed, while numbers and special characters aren't allowed.
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Type { get; set; }

    }
}
