using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Common;
using TeamProject.Business.Contracts;
using TeamProject.Business.Entities;
using TeamProject.Data.Contracts;
using TeamProject.Business.Entities;
using TeamProject.Common;

namespace TeamProject.Business.Managers
{
    public class WorkItemsManager:IWorkItemsService
    {
        IWorkItemsEngine _WorkItemsEngine;
        IWorkItemRepository _WorkItemRepository;

        public WorkItemsManager()
        {
        }

        public WorkItemsManager(IWorkItemRepository workItemRepository, IWorkItemsEngine workItemsEngine)
        {
            _WorkItemRepository = workItemRepository;
            _WorkItemsEngine = workItemsEngine;
        }

        public WorkItem GetWorkItem(int workItemId)
        {
            try
            {
                WorkItem workItemEntity = _WorkItemRepository.Get(workItemId);
               
                if (workItemEntity == null)
                {
                    throw new Exception(string.Format("Work Item with ID of {0} is not in the database", workItemId));
                }
                return workItemEntity;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public WorkItem UpdateWorkItem(WorkItem workItem)
        {
            try
            {
                WorkItem udpatedEntity = null;

                if (workItem.WorkItemId == 0)
                    udpatedEntity = _WorkItemRepository.Add(workItem);
                else
                    udpatedEntity = _WorkItemRepository.Update(workItem);

                return udpatedEntity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteWorkItem(int workItemId)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<WorkItem> Get(int projectId, StatusEnum selectedStatus)
        {
            try
            {
                IEnumerable<WorkItem> workItems = _WorkItemRepository.Get(projectId, selectedStatus);
                                               
                return workItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public int Count(int projectId, StatusEnum selectedStatus)
        {
            try
            {
                return _WorkItemRepository.Count(projectId, selectedStatus);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}
