using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Entities;
using TeamProject.Common;
using TeamProject.Data.Contracts;

namespace TeamProject.Data.Data_Repositories
{
    public class WorkItemRepository:DataRepositoryBase<WorkItem>, IWorkItemRepository
    {
        protected override WorkItem AddEntity(TeamProjectContext entityContext, WorkItem entity)
        {
            return entityContext.WorkItemSet.Add(entity);
        }

        protected override WorkItem UpdateEntity(TeamProjectContext entityContext, WorkItem entity)
        {
            return (from e in entityContext.WorkItemSet
                    where e.WorkItemId == entity.WorkItemId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<WorkItem> GetEntities(TeamProjectContext entityContext)
        {
            return (from e in entityContext.WorkItemSet select e).ToArray();

        }

        protected override WorkItem GetEntity(TeamProjectContext entityContext, int id)
        {
            var query = (from e in entityContext.WorkItemSet
                         where e.WorkItemId == id
                         select e);
            return query.FirstOrDefault();
        }

        public IEnumerable<WorkItem> Get(int projectId, StatusEnum selectedStatus)
        {
            using (TeamProjectContext entityContext = new TeamProjectContext()) 
            {
                var query = (from e in entityContext.WorkItemSet
                             where (e.ProjectId==projectId && e.Status==(int)selectedStatus)
                             select e);
                return query.ToList();
            }

          
        }

        public int Count(int projectId, StatusEnum selectedStatus)
        {
            using (TeamProjectContext entityContext = new TeamProjectContext())
            {
                var query = (from e in entityContext.WorkItemSet
                             where (e.ProjectId == projectId && e.Status == (int)selectedStatus)
                             select e);
                return query.Count();
            }
        }

        
    }
}
