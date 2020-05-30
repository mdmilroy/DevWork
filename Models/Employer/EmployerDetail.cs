using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Employer
{
    public class EmployerDetail
    {
        [Display(Name = "Employer ID")]
        public string EmployerId { get; set; }
        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Display(Name = "Organization")]
        public string Organization { get; set; }
        
        [Display(Name = "Rating")]
        public double Rating { get; set; }
        
        [Display(Name = "State")]
        public string State { get; set; }
        
        [Display(Name = "Joined Date")]
        public DateTimeOffset CreatedDate { get; set; }
        
        [Display(Name = "Active Job Postings")]
        public int JobPostsActive { get; set; }
        
        [Display(Name = "Closed Job Postings")]
        public int JobsCompleted { get; set; }

        [Display(Name = "Account Active")]
        public bool IsActive { get; set; }
    }
}
