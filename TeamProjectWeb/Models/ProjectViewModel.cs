using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamProjectWeb.Models
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        //public int? CreatedBy { get; set; }

        public string CreatedByFullName { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedDate { get; set; }

        //public bool Status { get; set; }

        public string StatusDescription { get; set; }

        [DisplayFormat(DataFormatString = "{0:##.##%}")]
        public double PercentageCompleted { get; set; }

      
        public virtual IEnumerable<TeamMemberViewModel> TeamMembersViewModel { get; set; }



    }


    public class ProjectItemViewModel
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string ProjectShortDescription { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDate { get; set; }

      
        public string StatusDescription { get; set; }

        [DisplayFormat(DataFormatString = "{0:##.##%}")]
        public double PercentageCompleted { get; set; }


    }

    
}