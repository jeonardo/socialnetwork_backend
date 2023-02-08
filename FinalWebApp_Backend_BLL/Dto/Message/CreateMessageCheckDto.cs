using System.ComponentModel.DataAnnotations;
namespace FinalWebApp_Backend_BLL.Dto.Message
{
    public class CreateMessageCheckDto
    {
        [Required]
        public string? Content { get; set; }

        [Required]
        public int UserToId { get; set; }
    }
}
