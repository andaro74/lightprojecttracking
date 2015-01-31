using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Contracts
{

    public interface IDataRepositoryReadOnly
    {
    }

    public interface IDataRepositoryReadOnly<T>: IDataRepositoryReadOnly where T: class
    {
        IEnumerable<T> Get();

        T Get(int id);
    }
}
