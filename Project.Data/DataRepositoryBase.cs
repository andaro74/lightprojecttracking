using Core.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;

namespace TeamProject.Data
{
    public abstract class DataRepositoryBase<T>:DataRepositoryBase<T, TeamProjectContext>
        where T: class, new()
    {
    }
}
