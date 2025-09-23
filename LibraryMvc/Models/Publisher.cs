using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMvc.Models
{
    [Table("Publisher", Schema = "dbo")]
    public class Publisher
    {
        [Key]
        public int PublisherID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(100)]
        public string Website { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
