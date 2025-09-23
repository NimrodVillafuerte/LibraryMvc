using System.ComponentModel.DataAnnotations;

namespace LibraryMvc.DTOs
{
    public class PublisherReadDto
    {
        public int PublisherID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
    }

    public class PublisherCreateDto
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [Url]
        public string Website { get; set; }
    }

    public class PublisherUpdateDto : PublisherCreateDto
    {
        [Required]
        public int PublisherID { get; set; }
    }
}
