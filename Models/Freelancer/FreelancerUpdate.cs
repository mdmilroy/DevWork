using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Freelancer
{
    public class FreelancerUpdate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CodingLanguage { get; set; }
        public string State { get; set; }
        public int JobsCompleted { get; set; }
        public double Rating { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
    }
}
