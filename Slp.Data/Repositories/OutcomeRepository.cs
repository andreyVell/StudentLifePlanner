using Slp.Data;
using Slp.Data.Repositories;
using Slp.DataCore.Entities;
using Slp.DataProvider.Repositories.Interfaces;

namespace Slp.DataProvider.Repositories
{
    public class OutcomeRepository : RepositoryBase<Outcome>, IOutcomeRepository
    {
        public OutcomeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
