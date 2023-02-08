using AutoMapper;
using FinalWebApp_Backend_BLL.Authentication.Dto;
using FinalWebApp_Backend_BLL.Dto.Authentication;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FinalWebApp_Backend_BLL.Services
{
    public class AuthService : IAuthService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<JwtSecurityToken> Login([FromBody] LoginDto model, string password)
        {
            var checkUser = await _unitOfWork.AuthRepository.FindByName(model.UserName);
            if (checkUser != null && await _unitOfWork.AuthRepository.LoginCheck(checkUser, password))
            {
                return await GetJwtToken(checkUser);
            }
            return null;
        }

        public async Task Register([FromBody] RegistrationDto model, string password)
        {
            var user = _mapper.Map<User>(model);
            user.SecurityStamp = Guid.NewGuid().ToString();
            var userExists = _unitOfWork.AuthRepository.FindByName(user.Email);
            if (userExists != null)
            {
                await _unitOfWork.AuthRepository.Register(user, password);
            }
        }

        public async Task ChangePassword(ChangePasswordDto model, int id)
        {
            var userDb = await _unitOfWork.UserRepository.GetItem(id);
            userDb.SecurityStamp = Guid.NewGuid().ToString();
            await _unitOfWork.AuthRepository.ChangePassword(userDb, model.OldPassword, model.NewPassword);
        }

        private async Task<JwtSecurityToken> GetJwtToken(User user)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
            var token = await _unitOfWork.AuthRepository.GetTokenByConfig(authClaims);
            return token;
        }
    }
}
