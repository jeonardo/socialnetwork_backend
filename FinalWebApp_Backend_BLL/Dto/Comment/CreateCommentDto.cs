using System.ComponentModel.DataAnnotations;
namespace FinalWebApp_Backend_BLL.Dto.Comment
{
    public class CreateCommentDto
    {
        [StringLength(100, MinimumLength = 2,
         ErrorMessage = "Name must be at least 2 characters long and no more than 100.")]
        public string? CommentText { get; set; }
        public int PostId { get; set; }
    }
}
