using FinalWebApp_Backend_DAL.Entities;

namespace FinalWebApp_Backend_DAL.Repositories.Interface
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetItems();
        Task<IEnumerable<Post>> GetItemsByUser(int id);
        Task<Post> GetItem(int id);
        Task CreateItem(Post post);
        Task EditItem(Post post);
        Task DeleteItem(Post post);
    }
}
