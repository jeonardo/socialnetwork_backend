using FinalWebApp_Backend_BLL.Dto.User;
using FinalWebApp_Backend_BLL.IdentityExtention;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_WEB.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace FinalWebApp_Backend_WEB.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var request = await _userService.GetItems(User.GetUserId<int>());
            return Ok(request);
        }

        [HttpGet]
        [Route("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var request = await _userService.GetItem(User.GetUserId<int>());
            return Ok(request);
        }

        [HttpPut]
        [ValidateModel]
        public async Task<IActionResult> Put([FromBody] EditDto user)
        {
            await _userService.EditItem(user, User.GetUserId<int>());
            return Ok();
        }

        [HttpPut]
        [Route("execute")]
        public async Task<IActionResult> Put()
        {
            await _userService.Exclude(User.GetUserId<int>());
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteItem(id, User.GetUserId<int>());
            return Ok();
        }
    }
}