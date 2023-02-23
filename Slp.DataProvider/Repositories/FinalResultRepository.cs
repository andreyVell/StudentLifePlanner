using Slp.DataCore.Entities;
using Slp.DataProvider.Repositories.Interfaces;

namespace Slp.DataProvider.Repositories
{
    public class FinalResultRepository : RepositoryBase<FinalResult>, IFinalResultRepository
    {
        public FinalResultRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
