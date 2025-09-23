using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMvc.Models
{
    [Table("BookAuthor", Schema = "dbo")]
    public class BookAuthor
    {
        public int BookID { get; set; }
        public Book Book { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }

        public string Contribution { get; set; }
    }
}

