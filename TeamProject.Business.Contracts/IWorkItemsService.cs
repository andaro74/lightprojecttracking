using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Entities;
using TeamProject.Common;


namespace TeamProject.Business.Contracts
{
    public interface IWorkItemsService
    {
        WorkItem GetWorkItem(int WorkItemId);

        WorkItem UpdateWorkItem(WorkItem workItem);

        void DeleteWorkItem(int workItemId);

        IEnumerable<WorkItem> Get(int projectId,StatusEnum selectedStatus);

        int Count(int projectId,StatusEnum selectedStatus);

    }
}
