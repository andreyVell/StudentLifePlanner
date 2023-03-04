using Slp.Services.Models.User;

namespace Slp.Services.Services.Interfaces
{
    public interface IAuthenticationService : IServiceRegistrator
    {        
        Task<string> LoginAsync(LoginUserModel user);
    }
}
