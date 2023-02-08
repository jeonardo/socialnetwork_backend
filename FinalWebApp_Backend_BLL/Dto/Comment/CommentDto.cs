namespace FinalWebApp_Backend_BLL.Dto.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? CommentText { get; set; }

        public int PostId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
