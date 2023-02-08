using FinalWebApp_Backend_BLL.Dto.Like;
using FinalWebApp_Backend_BLL.IdentityExtention;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_WEB.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApp_Backend_WEB.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class LikeController : BaseController
    {
        private ILikeService _likeService;
        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [ValidateModel]
        [HttpPost]
        public async Task<IActionResult> Post(CreateLikeDto model)
        {
            var likes = await _likeService.CreateItem(model, User.GetUserId<int>());
            return Ok(likes);
        }
    }
}
