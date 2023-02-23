using Slp.DataProvider;
using Slp.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Slp.Services.Models.User;
using Slp.DataCore.Exceptions.User;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using Slp.DataCore.Entities;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace Slp.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public AuthenticationService(
            IUnitOfWork unitOfWork, 
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> LoginAsync(LoginUserModel user)
        {
            if (string.IsNullOrEmpty(user.Login))
            {
                throw new UserLoginException("Enter login");
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                throw new UserLoginException("Enter password");
            }

            var dbUser = await _unitOfWork.Users.GetFirstWhereAsync(e=>e.Login== user.Login);
            if (dbUser == null)
            {
                throw new UserLoginException("User not found");
            }
            else
            {
                if (dbUser.PasswordHash != CreatePasswordHash(user.Password, dbUser.PasswordSalt))
                {
                    throw new UserLoginException("Wrong password");
                }
                else
                {
                    string token = CreateToken(dbUser);
                    return token;
                }     
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private string CreatePasswordHash(string password, string passwordSalt)
        {
            return Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password,
                    Encoding.ASCII.GetBytes(passwordSalt),
                    KeyDerivationPrf.HMACSHA256,
                    5000,
                    64));
        }
    }
}
