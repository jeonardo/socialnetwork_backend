using FinalWebApp_Backend_BLL.Dto.Message;

namespace FinalWebApp_Backend_BLL.Services.Interface
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDto>?> GetMessages(int roomId, int userId);
        Task<MessageDto> CreateMessage(CreateMessageDto dto, int userId);
        Task CreateMessageAndCheck(CreateMessageCheckDto dto, int userId);
    }
}
