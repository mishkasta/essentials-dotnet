using System;
using System.Threading;
using System.Threading.Tasks;
using Mishkasta.Common.Entities;

namespace Mishkasta.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;

        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}