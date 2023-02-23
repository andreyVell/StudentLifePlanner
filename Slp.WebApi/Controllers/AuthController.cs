using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Slp.Services.Services.Interfaces;
using Slp.WebApi.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Slp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static UserModel user = new UserModel();
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;


        public AuthController(IConfiguration configuration,
            IAuthService service)
        {
            _configuration = configuration;
            _authService = service;
        }

        [HttpGet, Authorize]
        [Route("/get_me")]
        public ActionResult<Guid> GetMe()
        {            
            return Ok(_authService.GetCurrentUserId());
        }

        [HttpPost]
        [Route("/register")]
        public async Task<ActionResult<UserModel>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            user.Id = new Guid("9484836C-F5EF-4922-99C7-800FA6EFEA62");
            user.UserName = request.Username; 
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user);
        }

        [HttpPost]
        [Route("/login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            if (user.UserName != request.Username)
            {
                return BadRequest("User not found");
            }

            if (!IsPasswordVerifiedHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong pass");
            }

            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(UserModel user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
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


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool IsPasswordVerifiedHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
