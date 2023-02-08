using AutoMapper;
using FinalWebApp_Backend_BLL.Dto.Room;
using FinalWebApp_Backend_DAL.Entities;
namespace FinalWebApp_Backend_BLL.AutoMapper
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile()
        {
            CreateMap<Room, RoomDto>();

            CreateMap<RoomDto, Room>();

        }
    }
}
