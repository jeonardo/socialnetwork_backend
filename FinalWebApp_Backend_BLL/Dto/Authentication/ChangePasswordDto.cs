using System.ComponentModel.DataAnnotations;
namespace FinalWebApp_Backend_BLL.Dto.Authentication
{
    public class ChangePasswordDto
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? NewPassword { get; set; }
    }
}
