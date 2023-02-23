using Slp.DataCore.Entities;
using Slp.DataProvider.Repositories.Interfaces;

namespace Slp.DataProvider.Repositories
{
    public class JobTaskRepository : RepositoryBase<JobTask>, IJobTaskRepository
    {
        public JobTaskRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
