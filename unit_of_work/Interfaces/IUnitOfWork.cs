using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_of_work
{
    public interface IUnitOfWork
    {
        void Run();
    }
}
