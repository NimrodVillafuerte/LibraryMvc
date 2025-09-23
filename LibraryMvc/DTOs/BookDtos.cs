using System.ComponentModel.DataAnnotations;

namespace LibraryMvc.DTOs
{
    public class BookReadDto
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime? PublishDate { get; set; }
        public string PublisherName { get; set; }
        public string Genre { get; set; }
        public int? Pages { get; set; }
        public List<AuthorReadDto> Authors { get; set; } = new();
    }

    public class BookCreateDto
    {
        [Required, StringLength(150)]
        public string Title { get; set; }

        [Required, StringLength(20)]
        public string ISBN { get; set; }

        public DateTime? PublishDate { get; set; }

        [Required]
        public int? PublisherID { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        [Range(1, 10000)]
        public int? Pages { get; set; }

        public List<int> AuthorIds { get; set; } = new();
    }

    public class BookUpdateDto : BookCreateDto
    {
        [Required]
        public int BookID { get; set; }
    }
}
