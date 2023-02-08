using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinalWebApp_Backend_DAL.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private ApplicationContext db;
        public LikeRepository(ApplicationContext context) : base()
        {
            this.db = context;
        }

        public async Task<Like> GetItem(int id)
        {
            var model = db.Likes
                .Where(p => p.PostId == id)
                .FirstOrDefault();
            return model;
        }

        public async Task<Like> GetLike(Like like)
        {
            var likeDb = await db.Likes
               .Where(l => l.PostId == like.PostId && l.UserId == like.UserId)
               .FirstOrDefaultAsync();
            return likeDb;
        }

        public async Task CreateItem(Like like)
        {
            db.Likes.Add(like);
            await db.SaveChangesAsync();
        }

        public async Task DeleteItem(Like like)
        {
            db.Likes.Remove(like);
            await db.SaveChangesAsync();
        }
    }
}
