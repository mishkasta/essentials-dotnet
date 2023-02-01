using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mishkasta.Common.Entities;

namespace Mishkasta.Repositories.EntityFrameworkCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        private readonly IDictionary<Type, object> _repositories;
        private readonly IDictionary<Type, Type> _customRepositoryTypes;


        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;

            _repositories = new Dictionary<Type, object>();
            _customRepositoryTypes = new Dictionary<Type, Type>();
        }


        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IEntity
        {
            var entityType = typeof(TEntity);
            if (_repositories.TryGetValue(entityType, out var repository))
            {
                return (IRepository<TEntity>) repository;
            }

            repository = _customRepositoryTypes.TryGetValue(entityType, out var customRepositoryType)
                ? Activator.CreateInstance(customRepositoryType, _dbContext)
                : new Repository<TEntity>(_dbContext);

            _repositories.Add(entityType, repository);

            return (IRepository<TEntity>) repository;
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }


        protected void RegisterCustomRepository<TEntity, TRepository>()
            where TEntity : class, IEntity
            where TRepository : IRepository<TEntity>
        {
            _customRepositoryTypes.Add(typeof(TEntity), typeof(TRepository));
        }
    }
}