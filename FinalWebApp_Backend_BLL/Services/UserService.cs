using AutoMapper;
using FinalWebApp_Backend_BLL.Dto.User;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.Entities.FriendStatus;
using FinalWebApp_Backend_DAL.UnitOfWork.Interface;
namespace FinalWebApp_Backend_BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetItems(int userId)
        {
            var friends = await _unitOfWork.FriendRepository.Get(userId);
            IEnumerable<User> usersDb = await _unitOfWork.UserRepository.GetItems();
            var users = _mapper.Map<IEnumerable<UserDto>>(usersDb);
            foreach (var user in users)
            {
                if (friends.Any())
                {
                    foreach (var friend in friends)
                    {
                        if ((user.Id == friend.UserId || user.Id == friend.FriendUserId) && (friend.Status == Status.Request))
                        {
                            user.Status = 0;
                        }
                        else if ((user.Id == friend.UserId || user.Id == friend.FriendUserId) && (friend.Status == Status.Friends))
                        {
                            user.Status = 1;
                        }
                        else
                        {
                            user.Status = 2;
                        }
                    }
                }
                else
                {
                    user.Status = 2;
                }
            }
            return users.OrderBy(x => x.Name).ThenBy(x => x.Surname);
        }

        public async Task<UserDto> GetItem(int userId)
        {
            var user = await _unitOfWork.UserRepository.GetItem(userId);
            return _mapper.Map<UserDto>(user);
        }

        public async Task EditItem(EditDto model, int userId)
        {
            var user = await _unitOfWork.UserRepository.GetItem(userId);
            if (user.Id == userId)
            {
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Sex = model.Sex;
                user.Email = model.Email;
                user.BirthDate = model.BirthDate;
                await _unitOfWork.UserRepository.EditItem(user);
            }
        }

        public async Task Exclude(int userId)
        {
            var user = await _unitOfWork.UserRepository.GetItem(userId);
            if (user.ExcludeFromSearch == null || user.ExcludeFromSearch == false)
            {
                user.ExcludeFromSearch = true;
                await _unitOfWork.UserRepository.EditItem(user);
            }
            else
            {
                user.ExcludeFromSearch = false;
                await _unitOfWork.UserRepository.EditItem(user);
            }

        }

        public async Task EditItemByFile(int userId, string path)
        {
            var user = await _unitOfWork.UserRepository.GetItem(userId);
            user.ProfilePictureUrl = path;
            await _unitOfWork.UserRepository.EditItem(user);
        }

        public Task DeleteItem(int id, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
