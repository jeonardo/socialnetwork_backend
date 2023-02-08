using FinalWebApp_Backend_BLL.Dto.Like;
using FinalWebApp_Backend_BLL.Services.Interfaces;

namespace FinalWebApp_Backend_BLL.Services.Interface
{
    public interface ILikeService : IBaseService<LikeDto>
    {
        Task<IEnumerable<LikeDto>> CreateItem(CreateLikeDto model, int userId);
    }
}
