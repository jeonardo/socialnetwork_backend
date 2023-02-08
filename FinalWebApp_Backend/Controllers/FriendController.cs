using FinalWebApp_Backend_BLL.Dto.Friend;
using FinalWebApp_Backend_BLL.IdentityExtention;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_WEB.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApp_Backend_WEB.Controllers
{
    [Authorize]
    public class FriendController : BaseController
    {
        IFriendService _friendService;
        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var request = await _friendService.Get(User.GetUserId<int>());
            return Ok(request);
        }

        [HttpGet]
        [Route("request")]
        public async Task<IActionResult> GetRequest()
        {
            var request = await _friendService.GetRequest(User.GetUserId<int>());
            return Ok(request);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Post(CreateFriendDto friend)
        {
            await _friendService.Create(friend, User.GetUserId<int>());
            return Ok();
        }

        [HttpPut]
        [ValidateModel]
        public async Task<IActionResult> Put(EditFriendDto friend)
        {
            await _friendService.Response(friend, User.GetUserId<int>());
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _friendService.DeleteFriendShip(id, User.GetUserId<int>());
            return Ok();
        }
    }
}
