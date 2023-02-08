using FinalWebApp_Backend_BLL.Dto.Room;
using FinalWebApp_Backend_BLL.IdentityExtention;
using FinalWebApp_Backend_BLL.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApp_Backend_WEB.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class RoomController : BaseController
    {
        private IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _roomService.GetItems(User.GetUserId<int>()));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateRoomDto roomDto)
        {
            await _roomService.CreateItem(roomDto, User.GetUserId<int>());
            return Ok();
        }
    }
}
