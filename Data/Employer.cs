using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Employer : IUser
    {
        [Key]
        public string EmployerId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Display(Name = "Organization")]
        public string Organization { get; set; }
        
        [Display(Name = "Rating")]
        public double Rating { get; set; } = 0;
        
        [Display(Name = "Joined Date")]
        public DateTimeOffset CreatedDate { get; set; }
        
        [Display(Name = "Last Updated")]
        public DateTimeOffset ModifiedDate { get; set; }
        
        [Display(Name = "Number of Jobs Completed")]
        public int JobsCompleted { get; set; } = 0;
        
        [Display(Name = "Account Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "State")]
        public int StateId { get; set; }
        public virtual State State { get; set; }

        public List<JobPost> JobPosts { get; set; }


    }
}