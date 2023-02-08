namespace FinalWebApp_Backend_DAL.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
