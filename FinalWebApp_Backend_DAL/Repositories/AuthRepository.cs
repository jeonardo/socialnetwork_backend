using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalWebApp_Backend_DAL.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthRepository(UserManager<User> userManager, IConfiguration configuration) : base()
        {
            this._userManager = userManager;
            this._configuration = configuration;
        }

        public async Task<User> FindByName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user;
        }

        public async Task<bool> LoginCheck(User user, string password)
        {
            var result = await _userManager.CheckPasswordAsync(user, password);
            return result;
        }

        public async Task Register(User model, string password)
        {
            await _userManager.CreateAsync(model, password);
        }

        public async Task ChangePassword(User user, string oldPassword, string newPassword)
        {
            await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task<JwtSecurityToken> GetTokenByConfig(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JWT:Expiries"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }
    }
}
