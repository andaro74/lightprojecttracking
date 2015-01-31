using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Entities;
using TeamProject.Data.Contracts;

namespace TeamProject.Data
{
    public class PriorityRepository : DataRepositoryReadOnlyBase<Priority>, IPriorityRepository
    {
        protected override IEnumerable<Priority> GetEntities(TeamProjectContext entityContext)
        {
            return (from e in entityContext.PrioritySet select e);
        }

        protected override Priority GetEntity(TeamProjectContext entityContext, int id)
        {
            var query = (from e in entityContext.PrioritySet
                         where e.PriorityId == id
                         select e);
            var results = query.FirstOrDefault();
            return results;
        }
    }
}
