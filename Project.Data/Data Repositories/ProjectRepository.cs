using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Entities;
using TeamProject.Data.Contracts;

namespace TeamProject.Data
{
    public class ProjectRepository:DataRepositoryBase<Project>, IProjectRepository
    {
        protected override Project AddEntity(TeamProjectContext entityContext, Project entity)
        {
            throw new NotImplementedException();
        }

        protected override Project UpdateEntity(TeamProjectContext entityContext, Project entity)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Project> GetEntities(TeamProjectContext entityContext)
        {
            return from e in entityContext.ProjectSet select e;
        }

        protected override Project GetEntity(TeamProjectContext entityContext, int id)
        {
            var query = (from e in entityContext.ProjectSet
                         where e.ProjectId == id
                         select e);
            var results = query.FirstOrDefault();
            return results;
        }
    }
}
