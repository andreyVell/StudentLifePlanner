using Slp.Services.Models.User;

namespace Slp.Services.Services.Interfaces
{
    public interface ICurrentUserService : IServiceRegistrator
    {
        Guid GetCurrentUserId();

        Task<GetUserModel> GetCurrentUserAsync();

        Task<Guid> EditCurrentUserAsync(EditUserModel user);
    }
}
