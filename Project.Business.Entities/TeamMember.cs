using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Business.Entities
{
    public class TeamMember
    {
        public int TeamMemberId { get; set; }

        public int ProjectId { get; set; }

        public int ContactId { get; set; }

        public string Role { get; set; }

        public string Description { get; set; }

        public virtual Contact ContactInfo { get; set; }

    }
}
