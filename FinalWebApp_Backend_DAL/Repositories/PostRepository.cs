using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinalWebApp_Backend_DAL.Repositories
{
    public class PostRepository : IPostRepository
    {
        private ApplicationContext db;
        public PostRepository(ApplicationContext context) : base()
        {
            this.db = context;
        }

        public async Task<IEnumerable<Post>> GetItems()
        {
            var models = await db.Posts
                 .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .ToListAsync();
            return models;
        }

        public async Task<IEnumerable<Post>> GetItemsByUser(int id)
        {
            var models = await db.Posts
                 .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .Where(p => p.UserId == id)
                .OrderByDescending(p => p.CreatedOn)
                .ToListAsync();
            return models;
        }

        public async Task<Post> GetItem(int id)
        {
            var model = await db.Posts
                .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return model;
        }

        public async Task CreateItem(Post post)
        {
            await db.Posts.AddAsync(post);
            await db.SaveChangesAsync();
        }

        public async Task EditItem(Post post)
        {
            var oldPost = await db.Posts.FindAsync(post.Id);
            oldPost.Title = post.Title;
            oldPost.Content = post.Content;
            oldPost.PictureUrl = post.PictureUrl;
            await db.SaveChangesAsync();
        }

        public async Task DeleteItem(Post post)
        {
            db.Posts.Remove(post);
            await db.SaveChangesAsync();
        }
    }
}

