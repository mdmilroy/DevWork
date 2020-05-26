using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Freelancer
{
    public class FreelancerListItem
    {
        public string FreelancerId { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public int JobPostsCompleted { get; set; }
    }
}
