using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamProject.Business.Contracts;
using TeamProject.Business.Entities;

namespace TeamProjectWeb.Models
{
    public class ViewModelFactory
    {
        private IContactService _contactManager;

        private ICommonService _commonManager;

        public ViewModelFactory(ICommonService commonManager,IContactService contactManager)
        {
            _contactManager = contactManager;
            _commonManager = commonManager;
        }

        public ViewModelFactory(ICommonService commonManager)
        {
           
            _commonManager = commonManager;
        }

        public ViewModelFactory(IContactService contactManager)
        {
            _contactManager = contactManager;
        }


        public ViewModelFactory()
        {
        }

        public ProjectViewModel Create(Project project)
        {
            ProjectViewModel pvm = new ProjectViewModel()
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                ProjectDescription = project.ProjectDescription,
                CreatedDate = project.CreatedDate,
                UpdatedDate = project.UpdatedDate,
                StatusDescription = ((bool)project.Status) ? "Active" : "Inactive",
                PercentageCompleted=project.PercentageCompleted,
            };

            ICollection<TeamMemberViewModel> members=new List<TeamMemberViewModel>();
            foreach (var tm in project.TeamMembers)
            {
                TeamMemberViewModel teamMember = new TeamMemberViewModel();
                Contact contact=tm.ContactInfo;
                teamMember.FirstName = tm.ContactInfo.FirstName;
                teamMember.LastName = tm.ContactInfo.LastName;
                teamMember.PhotoPath = tm.ContactInfo.PhotoPath;
                teamMember.Description = tm.Description;
                teamMember.Role = tm.Role;
                teamMember.TeamMemberId = tm.TeamMemberId;
                teamMember.ProjectId = tm.ProjectId;
                teamMember.ContactId = tm.ContactId;
                members.Add(teamMember);
            }

            pvm.TeamMembersViewModel = members;

            return pvm;
        }

        public TeamMemberViewModel Create(TeamMember project)
        {
            Contact contact= _contactManager.GetContact(project.ContactId);

            return new TeamMemberViewModel()
            {
                ProjectId = project.ProjectId,
               
                 FirstName=contact.FirstName,
                  LastName=contact.LastName,
                   
                 Description=project.Description,
                  PhotoPath=contact.PhotoPath

            };
        }


        public IEnumerable<ProjectItemViewModel> Create(IEnumerable<Project> projects)
        {
            List<ProjectItemViewModel> pivs=new List<ProjectItemViewModel>();
            foreach (var project in projects)
            {
                ProjectItemViewModel pivm = new ProjectItemViewModel()
                {
                    ProjectId = project.ProjectId,
                    ProjectName = project.ProjectName,
                    ProjectShortDescription = project.ProjectShortDescription,
                    CreatedDate = project.CreatedDate,
                    StatusDescription = ((bool)project.Status) ? "Active" : "Inactive",
                    PercentageCompleted = project.PercentageCompleted,
                };
                pivs.Add(pivm);

            }
            return pivs;
        }


        public IEnumerable<WorkItemViewModel> Create(IEnumerable<WorkItem> workItems)
        {
            List<WorkItemViewModel> wItems = new List<WorkItemViewModel>();
            foreach (var wItem in workItems)
            {
                WorkItemViewModel wItemvm = this.Create(wItem);
              
                wItems.Add(wItemvm);

            }
            return wItems;
        }

        public WorkItemViewModel Create(WorkItem workItem)
        {
            int defaultValue = 1;
            
            IEnumerable<Status> statusList = _commonManager.GetStatuses();
            IEnumerable<Difficulty> difficultyList = _commonManager.GetDifficulties();
            IEnumerable<Priority> priorityList = _commonManager.GetPriorities();
           
            WorkItemViewModel wItem= new WorkItemViewModel()
            {
                WorkItemId = workItem.WorkItemId,
                ProjectId = workItem.ProjectId,
                SelectedStatus = (workItem.Status != 0) ? workItem.Status : defaultValue,
                WorkHours = workItem.WorkHours,
                Title = workItem.Title,
                DueDate = workItem.DueDate,
                SelectedDifficulty = (workItem.Difficulty!=0)?workItem.Difficulty:defaultValue,
                Description=workItem.Description,
                StatusList = new SelectList(statusList, "StatusId", "Description"),
                DifficultyList = new SelectList(difficultyList, "DifficultyId", "Description"),
                PriorityList = new SelectList(priorityList, "PriorityId", "Description"),
                TeamMemberId=workItem.TeamMemberId
            };

            wItem.PreviousSelectedStatus = wItem.SelectedStatus;
           
            return wItem;
        }

        public WorkItem Parse(WorkItemViewModel model)
        {
            try
            {
                var entry = new WorkItem();

                entry.WorkItemId = model.WorkItemId;
                entry.ProjectId = model.ProjectId;
                entry.Status = model.SelectedStatus;
                entry.WorkHours = model.WorkHours;
                entry.Title = model.Title;
                entry.DueDate = model.DueDate;
                entry.Difficulty = model.SelectedDifficulty;
                entry.Description = model.Description;
                entry.Priority = model.SelectedPriority;
                entry.TeamMemberId = model.TeamMemberId;
                
                return entry;
            }
            catch
            {
                return null;
            }
        }


        public ContactBasicViewModel Create(Contact model)
        {
            return new ContactBasicViewModel()
            {
             ContactId=model.ContactId,
             FirstName=model.FirstName,
             LastName=model.LastName,
             PhotoPath=model.PhotoPath,
             Title=model.Title
            };
        }


    }
}