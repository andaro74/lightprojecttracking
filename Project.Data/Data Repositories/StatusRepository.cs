using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Entities;
using TeamProject.Data.Contracts;

namespace TeamProject.Data
{
    public class StatusRepository:DataRepositoryReadOnlyBase<Status>, IStatusRepository
    {
        protected override IEnumerable<Status> GetEntities(TeamProjectContext entityContext)
        {
            return from e in entityContext.StatusSet select e;
        }

        protected override Status GetEntity(TeamProjectContext entityContext, int id)
        {
            var query = (from e in entityContext.StatusSet
                         where e.StatusId == id
                         select e);
            var results = query.FirstOrDefault();
            return results;
        }
    }
}
