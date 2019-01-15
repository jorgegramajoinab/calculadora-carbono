using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using model;

namespace Repository
{
    public abstract class ARepository<Entity, EntityId>
        where Entity : class
    {
        protected IEnumerable<Entity> Set { get; set; }

        public ARepository(IEnumerable<Entity> Set)
        {
            this.Set = Set;
        }

        public abstract bool Exist(EntityId Id);

        public virtual bool Exist(Func<Entity, bool> condition)
        {
            return this.Set.Any(condition);
        }

        public virtual Entity GetFirst(Func<Entity, bool> condition)
        {
            return this.Set.FirstOrDefault(condition);
        }

        public virtual IEnumerable<Entity> Where (Func<Entity, bool> condition)
        {
            return this.Set.Where(condition);
        }

        public abstract Entity GetById(EntityId Id);
    }
}
