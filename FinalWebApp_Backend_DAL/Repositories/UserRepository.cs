using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinalWebApp_Backend_DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext db;
        private readonly UserManager<User> _userManager;
        public UserRepository(ApplicationContext context, UserManager<User> userManager) : base()
        {
            this.db = context;
            this._userManager = userManager;
        }

        public async Task<IEnumerable<User>> GetItems()
        {
            List<User> users = await db.Users
                .Where(u => (u.ExcludeFromSearch != true))
                .ToListAsync();
            return users;
        }

        public async Task<User> GetItem(int userId)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }

        public async Task<User> GetItemWithRooms(int userId)
        {
            var user = await db.Users
                .Include(u => u.Rooms)
                .FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }

        public async Task EditItem(User user)
        {
            await _userManager.UpdateAsync(user);
            await db.SaveChangesAsync();
        }

        public async Task DeleteItem(User user)
        {
            await _userManager.DeleteAsync(user);
        }
    }
}
