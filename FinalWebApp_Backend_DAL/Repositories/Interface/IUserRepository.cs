using FinalWebApp_Backend_DAL.Entities;

namespace FinalWebApp_Backend_DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetItem(int userId);
        Task<User> GetItemWithRooms(int userId);
        Task<IEnumerable<User>> GetItems();
        Task EditItem(User model);
        Task DeleteItem(User model);
    }
}
