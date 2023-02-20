using Slp.Data;
using Slp.Data.Repositories;
using Slp.DataCore.Entities;
using Slp.DataProvider.Repositories.Interfaces;

namespace Slp.DataProvider.Repositories
{
    public class JobIncomeRepository : RepositoryBase<JobIncome>, IJobIncomeRepository
    {
        public JobIncomeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
