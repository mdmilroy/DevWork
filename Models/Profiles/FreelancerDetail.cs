using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Profiles
{
    public class FreelancerDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CodingLanguage { get; set; }
        public virtual string State { get; set; }
        public double Rating { get; set; }
    }
}
