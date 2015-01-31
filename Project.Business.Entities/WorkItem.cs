using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Business.Entities
{
    public class WorkItem
    {
        public int WorkItemId { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public double WorkHours { get; set; }

        public int Status { get; set; }

        public int Difficulty { get; set; }

        public string Description { get; set; }

        public int? ProjectId { get; set; }

        public int Priority { get; set; }

        public int TeamMemberId { get; set; }
    }
}
