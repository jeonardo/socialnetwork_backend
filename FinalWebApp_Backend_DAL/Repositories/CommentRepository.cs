using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinalWebApp_Backend_DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationContext db;
        public CommentRepository(ApplicationContext context) : base()
        {
            this.db = context;
        }

        public async Task<Comment> GetItem(int id)
        {
            var model = await db.Comments
                .Where(p => p.Id == id)
                .Include(p => p.Author)
                .FirstOrDefaultAsync();
            return model;
        }

        public async Task CreateItem(Comment comment)
        {
            db.Comments.Add(comment);
            await db.SaveChangesAsync();
        }

        public async Task DeleteItem(Comment comment)
        {
            db.Comments.Remove(comment);
            await db.SaveChangesAsync();
        }
    }
}
