using FinalWebApp_Backend_BLL.Dto.Comment;
using FinalWebApp_Backend_BLL.Dto.Like;

namespace FinalWebApp_Backend_BLL.Dto.Post
{
    public class PostDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public string? PictureUrl { get; set; }

        public string? UserName { get; set; }

        public int UserId { get; set; }

        public ICollection<LikeDto>? Likes { get; set; }

        public ICollection<CommentDto>? Comments { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
