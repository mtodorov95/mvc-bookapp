using System.ComponentModel.DataAnnotations;

namespace BookStore
{
    public class BookModel
    {
        public int id { get; set; }
        [StringLength(100, MinimumLength =5)]
        [Required(ErrorMessage ="Please enter the title of your book")]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [StringLength(500, ErrorMessage ="Description can't be longer than 500 characters")]
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        [Required]
        public int Pages { get; set; }
    }
}