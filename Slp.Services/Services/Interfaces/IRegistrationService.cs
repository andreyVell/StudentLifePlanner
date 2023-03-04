using Slp.Services.Models.User;

namespace Slp.Services.Services.Interfaces
{
    public interface IRegistrationService : IServiceRegistrator
    {
        Task<Guid> CreateNewUserAsync(CreateUserModel newUser);
    }
}
