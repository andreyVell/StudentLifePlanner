using Slp.DataCore.Entities;
using Slp.DataProvider.Repositories.Interfaces;

namespace Slp.DataProvider.Repositories
{
    public class IncomeRepository : RepositoryBase<Income>, IIncomeRepository
    {
        public IncomeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
