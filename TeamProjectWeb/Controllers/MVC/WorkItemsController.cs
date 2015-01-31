using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamProject.Business.Contracts;
using TeamProject.Business.Entities;
using TeamProject.Common;
using TeamProjectWeb.Models;
using TeamProjectWeb.Infrastructure;

namespace TeamProjectWeb.Controllers.MVC
{
    public class WorkItemsController : BaseController
    {

        #region properties

        public int ProjectId {
            get 
            {
                return (int)SessionStateHelper.Get(SessionStateKeys.ProjectIdKey);
            }
            set 
            {
                SessionStateHelper.Set(SessionStateKeys.ProjectIdKey, value);
            } 
        }

        public StatusEnum SelectedStatus
        {
            get
            {
                return (StatusEnum)SessionStateHelper.Get(SessionStateKeys.SelectedStatusKey);
            }
            set
            {
                SessionStateHelper.Set(SessionStateKeys.SelectedStatusKey, value);
            }
        }



        public WorkItemsMenuViewModel MenuWorkItemsSession
        {
            get 
            {
                var workitemMenuVM = (WorkItemsMenuViewModel)SessionStateHelper.Get(SessionStateKeys.MenuWorkItemsSessionKey);
                if (workitemMenuVM != null && workitemMenuVM.ProjectId == ProjectId)
                {
                    workitemMenuVM.SelectedFilterStatus = SelectedStatus;
                    return workitemMenuVM;
                }
                else
                {

                    WorkItemsMenuItemsCounterViewModel menu=new  WorkItemsMenuItemsCounterViewModel();

                    menu.ToDoCounter = _workItemsManager.Count(ProjectId, StatusEnum.ToDo);
                    menu.InProgressCounter = _workItemsManager.Count(ProjectId, StatusEnum.InProgress);
                    menu.DoneCounter = _workItemsManager.Count(ProjectId, StatusEnum.Done);
                    menu.OnHoldCounter = _workItemsManager.Count(ProjectId, StatusEnum.OnHold);
                    menu.CancelledCounter = _workItemsManager.Count(ProjectId, StatusEnum.Cancelled);
                    menu.DeletedCounter = _workItemsManager.Count(ProjectId, StatusEnum.Deleted);

                    var workitemMenuViewModel = new WorkItemsMenuViewModel()
                    {
                        ProjectId = ProjectId,
                        ProjectName = ProjectViewModelSession.ProjectName,
                        MenuItemsStatusCounter = menu,
                        SelectedFilterStatus = SelectedStatus
                    };
                    //Store it back to the session variable
                    MenuWorkItemsSession = workitemMenuViewModel;

                    return workitemMenuViewModel;
                }
           }
            set 
            {
                SessionStateHelper.Set(SessionStateKeys.MenuWorkItemsSessionKey,value);
            } 
        }

        public ProjectViewModel ProjectViewModelSession
        {
            get
            {
                if (SessionStateHelper.Get(SessionStateKeys.ProjectViewModelSessionKey) != null)
                {
                    return (ProjectViewModel)SessionStateHelper.Get(SessionStateKeys.ProjectViewModelSessionKey);
                }
                else
                {
                    Project project = _teamProjectService.GetTeamProject(ProjectId);

                    //Store the project in session
                    ProjectViewModel ProjectViewModelSession = TheModelFactory.Create(project);
                    return ProjectViewModelSession;
                }
            }
            set
            {
                SessionStateHelper.Set(SessionStateKeys.ProjectViewModelSessionKey, value);
            }
        }

        #endregion

        private ICommonService _commonManager;
        private IWorkItemsService _workItemsManager;
        private ITeamProjectService _teamProjectService; 

        private ViewModelFactory _theModelFactory;
        protected ViewModelFactory TheModelFactory
        {
            get
            {
                if (_theModelFactory == null)
                {
                    _theModelFactory = new ViewModelFactory(_commonManager);
                }
                return _theModelFactory;
            }
        }

       
        public WorkItemsController(ICommonService commonManager, IWorkItemsService workItemsManager, ITeamProjectService teamProjectService)
        {
            _commonManager = commonManager;
            _workItemsManager = workItemsManager;
            _teamProjectService = teamProjectService;
        }

        // GET: WorkItems
        public ActionResult Index( int id,int status=(int)StatusEnum.ToDo)
        {
            //Get the selected workitem status
            StatusEnum selected=(StatusEnum)id;
            //Set the specific project in the session
            ProjectId = id;
            SelectedStatus = (StatusEnum)status;

            //Get all the workitmes for a specific project
            IEnumerable<WorkItem> workItems = _workItemsManager.Get(ProjectId, (StatusEnum)status);
            IEnumerable<WorkItemViewModel> wItemsVM = TheModelFactory.Create(workItems);

            foreach (var member in wItemsVM)
            {
                member.TeamMember = (TeamMemberViewModel)ProjectViewModelSession.TeamMembersViewModel.Where(s => s.TeamMemberId == member.TeamMemberId).FirstOrDefault();  
            }

            //Get left menu information and set the selected status
            WorkItemsMenuViewModel workItemsMenu = MenuWorkItemsSession;
           
             
            //Create the container that will be sent to the view.
            WorkItemsContainerViewModel wItemContainer = new WorkItemsContainerViewModel()
            {
                WorkItemsViewModelList = wItemsVM,
                WorkItemsMenu = workItemsMenu
            };
           
            return View(wItemContainer);
        }

        // GET: WorkItems/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkItems/Create
        public ActionResult Create()
        {
            //Create an empty work item
            WorkItem workItem = new WorkItem()
            {
                ProjectId = ProjectId
            };

            //Set initial values to the view model that will be rendered in the view
            WorkItemViewModel wItem = TheModelFactory.Create(workItem);
            wItem.Mode = Mode.Create;
            wItem.DueDate = DateTime.Now.Date;
            wItem.ProjectName = ProjectViewModelSession.ProjectName;

            //Set the list of team members that will be shown in the drop down for selection
            IEnumerable<TeamMemberViewModel> teamMemberList= ProjectViewModelSession.TeamMembersViewModel;
            wItem.TeamMemberList = new SelectList(teamMemberList, "TeamMemberId", "FullName");

            //Wrap the container
            WorkItemContainerViewModel container = new WorkItemContainerViewModel()
            {
                WorkItemsMenu = MenuWorkItemsSession,
                WorkItemViewModel = wItem
            };
            return View(container);

        }

        // POST: WorkItems/Create
        [HttpPost]
        public ActionResult Create(WorkItemViewModel workItemModel)
        {
            try
            {
                //todo: Validate the model

                WorkItem workItem = TheModelFactory.Parse(workItemModel);
                //Save the information
                WorkItem updatedWorkItem = _workItemsManager.UpdateWorkItem(workItem);
                WorkItemViewModel wItemViewModel = TheModelFactory.Create(updatedWorkItem);

                InvalidateSessions();

                return RedirectToAction("Index", new { id =workItem.ProjectId, status= workItem.Status });
            }
            catch
            {
                return View();
            }
        }

        


        [HttpPost]
        public ActionResult Draft(WorkItemViewModel workItem)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: WorkItems/Edit/5
        public ActionResult Edit(int id)
        {

            //Get information about the specific workItem
            WorkItem workItem = _workItemsManager.GetWorkItem(id);

            WorkItemViewModel wItem= TheModelFactory.Create(workItem);
            wItem.Mode = Mode.Edit;
            wItem.ProjectName = this.ProjectViewModelSession.ProjectName;
          
            IEnumerable<TeamMemberViewModel> teamMemberList = ProjectViewModelSession.TeamMembersViewModel;
            wItem.TeamMemberList = new SelectList(teamMemberList, "TeamMemberId", "FullName");


            WorkItemContainerViewModel container = new WorkItemContainerViewModel()
            {
                WorkItemViewModel=wItem,
                WorkItemsMenu=MenuWorkItemsSession
            };
            
            return View(container);

        }

        // POST: WorkItems/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, WorkItemViewModel workItemModel)
        {
            try
            {
               
                WorkItem workItem = TheModelFactory.Parse(workItemModel);
                WorkItem updatedWorkItem = _workItemsManager.UpdateWorkItem(workItem);
                WorkItemViewModel wItemViewModel = TheModelFactory.Create(updatedWorkItem);

                InvalidateSessions();

                return RedirectToAction("Index", new { id = workItem.ProjectId, status = workItem.Status });

            }
            catch
            {
                return View();
            }
        }

        // GET: WorkItems/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkItems/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        #region private methods

        private void InvalidateSessions()
        {
            //invalidate the session and the program, since there are changes in the menu session
            this.MenuWorkItemsSession = null;
            //invalidate the program session since there are changes in the program.
            this.ProjectViewModelSession = null;
        }

        #endregion
    }
}
