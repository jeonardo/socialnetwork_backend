using FinalWebApp_Backend_BLL.Dto.Friend.Enum;
namespace FinalWebApp_Backend_BLL.Dto.Friend
{
    public class FriendDto
    {
        public int UserId { get; set; }

        public int FriendUserId { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Sex { get; set; }

        public StatusFriend Status { get; set; }

        public string? ProfilePictureUrl { get; set; }
    }
}
