using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamProjectWeb.Models
{
    public class TeamMemberViewModel
    {
        public int TeamMemberId { get; set; }

        public int ProjectId { get; set; }

        public int ContactId { get; set; }

        public string Role { get; set; }

        public string Description { get; set; }
       
        public string FirstName { get; set; }

        public string LastName { get; set; }

        
        public string ContactTitle { get; set; }

        public string ContactDescription { get; set; }

        public string StreetNameAndNumber { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZIP { get; set; }

        public int? CompanyId { get; set; }

        public string HomePhoneNumber { get; set; }

        public string WorkPhoneNumber { get; set; }

        public string CellPhoneNumber { get; set; }

        public string Website { get; set; }

        public string PhotoPath { get; set; }

        public string FullName
        {
            get
            {
                string fullName = FirstName;

                if (!String.IsNullOrEmpty(LastName))
                    fullName = String.Format("{0} {1}", fullName, LastName);

                return fullName;
            }
        }
    }

    public class TeamMemberShortViewModel
    {
        public int TeamMemberId { get; set; }

        public int ProjectId { get; set; }

        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName 
        {
            get 
            {
                string fullName=FirstName;

                if (!String.IsNullOrEmpty(LastName))
                    fullName = String.Format("{0} {1}", fullName, LastName);

                return fullName;
            }
        }
    }
}