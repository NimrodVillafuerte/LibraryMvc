using System.ComponentModel.DataAnnotations;

namespace LibraryMvc.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }

        public ICollection<BookAuthor> BookAuthor { get; set; } = new List<BookAuthor>();
    }
}

