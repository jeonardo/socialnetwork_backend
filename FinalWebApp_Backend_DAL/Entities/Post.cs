using FinalWebApp_Backend_DAL.Entities.FriendStatus;

namespace FinalWebApp_Backend_DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User User { get; set; }

        public string? PictureUrl { get; set; }

        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public Post()
        {
            Likes = new HashSet<Like>();
            Comments = new HashSet<Comment>();
        }
    }
}
