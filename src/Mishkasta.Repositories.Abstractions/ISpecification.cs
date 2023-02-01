using System;
using System.Linq.Expressions;
using Mishkasta.Common.Entities;

namespace Mishkasta.Repositories
{
    public interface ISpecification<TEntity> where TEntity : IEntity
    {
        Expression<Func<TEntity, bool>> Predicate { get; }
    }
}