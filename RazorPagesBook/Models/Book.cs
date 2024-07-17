using System.ComponentModel.DataAnnotations;

namespace RazorPagesBook.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ProductNo { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

    }
}
