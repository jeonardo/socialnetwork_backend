using System.ComponentModel.DataAnnotations;

namespace FinalWebApp_Backend_BLL.Dto.User
{
    public class EditDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Surname { get; set; }

        [Required]
        public string? Sex { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }
    }
}
