using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBase.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<int> CommitAsync();
        int Commit();

        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        long Count();
        Task<long> CountAsync();
        long Count(Expression<Func<TEntity, bool>> predicate);
        Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        ValueTask<TEntity> GetByIdAsync(int id);
        TEntity GetById(int id);

        void Remove(TEntity entity);
        TEntity Update(TEntity entity);


        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Find(
                    Expression<Func<TEntity, bool>> filter = null,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                    string includeProperties = "");
        Task<IEnumerable<TEntity>> FindAsync(
                       Expression<Func<TEntity, bool>> filter = null,
                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                       string includeProperties = "");


    }
}
