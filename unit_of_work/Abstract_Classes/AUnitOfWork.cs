using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_of_work.Abstract_Classes
{
    public abstract class AUnitOfWork<Type> : IUnitOfWork
    {
        public Type Result { get; set; }

        public abstract void Run();
    }
}
