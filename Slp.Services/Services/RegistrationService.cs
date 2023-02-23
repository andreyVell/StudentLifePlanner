using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Slp.DataCore.Entities;
using Slp.DataCore.Exceptions.User;
using Slp.DataProvider;
using Slp.Services.Models.User;
using Slp.Services.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Slp.Services.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegistrationService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public async Task<Guid> CreateNewUserAsync(CreateUserModel newUser)
        {
            //проверить валидность полей
            if (newUser == null)
            {
                throw new UserCreateException("Empty user data");
            }
            if (string.IsNullOrEmpty(newUser.FirstName))
            {
                throw new UserCreateException("Enter FirstName");
            }
            if (string.IsNullOrEmpty(newUser.Login))
            {
                throw new UserCreateException("Enter login");
            }
            if (string.IsNullOrEmpty(newUser.Password))
            {
                throw new UserCreateException("Enter password");
            }
            //проверить есть ли уже такой пользователь в бд (по логину)
            if (await _unitOfWork.Users.AnyAsync(e=>e.Login == newUser.Login))
            {
                throw new UserCreateException("A user login already exists");
            }
            
            //если все ок то регистрируем            

            var user = new User();
            user.FirstName = newUser.FirstName;
            user.Login = newUser.Login;
            user.PasswordSalt = Guid.NewGuid().ToString();
            user.PasswordHash = CreatePasswordHash(newUser.Password, user.PasswordSalt);

            var result = await _unitOfWork.Users.InsertAsync(user);
            return result.Id;
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
