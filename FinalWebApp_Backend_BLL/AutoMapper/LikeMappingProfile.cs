using AutoMapper;
using FinalWebApp_Backend_BLL.Dto.Like;
using FinalWebApp_Backend_DAL.Entities;
namespace FinalWebApp_Backend_BLL.AutoMapper
{
    public class LikeMappingProfile : Profile
    {
        public LikeMappingProfile()
        {
            CreateMap<Like, LikeDto>();

            CreateMap<CreateLikeDto, Like>();
        }
    }
}
