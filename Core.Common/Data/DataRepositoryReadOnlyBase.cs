
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Core.Common.Contracts;
using Core.Common.Utils;

namespace Core.Common.Data
{
    public abstract class DataRepositoryReadOnlyBase<T, U>: IDataRepositoryReadOnly<T>
        where T: class, new()
        where U: DbContext, new()
    {
        protected abstract IEnumerable<T> GetEntities(U entityContext);

        protected abstract T GetEntity(U entityContext, int id);

        public IEnumerable<T> Get()
        {
            using (U entityContext = new U())
                return (GetEntities(entityContext)).ToArray().ToList();
        }

        public T Get(int id)
        {
            using (U entityContext = new U())
                return GetEntity(entityContext, id);
        }
    }
}
