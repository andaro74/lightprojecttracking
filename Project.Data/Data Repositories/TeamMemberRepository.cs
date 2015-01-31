using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Entities;
using TeamProject.Data.Contracts;

namespace TeamProject.Data
{
    public class TeamMemberRepository : DataRepositoryBase<TeamMember>, ITeamMemberRepository
    {
        protected override TeamMember AddEntity(TeamProjectContext entityContext, TeamMember entity)
        {
            throw new NotImplementedException();
        }

        protected override TeamMember UpdateEntity(TeamProjectContext entityContext, TeamMember entity)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<TeamMember> GetEntities(TeamProjectContext entityContext)
        {
            return from e in entityContext.TeamMemberSet select e;
        }

        protected override TeamMember GetEntity(TeamProjectContext entityContext, int id)
        {
            var query = (from e in entityContext.TeamMemberSet
                         where e.ProjectId == id
                         select e);
            var results = query.FirstOrDefault();
            return results;
        }
    }
}
