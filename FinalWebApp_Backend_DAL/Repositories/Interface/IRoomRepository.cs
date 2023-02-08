using FinalWebApp_Backend_DAL.Entities;

namespace FinalWebApp_Backend_DAL.Repositories.Interface
{
    public interface IRoomRepository
    {
        Task<Room> GetRoomBetweenTwoUsers(int userToId, int userFromId);

        Task<List<Room>> GetItemsWithUsers();

        Task<Room> GetItemWithUsers(int id);

        Task CreateItem(Room room);
    }
}
