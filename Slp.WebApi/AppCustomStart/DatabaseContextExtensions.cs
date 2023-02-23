using Microsoft.EntityFrameworkCore;
using Slp.DataProvider;

namespace Slp.WebApi.AppCustomStart
{
    public static class DatabaseContextExtensions
    {
        public static void AddCustomSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionString));
            services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.Migrate(); // DB automigration on start enable
        }
    }
}
