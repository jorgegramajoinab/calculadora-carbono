using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_of_work.Abstract_Classes
{
    public abstract class AContextUnitOfWork<Type> : AUnitOfWork<Type>, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual Type SaveChanges()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Type> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

    }
}
