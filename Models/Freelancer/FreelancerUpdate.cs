using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Freelancer
{
    public class FreelancerUpdate
    {
        [Display(Name = "Freelancer ID")]
        public string FreelancerId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Rating")]
        public double Rating { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Completed Job Postings")]
        public int JobsCompleted { get; set; }

        [Display(Name = "Coding Language")]
        public int CodingLanguageId { get; set; }
    }
}
