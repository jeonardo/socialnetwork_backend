using FinalWebApp_Backend_BLL.Authentication.Dto;
using FinalWebApp_Backend_BLL.Dto.Authentication;
using FinalWebApp_Backend_BLL.Dto.User;
using FinalWebApp_Backend_BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace FinalWebApp_Backend_BLL.Services.Interface
{
    public interface IAuthService : IBaseService<UserDto>
    {
        Task<JwtSecurityToken> Login([FromBody] LoginDto model, string password);

        Task Register([FromBody] RegistrationDto model, string password);

        Task ChangePassword(ChangePasswordDto model, int id);
    }
}
