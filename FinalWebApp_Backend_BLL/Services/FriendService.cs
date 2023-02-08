using AutoMapper;
using FinalWebApp_Backend_BLL.Dto.Friend;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.Entities.FriendStatus;
using FinalWebApp_Backend_DAL.UnitOfWork.Interface;

namespace FinalWebApp_Backend_BLL.Services
{
    public class FriendService : IFriendService
    {
        private IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public FriendService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FriendDto>> Get(int userId)
        {
            var friends = await _unitOfWork.FriendRepository.Get(userId);
            foreach (var friend in friends)
            {
                if (friend.FriendUserId == userId)
                {
                    friend.FriendUser = friend.User;
                }
            }
            return _mapper.Map<IEnumerable<FriendDto>>(friends);
        }

        public async Task<IEnumerable<FriendDto>> GetRequest(int userId)
        {
            var friends = await _unitOfWork.FriendRepository.GetRequest(userId);
            foreach (var friend in friends)
            {
                if (friend.FriendUserId == userId)
                {
                    friend.FriendUser = friend.User;
                }
            }
            return _mapper.Map<IEnumerable<FriendDto>>(friends);
        }

        public async Task Create(CreateFriendDto model, int userId)
        {
            var friendDb = await _unitOfWork.FriendRepository.GetFriendshipBetwenUsers(userId, model.friendid);
            if (friendDb == null)
            {
                var friend = new Friend();
                friend.FriendUserId = model.friendid;
                friend.UserId = userId;
                friend.Status = Status.Request;
                await _unitOfWork.FriendRepository.Create(friend);
            }
        }

        public async Task Response(EditFriendDto model, int userId)
        {
            if (model.Id != userId)
            {
                var friendship = await _unitOfWork.FriendRepository.GetFriendshipForRequest(model.Id, userId);
                if (friendship.FriendUserId == userId && friendship.Status != Status.Friends)
                {
                    if (model.Status == Status.Decline)
                    {
                        await _unitOfWork.FriendRepository.Delete(friendship);
                    }
                    else if (model.Status == Status.Friends)
                    {
                        await _unitOfWork.FriendRepository.Response(friendship);
                    }
                }
            }
        }

        public async Task DeleteFriendShip(int idi, int userId)
        {
            var friendship = await _unitOfWork.FriendRepository.GetFriendshipBetwenUsers(idi, userId);
            if (friendship != null)
            {
                await _unitOfWork.FriendRepository.Delete(friendship);
            }
        }
    }
}
