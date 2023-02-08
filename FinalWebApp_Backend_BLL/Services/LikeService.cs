using AutoMapper;
using FinalWebApp_Backend_BLL.Dto.Like;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.UnitOfWork.Interface;

namespace FinalWebApp_Backend_BLL.Services
{
    public class LikeService : ILikeService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public LikeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LikeDto>> CreateItem(CreateLikeDto model, int userId)
        {
            var post = await _unitOfWork.PostRepository.GetItem(model.PostId);
            var returningLikes = post.Likes;
            var existingLike = returningLikes.FirstOrDefault(p => p.UserId == userId);
            if (existingLike == null)
            {
                var like = _mapper.Map<Like>(model);
                like.UserId = userId;
                await _unitOfWork.LikeRepository.CreateItem(like);
                returningLikes.Add(like);
            }
            else
            {
                await _unitOfWork.LikeRepository.DeleteItem(existingLike);
                returningLikes.Remove(existingLike); 
            }
            return _mapper.Map<IEnumerable<LikeDto>>(returningLikes);
        }
    }
}
