using Microsoft.EntityFrameworkCore;
using NetBlog.Core.DataAccess.Abstract;
using NetBlog.Core.Entities.Abstract;
using System.Linq.Expressions;

namespace NetBlog.Core.DataAccess.Concrete
{
    public class EntityRepositoryAsync<TEntity, TContext> : IEntityRepositoryAsync<TEntity, TContext>
        where TEntity : BaseEntity, IEntity, new()
        where TContext : DbContext, new()
    {
        protected TContext _context;
        private readonly DbSet<TEntity> _entitySet;

        public EntityRepositoryAsync(TContext context)
        {
            _context = context;
            _entitySet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _entitySet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _entitySet.AnyAsync(expression);

        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _entitySet.CountAsync(expression);
        }

        public async Task DeleteAsync(int id)
        {
            TEntity entity = await _entitySet.FindAsync(id);
            await Task.Run(() => { _entitySet.Remove(entity); });
            await _context.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includesProperty)
        {
            IQueryable<TEntity> query = _entitySet;

            if (predicate != null) query = query.Where(predicate);

            if (includesProperty.Any())
            {
                foreach (var includeProperty in includesProperty)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.OrderBy(i => i.CreatedDate).AsNoTracking().ToListAsync();

        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includesProperty)
        {
            IQueryable<TEntity> query = _entitySet;

            if (predicate != null) query = query.Where(predicate);

            if (includesProperty.Any())
            {
                foreach (var includeProperty in includesProperty)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<IList<TEntity>> SearchAsync(IList<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includesProperty)
        {
            IQueryable<TEntity> query = _entitySet;

            foreach (var predicate in predicates)
            {
                query = query.Where(predicate);
            }

            foreach (var includeproperty in includesProperty)
            {
                query = query.Include(includeproperty);
            }

            return await query.OrderBy(i => i.CreatedDate).AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => { _entitySet.Update(entity); });
            await _context.SaveChangesAsync();
        }
    }
}
