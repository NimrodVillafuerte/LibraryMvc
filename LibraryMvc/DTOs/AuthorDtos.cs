using System.ComponentModel.DataAnnotations;

namespace LibraryMvc.DTOs
{
    public class AuthorReadDto
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime? BirthDate { get; set; }
        public string Nationality { get; set; }
    }

    public class AuthorCreateDto
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }
    }

    public class AuthorUpdateDto : AuthorCreateDto
    {
        [Required]
        public int AuthorID { get; set; }
    }
}
