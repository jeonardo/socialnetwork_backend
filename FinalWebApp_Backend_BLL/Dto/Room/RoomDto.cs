using FinalWebApp_Backend_BLL.Dto.User;

namespace FinalWebApp_Backend_BLL.Dto.Room
{
    public class RoomDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? AdminId { get; set; }

        public IEnumerable<UserDto>? Users { get; set; }

    }
}
