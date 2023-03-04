namespace Slp.Services.Services.Interfaces
{
    public interface ICurrentUserService : IServiceRegistrator
    {
        Guid GetCurrentUserId();
    }
}
