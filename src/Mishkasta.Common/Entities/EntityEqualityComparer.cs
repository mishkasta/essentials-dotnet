using System.Collections.Generic;

namespace Mishkasta.Common.Entities
{
    public class EntityEqualityComparer : IEqualityComparer<IEntity>
    {
        public bool Equals(IEntity x, IEntity y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            if (x == null)
            {
                return false;
            }
            if (y == null)
            {
                return false;
            }

            return x.Id == y.Id;
        }

        public int GetHashCode(IEntity obj)
        {
            return obj.Id;
        }
    }
}