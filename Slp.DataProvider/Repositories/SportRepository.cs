using Slp.DataCore.Entities;
using Slp.DataProvider.Repositories.Interfaces;

namespace Slp.DataProvider.Repositories
{
    public class SportRepository : RepositoryBase<Sport>, ISportRepository
    {
        public SportRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
