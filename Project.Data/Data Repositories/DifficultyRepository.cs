using Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Entities;
using TeamProject.Data.Contracts;

namespace TeamProject.Data
{
    public class DifficultyRepository : DataRepositoryReadOnlyBase<Difficulty>, IDifficultyRepository
    {

        protected override IEnumerable<Difficulty> GetEntities(TeamProjectContext entityContext)
        {
            return from e in entityContext.DifficultySet select e;
        }

        protected override Difficulty GetEntity(TeamProjectContext entityContext, int id)
        {
            var query = (from e in entityContext.DifficultySet
                         where e.DifficultyId == id
                         select e);
            var results = query.FirstOrDefault();
            return results;
        }
    }
}
