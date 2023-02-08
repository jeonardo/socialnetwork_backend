using FinalWebApp_Backend_DAL.Entities.FriendStatus;

namespace FinalWebApp_Backend_DAL.Entities
{
    public class Friend
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }

        public int FriendUserId { get; set; }

        public User? FriendUser { get; set; }

        public Status Status { get; set; }
    }
}
