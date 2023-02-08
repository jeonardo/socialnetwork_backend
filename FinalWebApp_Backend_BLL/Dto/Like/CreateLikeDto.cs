using System.ComponentModel.DataAnnotations;
namespace FinalWebApp_Backend_BLL.Dto.Like
{
    public class CreateLikeDto
    {
        [Required]
        public int PostId { get; set; }
    }
}
