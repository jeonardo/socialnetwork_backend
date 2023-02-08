using AutoMapper;
using FinalWebApp_Backend_BLL.Dto.Comment;
using FinalWebApp_Backend_DAL.Entities;
namespace FinalWebApp_Backend_BLL.AutoMapper
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.Author.UserName));
            CreateMap<CreateCommentDto, Comment>();
        }
    }
}
