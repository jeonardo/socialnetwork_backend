using FinalWebApp_Backend_BLL.Authentication.Dto;
using FinalWebApp_Backend_BLL.Dto.Authentication;
using FinalWebApp_Backend_BLL.IdentityExtention;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_WEB.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace FinalWebApp_Backend_WEB.Controllers
{
    public class AuthController : BaseController
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [ValidateModel]
        [Route("login")]
        public async Task<IActionResult> Post([FromBody] LoginDto model)
        {
            var token = await _authService.Login(model, model.Password);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [HttpPost]
        [ValidateModel]
        [Route("register")]
        public async Task<IActionResult> Post([FromBody] RegistrationDto model)
        {
            await _authService.Register(model, model.Password);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        [Route("changePassword")]
        public async Task<IActionResult> Put(ChangePasswordDto user)
        {
            await _authService.ChangePassword(user, User.GetUserId<int>());
            return Ok();
        }
    }
}
