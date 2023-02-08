using FinalWebApp_Backend_BLL.Dto.Post;
using FinalWebApp_Backend_BLL.Services.Interfaces;

namespace FinalWebApp_Backend_BLL.Services.Interface
{
    public interface IPostService : IBaseService<PostDto>
    {
        Task<IEnumerable<PostDto>> GetItems();
        Task<IEnumerable<PostDto>> GetItemsByUser(int userId);
        Task<PostDto> CreateItem(CreatePostDto model, int userId, string userName);
        Task DeleteItem(int id, int userId);
        Task EditItem(EditPostDto model, int userId);
        Task EditItemByFile(int elementId, int userId, string path);
    }
}
