using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.Core.Models.Entities;
using System.Linq.Expressions;

namespace OnlineShop.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected AppDbContext DbContext;

        public RepositoryBase(AppDbContext dbContext)
            => DbContext = dbContext;

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
              DbContext.Set<T>()
                .AsNoTracking() :
              DbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
              DbContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
              DbContext.Set<T>()
                .Where(expression);

        public void Create(T entity) => DbContext.Set<T>().Add(entity);

        public void Update(T entity) => DbContext.Set<T>().Update(entity);

        public void Delete(T entity) => DbContext.Set<T>().Remove(entity);
    }
}
