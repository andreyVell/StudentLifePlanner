using Slp.DataCore.Entities;
using Slp.DataProvider.Repositories.Interfaces;

namespace Slp.DataProvider.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
