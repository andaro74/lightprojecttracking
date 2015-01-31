using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TeamProject.Business.Entities;
using TeamProject.Common;

namespace TeamProjectWeb.Models
{
    public class WorkItemViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Mode Mode { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int WorkItemId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? ProjectId { get; set; }

        [Required(ErrorMessage="Please enter a title")]
        public string Title { get; set; }

        public string ProjectName { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        [DataType(DataType.Currency)]
        public double WorkHours { get; set; }


        public int SelectedStatus { get; set; }

        public int PreviousSelectedStatus { get; set; }

        public int SelectedDifficulty { get; set; }

        public int SelectedPriority { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public IEnumerable<SelectListItem> StatusList { get; set; }

        public IEnumerable<SelectListItem> DifficultyList { get; set; }

        public IEnumerable<SelectListItem> PriorityList { get; set; }

        public IEnumerable<SelectListItem> TeamMemberList { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int TeamMemberId { get; set; }


        public TeamMemberViewModel TeamMember { get; set; }

    }

    public class WorkItemsContainerViewModel
    {
        public IEnumerable<WorkItemViewModel> WorkItemsViewModelList { get; set; }

        public WorkItemsMenuViewModel WorkItemsMenu { get; set; }
       
    }

    public class WorkItemsMenuViewModel
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public StatusEnum SelectedFilterStatus { get; set; }

        public WorkItemsMenuItemsCounterViewModel MenuItemsStatusCounter { get; set; }
    }


    public class WorkItemsMenuItemsCounterViewModel 
    {

        public int ToDoCounter { get; set; }

        public int InProgressCounter { get; set; }

        public int DoneCounter { get; set; }

        public int CancelledCounter { get; set; }

        public int OnHoldCounter { get; set; }

        public int DeletedCounter { get; set; }
    }

    public class WorkItemContainerViewModel
    {
        public WorkItemViewModel WorkItemViewModel { get; set; }

        public WorkItemsMenuViewModel WorkItemsMenu { get; set; }

    }

}