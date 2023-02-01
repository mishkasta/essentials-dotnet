using Mishkasta.Common.Entities;

namespace Mishkasta.Repositories
{
    public class TrueSpecification<TEntity> : Specification<TEntity> where TEntity : class, IEntity
    {
        public TrueSpecification()
            : base(e => true)
        {

        }
    }
}