﻿using Microsoft.EntityFrameworkCore;
using Slp.Data.Repositories.Interfaces;
using Slp.DataCore.Exceptions;
using System.Linq.Expressions;

namespace Slp.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext context;

        private readonly DbSet<TEntity> dbSet;

        protected RepositoryBase(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }        

        public async Task<int> CountAsync()
        {
            return await context.Set<TEntity>().CountAsync();
        }

        #region Get

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<List<TEntity>> FindAllByWhereAsync(Expression<Func<TEntity, bool>> match)
        {
            return await context.Set<TEntity>().Where(match).ToListAsync();
        }

        public async Task<List<TEntity>> FindAllByWhereOrderedAscendingAsync(
            Expression<Func<TEntity, bool>> match,
            Expression<Func<TEntity, object>> orderBy)
        {
            return await context.Set<TEntity>().Where(match).OrderBy(orderBy).ToListAsync();
        }

        public async Task<List<TEntity>> FindAllByWhereOrderedDescendingAsync(
            Expression<Func<TEntity, bool>> match,
            Expression<Func<TEntity, object>> orderBy)
        {
            return await context.Set<TEntity>().Where(match).OrderByDescending(orderBy).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> match)
        {
            return await context.Set<TEntity>().AnyAsync(match);
        }

        public virtual async Task<TEntity> GetFirstWhereAsync(Expression<Func<TEntity, bool>> match)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(match);
        }

        #endregion

        #region Delete

        public async Task DeleteAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(ICollection<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        #endregion

        #region Update

        public virtual async Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {
            try
            {
                if (context.Entry(entityToUpdate).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToUpdate);
                }

                context.Entry(entityToUpdate).State = EntityState.Modified;
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                await context.SaveChangesAsync();

                return entityToUpdate;
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message, e.InnerException, typeof(TEntity).ToString());
            }
        }

        public virtual async Task<IList<TEntity>> UpdateRangeAsync(IList<TEntity> entities)
        {
            var detachedEntities = new List<TEntity>();
            context.ChangeTracker.AutoDetectChangesEnabled = false;
            foreach (var entity in entities)
            {
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    detachedEntities.Add(entity);
                }

                context.Entry(entity).State = EntityState.Modified;
            }

            dbSet.AttachRange(detachedEntities);
            await context.SaveChangesAsync();
            context.ChangeTracker.AutoDetectChangesEnabled = true;

            return entities;
        }

        #endregion

        #region Insert

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<IList<TEntity>> InsertRangeAsync(IList<TEntity> entities, bool saveChanges = true)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
            if (saveChanges)
            {
                await context.SaveChangesAsync();
            }

            return entities;
        }

        #endregion
    }
}
