using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Northwind.EF.DAL.Context;

namespace Northwind.EF.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
    {
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(NorthwindEFContext context)
        {
            context.Database.EnsureCreated();
            _dbSet = context?.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _dbSet.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            return query;
        }

    }

}

