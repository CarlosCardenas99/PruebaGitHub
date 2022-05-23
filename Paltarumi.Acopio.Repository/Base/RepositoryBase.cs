using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Entity.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Repository.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
            => _dbContext = dbContext;

        public async Task<TEntity?> AddAsync(TEntity entity)
        {
            if (entity == null) return null;

            await _dbContext.Set<TEntity>().AddAsync(entity);

            return await Task.FromResult(entity);
        }

        public async Task<IEnumerable<TEntity>?> AddAsync(params TEntity[] entities)
        {
            if (entities == null) return null;
            if (!entities.Any()) return entities;

            await _dbContext.Set<TEntity>().AddRangeAsync(entities);

            return await Task.FromResult(entities);
        }

        public async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            if (entity == null) return null;

            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Update(entity);

            return await Task.FromResult(entity);
        }

        public async Task<IEnumerable<TEntity>?> UpdateAsync(params TEntity[] entities)
        {
            if (entities == null) return null;
            if (!entities.Any()) return entities;

            entities.ToList().ForEach(entity =>
            {
                _dbContext.Set<TEntity>().Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            });

            _dbContext.Set<TEntity>().UpdateRange(entities);

            return await Task.FromResult(entities);
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            if (entity == null) return default;

            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Set<TEntity>().Remove(entity);

            return await Task.FromResult(default(int));
        }

        public async Task<int> DeleteAsync(params TEntity[] entities)
        {
            if (entities == null) return default;
            if (!entities.Any()) return default;

            entities.ToList().ForEach(entity => _dbContext.Set<TEntity>().Attach(entity));

            _dbContext.Set<TEntity>().RemoveRange(entities);

            return await Task.FromResult(default(int));
        }

        public async Task<TEntity?> GetAsync(object keyValue)
            => await FindAll().FilterByKey(keyValue).FirstOrDefaultAsync();

        public async Task<TEntity?> GetAsNoTrackingAsync(object keyValue)
            => await FindAllAsNoTracking().FilterByKey(keyValue).FirstOrDefaultAsync();

        public async Task<TEntity?> GetAsync(params object[] keyValues)
            => await FindAll().FilterByKey(keyValues).FirstOrDefaultAsync();

        public async Task<TEntity?> GetAsNoTrackingAsync(params object[] keyValues)
            => await FindAllAsNoTracking().FilterByKey(keyValues).FirstOrDefaultAsync();

        public async Task<TEntity?> GetAsync(object keyValue, params Expression<Func<TEntity, object>>[] includeProperties)
            => await FindAll(includeProperties).FilterByKey(keyValue).FirstOrDefaultAsync();

        public async Task<TEntity?> GetAsNoTrackingAsync(object keyValue, params Expression<Func<TEntity, object>>[] includeProperties)
            => await FindAllAsNoTracking(includeProperties).FilterByKey(keyValue).FirstOrDefaultAsync();

        public async Task<TEntity?> GetAsync(object[] keyValues, params Expression<Func<TEntity, object>>[] includeProperties)
            => await FindAll(includeProperties).FilterByKey(keyValues).FirstOrDefaultAsync();

        public async Task<TEntity?> GetAsNoTrackingAsync(object[] keyValues, params Expression<Func<TEntity, object>>[] includeProperties)
            => await FindAllAsNoTracking(includeProperties).FilterByKey(keyValues).FirstOrDefaultAsync();

        public async Task<TEntity?> GetByAsync(Expression<Func<TEntity, bool>> filter)
            => await FindAll().Filter(filter).FirstOrDefaultAsync();

        public async Task<TEntity?> GetByAsNoTrackingAsync(Expression<Func<TEntity, bool>> filter)
            => await FindAllAsNoTracking().Filter(filter).FirstOrDefaultAsync();

        public async Task<TEntity?> GetByAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
            => await FindAll(includeProperties).Filter(filter).FirstOrDefaultAsync();

        public async Task<TEntity?> GetByAsNoTrackingAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
            => await FindAllAsNoTracking(includeProperties).Filter(filter).FirstOrDefaultAsync();

        public IQueryable<TEntity> FindAll()
            => _dbContext.Set<TEntity>();

        public IQueryable<TEntity> FindAllAsNoTracking()
            => _dbContext.Set<TEntity>().AsNoTracking();

        public IQueryable<TEntity> FindAll(params Expression<Func<TEntity, object>>[] includeProperties)
            => FindAll().IncludeProperties(includeProperties);

        public IQueryable<TEntity> FindAllAsNoTracking(params Expression<Func<TEntity, object>>[] includeProperties)
            => FindAllAsNoTracking().IncludeProperties(includeProperties);

        public async Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> filter)
            => await FindAll().Filter(filter).ToListAsync();

        public async Task<IEnumerable<TEntity>> FindByAsNoTrackingAsync(Expression<Func<TEntity, bool>> filter)
            => await FindAllAsNoTracking().Filter(filter).ToListAsync();

        public async Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
            => await FindAll(includeProperties).Filter(filter).ToListAsync();

        public async Task<IEnumerable<TEntity>> FindByAsNoTrackingAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
            => await FindAllAsNoTracking(includeProperties).Filter(filter).ToListAsync();

        public async Task<SearchResult<TEntity>> SearchByAsync(int page, int pageSize, IEnumerable<SortExpression<TEntity>>? sortExpressions, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
            => await SearchByAsync(false, page, pageSize, sortExpressions, filter, includeProperties);

        public async Task<SearchResult<TEntity>> SearchByAsNoTrackingAsync(int page, int pageSize, IEnumerable<SortExpression<TEntity>>? sortExpressions, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
            => await SearchByAsync(true, page, pageSize, sortExpressions, filter, includeProperties);

        private async Task<SearchResult<TEntity>> SearchByAsync(bool asNoTracking, int page, int pageSize, IEnumerable<SortExpression<TEntity>>? sortExpressions, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var findAll = asNoTracking ? FindAllAsNoTracking() : FindAll();

            if (filter != null) findAll = findAll.Filter(filter);

            var total = await findAll.CountAsync();

            if (sortExpressions != null && sortExpressions.Any())
            {
                var firstSortExpression = sortExpressions.First();

                if (firstSortExpression.Property != null)
                {
                    findAll = firstSortExpression.Direction == SortDirection.Asc ?
                        findAll.OrderBy(firstSortExpression.Property) :
                        findAll.OrderByDescending(firstSortExpression.Property);
                }

                if (sortExpressions.Count() > 1)
                {
                    foreach (var sortExpression in sortExpressions.Skip(1))
                    {
                        if (findAll is IOrderedQueryable<TEntity> sortExp && firstSortExpression.Property != null)
                        {
                            findAll = firstSortExpression.Direction == SortDirection.Asc ?
                                (sortExp).ThenBy(firstSortExpression.Property) :
                                (sortExp).ThenByDescending(firstSortExpression.Property);
                        }
                    }
                }
            }

            if (includeProperties != null && includeProperties.Any())
                findAll = findAll.IncludeProperties(includeProperties);

            var currentPage = page <= 0 ? 1 : page;
            var skip = ((currentPage - 1) * pageSize);

            findAll = findAll.Skip(skip).Take(pageSize);

            var items = await findAll.ToListAsync();

            return new SearchResult<TEntity>
            {
                Total = total,
                Items = items
            };
        }

        public async Task<int> SaveAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
