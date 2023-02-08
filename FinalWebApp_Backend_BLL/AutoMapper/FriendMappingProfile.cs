using AutoMapper;
using FinalWebApp_Backend_BLL.Dto.Friend;
using FinalWebApp_Backend_DAL.Entities;
namespace FinalWebApp_Backend_BLL.AutoMapper
{
    public class FriendMappingProfile : Profile
    {
        public FriendMappingProfile()
        {
            CreateMap<Friend, FriendDto>()
                  .ForMember(c => c.Email, opt => opt.MapFrom(c => c.FriendUser.Email))
                 .ForMember(c => c.Name, opt => opt.MapFrom(c => c.FriendUser.Name))
                 .ForMember(c => c.Surname, opt => opt.MapFrom(c => c.FriendUser.Surname))
                 .ForMember(c => c.Sex, opt => opt.MapFrom(c => c.FriendUser.Sex))
                 .ForMember(c => c.Status, opt => opt.MapFrom(c => c.Status))
                 .ForMember(c => c.ProfilePictureUrl, opt => opt.MapFrom(c => c.FriendUser.ProfilePictureUrl))
                 .ForMember(c => c.Username, opt => opt.MapFrom(c => c.FriendUser.UserName));
        }
    }
}
