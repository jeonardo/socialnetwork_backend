using AutoMapper;
using FinalWebApp_Backend_BLL.Authentication.Dto;
using FinalWebApp_Backend_BLL.Dto.Friend;
using FinalWebApp_Backend_BLL.Dto.User;
using FinalWebApp_Backend_DAL.Entities;
namespace FinalWebApp_Backend_BLL.AutoMapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegistrationDto, User>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.Email));

            CreateMap<LoginDto, User>();

            CreateMap<UserDto, User>();

            CreateMap<User, UserDto>();

            CreateMap<EditDto, User>();

            CreateMap<CreateFriendDto, Friend>();

        }
    }
}
