using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mishkasta.Common.Entities;
using Mishkasta.Repositories;

namespace Mishkasta.Repositories.EntityFrameworkCore
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext _dbContext;

        private readonly DbSet<TEntity> _entities;


        protected virtual IQueryable<TEntity> Query => _entities;


        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;

            _entities = _dbContext.Set<TEntity>();
        }


        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            return await Query.ToListAsync();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return GetSingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IReadOnlyCollection<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Query.Where(predicate).ToListAsync();
        }

        public Task<IReadOnlyCollection<TEntity>> GetWhereAsync(ISpecification<TEntity> specification)
        {
            return GetWhereAsync(specification.Predicate);
        }

        public Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Query.FirstOrDefaultAsync(predicate);
        }

        public Task<TEntity> GetFirstOrDefaultAsync(ISpecification<TEntity> specification)
        {
            return GetFirstOrDefaultAsync(specification.Predicate);
        }

        public Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Query.FirstAsync(predicate);
        }

        public Task<TEntity> GetFirstAsync(ISpecification<TEntity> specification)
        {
            return GetFirstAsync(specification.Predicate);
        }

        public Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Query.SingleOrDefaultAsync(predicate);
        }

        public Task<TEntity> GetSingleOrDefaultAsync(ISpecification<TEntity> specification)
        {
            return GetSingleOrDefaultAsync(specification.Predicate);
        }

        public Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Query.SingleAsync(predicate);
        }

        public Task<TEntity> GetSingleAsync(ISpecification<TEntity> specification)
        {
            return GetSingleAsync(specification.Predicate);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Query.AnyAsync(predicate);
        }

        public Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Query.AllAsync(predicate);
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }
    }
}