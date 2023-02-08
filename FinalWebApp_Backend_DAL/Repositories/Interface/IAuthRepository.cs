using FinalWebApp_Backend_DAL.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FinalWebApp_Backend_DAL.Repositories.Interface
{
    public interface IAuthRepository
    {
        Task<bool> LoginCheck(User user, string password);
        Task Register(User model, string password);
        Task ChangePassword(User user, string oldPassword, string newPassword);
        Task<User> FindByName(string username);
        Task<JwtSecurityToken> GetTokenByConfig(List<Claim> authClaims);
    }
}
