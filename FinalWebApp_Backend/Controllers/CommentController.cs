using FinalWebApp_Backend_BLL.Dto.Comment;
using FinalWebApp_Backend_BLL.IdentityExtention;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_WEB.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApp_Backend_WEB.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CommentController : BaseController
    {
        private ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Post(CreateCommentDto model)
        {
            var request = await _commentService.CreateItem(model, User.GetUserId<int>(), User.GetUserName());
            return Ok(request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentService.DeleteItem(id, User.GetUserId<int>());
            return Ok();
        }
    }
}
