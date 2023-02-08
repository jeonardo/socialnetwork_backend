using FinalWebApp_Backend_DAL.Entities.FriendStatus;
using System.ComponentModel.DataAnnotations;

namespace FinalWebApp_Backend_BLL.Dto.Friend
{
    public class EditFriendDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}
