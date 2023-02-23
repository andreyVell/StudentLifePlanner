using Slp.Services.Models.User;

namespace Slp.Services.Services.Interfaces
{
    public interface IAuthenticationService
    {        
        Task<string> LoginAsync(LoginUserModel user);
    }
}
