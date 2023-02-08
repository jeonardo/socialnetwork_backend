using FinalWebApp_Backend_BLL.Dto.User;
using FinalWebApp_Backend_BLL.Services.Interfaces;

namespace FinalWebApp_Backend_BLL.Services.Interface
{
    public interface IUserService : IBaseService<UserDto>
    {
        Task<UserDto> GetItem(int id);

        Task<IEnumerable<UserDto>> GetItems(int userId);

        Task EditItem(EditDto user, int userId);

        Task DeleteItem(int id, int userId);

        Task Exclude(int userId);

        Task EditItemByFile(int elementId, string path);

    }
}
