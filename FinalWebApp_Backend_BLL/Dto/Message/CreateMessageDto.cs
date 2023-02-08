using System.ComponentModel.DataAnnotations;
namespace FinalWebApp_Backend_BLL.Dto.Message
{
    public class CreateMessageDto
    {
        [Required]
        public string? Content { get; set; }

        [Required]
        public int RoomToId { get; set; }
    }
}
