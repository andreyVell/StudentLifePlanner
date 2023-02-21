using Slp.Data;
using Slp.Data.Repositories;
using Slp.DataCore.Entities;
using Slp.DataProvider.Repositories.Interfaces;

namespace Slp.DataProvider.Repositories
{
    public class BookRepositoryL : RepositoryBase<Book>, IBookRepository
    {
        public BookRepositoryL(ApplicationDbContext context) : base(context)
        {
        }
    }
}
