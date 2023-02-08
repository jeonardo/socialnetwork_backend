using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinalWebApp_Backend_DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private ApplicationContext db;
        public MessageRepository(ApplicationContext context) : base()
        {
            this.db = context;
        }

        public async Task<IEnumerable<Message>> GetItems(int id)
        {
            var messages = await db.Messages
                .Where(m => m.RoomId == id)
                .OrderByDescending(m => m.Timestamp)
                .Reverse()
                .ToListAsync();

            return messages;
        }

        public async Task CreateItem(Message message)
        {
            await db.Messages.AddAsync(message);
            await db.SaveChangesAsync();
        }
    }
}