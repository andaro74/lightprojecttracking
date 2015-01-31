using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamProjectWeb.Models
{
    public class ContactBasicViewModel
    {
       
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

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
}