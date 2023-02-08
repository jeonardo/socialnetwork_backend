using AutoMapper;
using FinalWebApp_Backend_BLL.Dto.Post;
using FinalWebApp_Backend_DAL.Entities;
namespace FinalWebApp_Backend_BLL.AutoMapper
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Post, PostDto>()
               .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.User.UserName));
            CreateMap<CreatePostDto, Post>();
            CreateMap<EditPostDto, Post>();
        }
    }
}
