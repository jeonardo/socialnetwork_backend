using System.ComponentModel.DataAnnotations;
namespace FinalWebApp_Backend_BLL.Authentication.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Login is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
