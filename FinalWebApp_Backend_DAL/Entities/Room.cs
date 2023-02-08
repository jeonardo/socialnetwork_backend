namespace FinalWebApp_Backend_DAL.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int? AdminId { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Message> Messages { get; set; }

        public Room()
        {
            Users = new HashSet<User>();
            Messages = new HashSet<Message>();
        }
    }
}
