using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Business.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public Address CompanyAddress { get; set; }

        public string Email { get; set; }

        public string PhoneNumber1 { get; set; }

        public string PhoneNumber2 { get; set; }

        public string Website { get; set; }


    }
}
