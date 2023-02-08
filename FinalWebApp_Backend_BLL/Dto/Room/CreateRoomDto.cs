using System.ComponentModel.DataAnnotations;

namespace FinalWebApp_Backend_BLL.Dto.Room
{
    public class CreateRoomDto
    {
        [Required]
        public IEnumerable<int>? PartnersId { get; set; }
    }
}
