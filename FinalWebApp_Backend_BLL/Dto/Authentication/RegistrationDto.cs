using System.ComponentModel.DataAnnotations;
namespace FinalWebApp_Backend_BLL.Authentication.Dto
{
    public class RegistrationDto
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2,
         ErrorMessage = "Name must be at least 2 characters long and no more than 10.")]
        public string? Name { get; set;}

        [Required]
        [StringLength(20, MinimumLength = 2,
         ErrorMessage = "Surname must be at least 2 characters long and no more than 20.")]
        public string? Surname { get; set; }
        
        [Required]
        public string? Sex { get; set; }
    }
}
