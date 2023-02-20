using Slp.Data;
using Slp.Data.Repositories;
using Slp.DataCore.Entities;
using Slp.DataProvider.Repositories.Interfaces;

namespace Slp.DataProvider.Repositories
{
    public class TrainingPlanRepository : RepositoryBase<TrainingPlan>, ITrainingPlanRepository
    {
        public TrainingPlanRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
