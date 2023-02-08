using AutoMapper;
using FinalWebApp_Backend_BLL.Dto.Message;
using FinalWebApp_Backend_DAL.Entities;
namespace FinalWebApp_Backend_BLL.AutoMapper
{
    public class MessageMappingProfile : Profile
    {
        public MessageMappingProfile()
        {
            CreateMap<Message, MessageDto>()
            .ForMember(c => c.UserFromName, opt => opt.MapFrom(c => c.UserFrom.UserName));
            CreateMap<MessageDto, Message>();
        }
    }
}
