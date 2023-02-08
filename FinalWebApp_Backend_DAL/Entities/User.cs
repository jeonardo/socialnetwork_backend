using Microsoft.AspNetCore.Identity;

namespace FinalWebApp_Backend_DAL.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        
        public bool? ExcludeFromSearch { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime? BirthDate { get; set; }

        public ICollection<Friend> Friends { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Message> Messages { get; set; }


        public User()
        {
            Posts = new HashSet<Post>();
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
            Friends = new HashSet<Friend>();
            Rooms = new HashSet<Room>();
            Messages = new HashSet<Message>();
        }
    }
}
