using Slp.Data;
using Slp.Data.Repositories;
using Slp.DataCore.Entities;
using Slp.DataProvider.Repositories.Interfaces;

namespace Slp.DataProvider.Repositories
{
    public class DailyTaskRepository : RepositoryBase<DailyTask>, IDailyTaskRepository
    {
        public DailyTaskRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
