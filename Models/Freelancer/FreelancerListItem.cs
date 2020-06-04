using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Freelancer
{
    public class FreelancerListItem
    {

        [Display(Name = "Freelancer ID")]
        public string FreelancerId { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Completed Job Postings")]
        public int JobPostsCompleted { get; set; }

        [Display(Name = "Coding Languages")]
        public List<string> CodingLanguages { get; set; }
    }
}
