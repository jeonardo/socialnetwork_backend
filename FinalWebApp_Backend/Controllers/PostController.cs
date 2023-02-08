using FinalWebApp_Backend_BLL.Dto.Post;
using FinalWebApp_Backend_BLL.IdentityExtention;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_WEB.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApp_Backend_WEB.Controllers
{
    [Authorize]
    public class PostController : BaseController
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var request = await _postService.GetItems();
            return Ok(request);
        }

        [Route("myposts")]
        [HttpGet]
        public async Task<IActionResult> GetByUser()
        {
            var request = await _postService.GetItemsByUser(User.GetUserId<int>());
            return Ok(request);
        }


        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Post(CreatePostDto model)
        {
            var request = await _postService.CreateItem(model, User.GetUserId<int>(), User.GetUserName());
            return Ok(request);
        }

        [HttpPut]
        [ValidateModel]
        public async Task<IActionResult> Put(EditPostDto model)
        {
            await _postService.EditItem(model, User.GetUserId<int>());
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.DeleteItem(id, User.GetUserId<int>());
            return Ok();
        }
    }
}
