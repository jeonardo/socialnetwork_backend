using FinalWebApp_Backend_BLL.Dto.Room;
using FinalWebApp_Backend_DAL.Entities;

namespace FinalWebApp_Backend_BLL.Services.Interface
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetItems(int name);

        Task<Room> CreateItem(CreateRoomDto room, int name);
    }
}
