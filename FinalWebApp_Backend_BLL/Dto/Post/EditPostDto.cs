namespace FinalWebApp_Backend_BLL.Dto.Post
{
    public class EditPostDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? PictureUrl { get; set; }
    }
}
