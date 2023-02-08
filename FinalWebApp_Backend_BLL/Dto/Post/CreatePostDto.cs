using System.ComponentModel.DataAnnotations;

namespace FinalWebApp_Backend_BLL.Dto.Post
{
    public class CreatePostDto
    {
        [StringLength(10, MinimumLength = 4,
        ErrorMessage = "Title of post must be at least 2 characters long and no more than 10.")]
        public string Title { get; set; }

        [StringLength(3000, MinimumLength = 3,
          ErrorMessage = "Name must be at least 2 characters long and no more than 3000.")]
        public string Content { get; set; }
    }
}
