using System;
using System.Linq.Expressions;
using Mishkasta.Common.Entities;
using Mishkasta.Common.Expression;
using Mishkasta.Repositories;

namespace Mishkasta.Repositories
{
    public abstract class Specification<TEntity> : ISpecification<TEntity> where TEntity : class, IEntity
    {
        public Expression<Func<TEntity, bool>> Predicate { get; private set; }


        protected Specification(Expression<Func<TEntity, bool>> predicate)
        {
            Predicate = predicate;
        }


        public Specification<TEntity> And(ISpecification<TEntity> specification)
        {
            Predicate = Predicate.And(specification.Predicate);

            return this;
        }

        public Specification<TEntity> Or(ISpecification<TEntity> specification)
        {
            Predicate = Predicate.Or(specification.Predicate);

            return this;
        }

        public Specification<TEntity> Not()
        {
            Predicate = Predicate.Not();

            return this;
        }
    }
}