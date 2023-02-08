using AutoMapper;
using FinalWebApp_Backend_BLL.Dto.Room;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.UnitOfWork.Interface;
namespace FinalWebApp_Backend_BLL.Services
{
    public class RoomService : IRoomService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomDto>> GetItems(int userId)
        {
            var userDb = await _unitOfWork.UserRepository.GetItem(userId);
            var roomsDb = await _unitOfWork.RoomRepository.GetItemsWithUsers();
            var myRooms = new List<Room>();
            foreach (var room in roomsDb)
            {
                if (room.Users.Contains(userDb))
                    myRooms.Add(room);
            }
            return _mapper.Map<IEnumerable<RoomDto>>(myRooms);
        }

        public async Task<Room> CreateItem(CreateRoomDto roomDto, int userId)
        {
            var partners = new List<User>();
            foreach (var partner in roomDto.PartnersId)
            {
                partners.Add(await _unitOfWork.UserRepository.GetItem(partner));
            }
            Room result = new Room();
            result.Users = partners;
            result.AdminId = userId;
            await _unitOfWork.RoomRepository.CreateItem(result);
            return result;
        }
    }
}