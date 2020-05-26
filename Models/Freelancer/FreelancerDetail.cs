using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Freelancer
{
    public class FreelancerDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> CodingLanguages { get; set; }

        public string State { get; set; }
        public double Rating { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int JobsCompleted { get; set; }
    }
}
