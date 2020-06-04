using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Freelancer
{
    public class FreelancerDetail
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Rating")]
        public double Rating { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Completed Job Postings")]
        public int JobsCompleted { get; set; }

        [Display(Name = "Coding Languages")]
        public List<string> CodingLanguages { get; set; }

        [Display(Name = "Joined Date")]
        public DateTimeOffset CreatedDate { get; set; }

        [Display(Name = "Account Active")]
        public bool IsActive { get; set; }
    }
}
