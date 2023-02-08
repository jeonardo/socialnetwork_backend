using FinalWebApp_Backend_DAL.Entities;

namespace FinalWebApp_Backend_DAL.Repositories.Interface
{
    public interface ICommentRepository
    {
        Task<Comment> GetItem(int id);
        Task CreateItem(Comment comment);
        Task DeleteItem(Comment comment);
    }
}
