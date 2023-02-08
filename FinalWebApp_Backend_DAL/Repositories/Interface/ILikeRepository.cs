using FinalWebApp_Backend_DAL.Entities;

namespace FinalWebApp_Backend_DAL.Repositories.Interface
{
    public interface ILikeRepository
    {
        Task<Like> GetItem(int id);
        Task<Like> GetLike(Like like);
        Task CreateItem(Like like);
        Task DeleteItem(Like like);
    }
}
