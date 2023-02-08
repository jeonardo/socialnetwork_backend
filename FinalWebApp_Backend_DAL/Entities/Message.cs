namespace FinalWebApp_Backend_DAL.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public string? Content { get; set; }

        public DateTime? Timestamp { get; set; } = DateTime.Now;

        public int? UserFromId { get; set; }

        public User? UserFrom { get; set; }

        public int? RoomId { get; set; }

        public Room? Room { get; set; }
    }
}
