using System.Linq.Expressions;

namespace Slp.DataProvider.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> : IRepositoryRegistrator where TEntity : class 
    {
        Task<TEntity> GetFirstWhereAsync(Expression<Func<TEntity, bool>> match);

        Task<List<TEntity>> FindAllByWhereAsync(Expression<Func<TEntity, bool>> match);

        Task<List<TEntity>> FindAllByWhereOrderedAscendingAsync(Expression<Func<TEntity, bool>> match, Expression<Func<TEntity, object>> orderBy);

        Task<List<TEntity>> FindAllByWhereOrderedDescendingAsync(Expression<Func<TEntity, bool>> match, Expression<Func<TEntity, object>> orderBy);

        Task<List<TEntity>> GetAllAsync();

        Task<IList<TEntity>> UpdateRangeAsync(IList<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entityToUpdate);

        Task<TEntity> InsertAsync(TEntity entity);

        Task<IList<TEntity>> InsertRangeAsync(IList<TEntity> entities, bool saveChanges = true);

        Task DeleteAsync(TEntity entity);

        Task DeleteRangeAsync(ICollection<TEntity> entities);

        Task<int> CountAsync();

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> match);
    }
}
