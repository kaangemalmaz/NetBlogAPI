using Microsoft.EntityFrameworkCore;
using NetBlog.Core.Entities.Abstract;
using System.Linq.Expressions;

namespace NetBlog.Core.DataAccess.Abstract
{

    //public interface IEntityRepositoryAsync<TEntity, TContext>
    //    where TEntity : BaseEntity, IEntity, new()
    //    where TContext : DbContext, new()

    public interface IEntityRepositoryAsync<TEntity, TContext>
        where TEntity : BaseEntity, IEntity, new()
        where TContext : DbContext, new()
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includesProperty);
        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includesProperty);
        Task<IList<TEntity>> SearchAsync(IList<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includesProperty);

        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression);
    }
}
