using FinalWebApp_Backend_BLL.Dto.File;
using FinalWebApp_Backend_BLL.IdentityExtention;
using FinalWebApp_Backend_BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace FinalWebApp_Backend_WEB.Controllers
{
    [Authorize]
    public class FileController : BaseController
    {
        private IWebHostEnvironment _appEnvironment;
        private IUserService _userService;
        private IPostService _postService;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnv;

        public FileController(
            Microsoft.AspNetCore.Hosting.IHostingEnvironment env,
            IWebHostEnvironment appEnvironment,
            IUserService userService,
            IPostService postService)
        {
            _appEnvironment = appEnvironment;
            _userService = userService;
            _postService = postService;
            _hostingEnv = env;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<ActionResult> PostInPost([FromForm] FileModelDto file)
        {
            string userName = User.GetUserName();
            int userId = User.GetUserId<int>();
            try
            {
                string FilePath = Path.Combine(_hostingEnv.WebRootPath, "posts", userName);
                if (!Directory.Exists(FilePath))
                    Directory.CreateDirectory(FilePath);
                var fileName = file.FormFile.FileName;
                var filePath = Path.Combine(FilePath, fileName);
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    file.FormFile.CopyTo(fs);
                }
                await _postService.EditItemByFile(file.ElementId, userId, fileName);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Microsoft.AspNetCore.Mvc.Route("profile")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<ActionResult> PostInUser([FromForm] ModelDto file)
        {
            string userName = User.GetUserName();
            int userId = User.GetUserId<int>();
            try
            {
                string FilePath = Path.Combine(_hostingEnv.WebRootPath, "users", userName);
                if (!Directory.Exists(FilePath))
                    Directory.CreateDirectory(FilePath);
                var fileName = file.FormFile.FileName;
                var filePath = Path.Combine(FilePath, fileName);
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    file.FormFile.CopyTo(fs);
                }
                await _userService.EditItemByFile(userId, fileName);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
