using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Business.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        //public Address ContactAddress { get; set; }

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

      
    }
}
