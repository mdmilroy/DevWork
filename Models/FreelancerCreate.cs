using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Profiles
{
    public class FreelancerCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CodingLanguage { get; set; }
        public int State { get; set; }
    }
}
