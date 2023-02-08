using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.Entities.FriendStatus;
using FinalWebApp_Backend_DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinalWebApp_Backend_DAL.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private ApplicationContext db;
        public FriendRepository(ApplicationContext context) : base()
        {
            this.db = context;
        }

        public async Task<IEnumerable<Friend>> Get(int userId)
        {
            var friends = await db.Friends
                .Where(p => (p.UserId == userId || p.FriendUserId == userId) && p.Status == Status.Friends)
                .Include(f => f.User)
                .Include(f => f.FriendUser)
                .ToListAsync();
            return friends;
        }

        public async Task<IEnumerable<Friend>> GetRequest(int userId)
        {
            var friends = await db.Friends
                .Where(p => p.FriendUserId == userId && p.Status == Status.Request)
                .Include(f => f.User)
                .ToListAsync();
            return friends;
        }

        public async Task<Friend> GetFriendshipForRequest(int userId, int id)
        {
            var friend = await db.Friends
                .Where(p => p.FriendUserId == id && p.UserId == userId)
                .FirstOrDefaultAsync();
            return friend;
        }

        public async Task<Friend> GetFriendshipBetwenUsers(int userId, int id)
        {
            var friend = await db.Friends.Where(f =>
            (f.UserId == userId && f.FriendUserId == id) || (f.UserId == id && f.FriendUserId == userId))
                .FirstOrDefaultAsync();
            return friend;
        }

        public async Task Create(Friend friend)
        {
            db.Friends.Add(friend);
            await db.SaveChangesAsync();
        }

        public async Task Response(Friend friend)
        {
            friend.Status = Status.Friends;
            db.Friends.Update(friend);
            await db.SaveChangesAsync();
        }
        public async Task Delete(Friend friend)
        {
            db.Friends.Remove(friend);
            await db.SaveChangesAsync();
        }
    }
}

