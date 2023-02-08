namespace FinalWebApp_Backend_BLL.Dto.Message
{
    public class MessageDto
    {
        public int Id { get; set; }

        public string? Content { get; set; }

        public DateTime? Timestamp { get; set; }

        public string? UserFromName { get; set; }

        public int? UserFromId { get; set; }

        public int? RoomId { get; set; }
    }
}
