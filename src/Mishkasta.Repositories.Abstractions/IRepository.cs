using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mishkasta.Common.Entities;

namespace Mishkasta.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<IReadOnlyCollection<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IReadOnlyCollection<TEntity>> GetWhereAsync(ISpecification<TEntity> specification);

        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetFirstOrDefaultAsync(ISpecification<TEntity> specification);

        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetFirstAsync(ISpecification<TEntity> specification);

        Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetSingleOrDefaultAsync(ISpecification<TEntity> specification);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetSingleAsync(ISpecification<TEntity> specification);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}