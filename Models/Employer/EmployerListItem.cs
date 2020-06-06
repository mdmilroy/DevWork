using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Employer
{
    public class EmployerListItem
    {
        [Display(Name = "Employer ID")]
        public string EmployerId { get; set; }
       
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Organization")]
        public string Organization { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Active Job Postings")]
        public int JobPostsActive { get; set; }
    }
}
