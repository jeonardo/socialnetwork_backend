using FinalWebApp_Backend_BLL.Dto.Friend;
using FinalWebApp_Backend_BLL.Services.Interfaces;

namespace FinalWebApp_Backend_BLL.Services.Interface
{
    public interface IFriendService : IBaseService<FriendDto>
    {
        Task<IEnumerable<FriendDto>> Get(int userId);

        Task<IEnumerable<FriendDto>> GetRequest(int userId);

        Task Create(CreateFriendDto friend, int userId);

        Task Response(EditFriendDto friend, int userId);

        Task DeleteFriendShip(int id, int userId);
    }
}
