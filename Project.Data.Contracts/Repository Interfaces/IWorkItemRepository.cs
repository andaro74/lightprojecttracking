using Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Entities;
using TeamProject.Common;


namespace TeamProject.Data.Contracts
{
    public interface IWorkItemRepository:IDataRepository<WorkItem>
    {
       
        IEnumerable<WorkItem> Get(int projectId, StatusEnum selectedStatus);

       int Count(int projectId, StatusEnum selectedStatus);
        
    }
}
