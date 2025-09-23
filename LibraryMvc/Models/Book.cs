using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMvc.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [Required, StringLength(150)]
        public string Title { get; set; }

        [StringLength(20)]
        public string ISBN { get; set; }

        public DateTime? PublishDate { get; set; }

        [ForeignKey("Publisher")]
        public int? PublisherID { get; set; }
        public Publisher Publisher { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        public int? Pages { get; set; }

        public ICollection<BookAuthor> BookAuthor { get; set; } = new List<BookAuthor>();
    }
}
