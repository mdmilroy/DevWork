using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Profiles
{
    public class FreelancerDetail
    {
        public int FreelancerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Rating { get; set; }
        public int CodingLanguage { get; set; }
        public int JobsCompleted { get; set; }
        public string StateName { get; set; }
    }
}
