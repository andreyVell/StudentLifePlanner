using Slp.Data;
using Slp.Data.Repositories;
using Slp.DataCore.Entities;
using Slp.DataProvider.Repositories.Interfaces;

namespace Slp.DataProvider.Repositories
{
    public class PeriodicOutcomeRepository : RepositoryBase<PeriodicOutcome>, IPeriodicOutcomeRepository
    {
        public PeriodicOutcomeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
