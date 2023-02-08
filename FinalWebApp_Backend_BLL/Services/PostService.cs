using AutoMapper;
using FinalWebApp_Backend_BLL.Dto.Post;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.UnitOfWork.Interface;

namespace FinalWebApp_Backend_BLL.Services
{
    public class PostService : IPostService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostDto>> GetItems()
        {
            var posts = await _unitOfWork.PostRepository.GetItems();
            var returningModel = _mapper.Map<IEnumerable<PostDto>>(posts);
            return returningModel;
        }

        public async Task<IEnumerable<PostDto>> GetItemsByUser(int userId)
        {
            var posts = await _unitOfWork.PostRepository.GetItemsByUser(userId);
            var returningModel = _mapper.Map<IEnumerable<PostDto>>(posts);
            return returningModel;
        }

        public async Task<PostDto> CreateItem(CreatePostDto model, int userId, string userName)
        {
            var modelNew = _mapper.Map<Post>(model);
            modelNew.UserId = userId;
            await _unitOfWork.PostRepository.CreateItem(modelNew);
            var returningModel = _mapper.Map<PostDto>(modelNew);
            returningModel.UserName = userName;
            return returningModel;
        }

        public async Task EditItem(EditPostDto model, int userId)
        {
            var post = await _unitOfWork.PostRepository.GetItem(model.Id);
            if (userId == post.UserId)
            {
                await _unitOfWork.PostRepository.EditItem(_mapper.Map<Post>(model));
            }
        }

        public async Task EditItemByFile(int elementId, int userId, string path)
        {
            var post = await _unitOfWork.PostRepository.GetItem(elementId);
            if (post.UserId == userId)
            {
                post.PictureUrl = path;
                await _unitOfWork.PostRepository.EditItem(post);
            }
        }

        public async Task DeleteItem(int postid, int userId)
        {
            var post = await _unitOfWork.PostRepository.GetItem(postid);
            if (userId == post.UserId)
            {
                await _unitOfWork.PostRepository.DeleteItem(post);
            }
        }
    }
}
