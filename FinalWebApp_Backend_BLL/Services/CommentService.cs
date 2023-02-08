using AutoMapper;
using FinalWebApp_Backend_BLL.Dto.Comment;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.UnitOfWork.Interface;

namespace FinalWebApp_Backend_BLL.Services
{
    public class CommentService : ICommentService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommentDto> CreateItem(CreateCommentDto model, int userId, string userName)
        {
            var modelNew = _mapper.Map<Comment>(model);
            modelNew.AuthorId = userId;
            await _unitOfWork.CommentRepository.CreateItem(modelNew);
            var returningModel = _mapper.Map<CommentDto>(modelNew);
            returningModel.UserName = userName;
            return returningModel;
        }

        public async Task DeleteItem(int deletedId, int userId)
        {
            var comment = await _unitOfWork.CommentRepository.GetItem(userId);
            if (userId == comment.AuthorId)
            {
                await _unitOfWork.CommentRepository.DeleteItem(comment);
            }
        }
    }
}

