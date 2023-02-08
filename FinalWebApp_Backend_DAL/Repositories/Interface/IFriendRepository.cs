using FinalWebApp_Backend_DAL.Entities;

namespace FinalWebApp_Backend_DAL.Repositories.Interface
{
    public interface IFriendRepository
    {
        Task<IEnumerable<Friend>> Get(int userId);
        Task<Friend> GetFriendshipForRequest(int userId, int id);
        Task<Friend> GetFriendshipBetwenUsers(int userId, int id);
        Task Create(Friend friend);
        Task Response(Friend friend);
        Task Delete(Friend friend);
        Task<IEnumerable<Friend>> GetRequest(int userId);
    }
}
