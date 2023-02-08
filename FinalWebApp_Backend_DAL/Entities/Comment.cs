using System.ComponentModel.DataAnnotations.Schema;

namespace FinalWebApp_Backend_DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int? AuthorId { get; set; }
        public User? Author { get; set; }
        public string? CommentText { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post? Post { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
