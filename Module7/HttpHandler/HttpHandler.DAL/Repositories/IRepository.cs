using System;
using System.Linq;
using System.Linq.Expressions;

namespace HttpHandler.DAL.Repositories
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
    }
}
