using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinalWebApp_Backend_DAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private ApplicationContext db;
        public RoomRepository(ApplicationContext context) : base()
        {
            this.db = context;
        }

        public async Task<List<Room>> GetItemsWithUsers()
        {
            var models = await db.Rooms
                .Include(p => p.Users)
                .ToListAsync();
            return models;
        }

        public async Task<Room> GetItemWithUsers(int id)
        {
            var model = await db.Rooms
                .Include(p => p.Users)
                .FirstOrDefaultAsync(u => u.Id == id);
            return model;
        }

        public async Task CreateItem(Room model)
        {
            await db.Rooms.AddAsync(model);
            await db.SaveChangesAsync();
        }

        public Task<Room> GetRoomBetweenTwoUsers(int userToId, int userFromId)
        {
            throw new NotImplementedException();
        }
    }
}
