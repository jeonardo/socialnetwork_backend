using FinalWebApp_Backend_BLL.Dto.Comment;
using FinalWebApp_Backend_BLL.Services.Interfaces;

namespace FinalWebApp_Backend_BLL.Services.Interface
{
    public interface ICommentService : IBaseService<CommentDto>
    {
        Task<CommentDto> CreateItem(CreateCommentDto model, int userId, string userName);
        Task DeleteItem(int id, int userId);
    }
}
