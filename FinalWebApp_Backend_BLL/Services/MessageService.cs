using AutoMapper;
using FinalWebApp_Backend_BLL.Dto.Message;
using FinalWebApp_Backend_BLL.Dto.Room;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.UnitOfWork.Interface;
using System.Text.RegularExpressions;

namespace FinalWebApp_Backend_BLL.Services
{
    public class MessageService : IMessageService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IRoomService _roomService;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper, IRoomService roomService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roomService = roomService;
        }
        public async Task<IEnumerable<MessageDto>?> GetMessages(int roomId, int userId)
        {
            var room = await _unitOfWork.RoomRepository.GetItemWithUsers(roomId);
            foreach (var roomUser in room.Users)
            {
                if (roomUser.Id == userId)
                {
                    var messages = await _unitOfWork.MessageRepository.GetItems(roomId);
                    return _mapper.Map<IEnumerable<MessageDto>>(messages);
                }
            }
            return null;
        }

        public async Task<MessageDto> CreateMessage(CreateMessageDto dto, int userId)
        {
            var room = await _unitOfWork.RoomRepository.GetItemWithUsers(dto.RoomToId);
            foreach (var roomUser in room.Users)
            {
                if (roomUser.Id == userId)
                {
                    dto.Content = Regex.Replace(dto.Content, @"<.*?>", string.Empty);
                    Message message = new Message();
                    message.Content = dto.Content;
                    message.UserFromId = userId;
                    message.RoomId = room.Id;
                    await _unitOfWork.MessageRepository.CreateItem(message);
                    return _mapper.Map<MessageDto>(message);
                }
            }
            return null;
        }

        public async Task CreateMessageAndCheck(CreateMessageCheckDto dto, int userId)
        {
            var user = await _unitOfWork.UserRepository.GetItemWithRooms(userId); // set the first user
            var userTo = await _unitOfWork.UserRepository.GetItemWithRooms(dto.UserToId); //get the second user!
            Room saveRoom = new Room();
            var myRooms = user.Rooms;
            foreach (var room in myRooms)
            {
                foreach (var roomUser in room.Users)
                {
                    if (roomUser.Id == dto.UserToId)
                    {
                        saveRoom = room;
                    }
                }
            }
            if (saveRoom.AdminId == null)
            {
                CreateRoomDto createRoomDto = new();
                List<int> insider = new();
                insider.Add(userId);
                insider.Add(dto.UserToId);
                createRoomDto.PartnersId = insider;
                saveRoom = await _roomService.CreateItem(createRoomDto, userId);
            }
            CreateMessageDto createMessageDto = new CreateMessageDto();
            createMessageDto.RoomToId = userId;
            createMessageDto.Content = dto.Content;
            await CreateMessage(createMessageDto, saveRoom.Id);
        }
    }
}