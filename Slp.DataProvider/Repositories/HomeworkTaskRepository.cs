using Slp.DataCore.Entities;
using Slp.DataProvider.Repositories.Interfaces;

namespace Slp.DataProvider.Repositories
{
    public class HomeworkTaskRepository : RepositoryBase<HomeworkTask>, IHomeworkTaskRepository
    {
        public HomeworkTaskRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
