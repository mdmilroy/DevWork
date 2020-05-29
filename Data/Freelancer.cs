using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Freelancer : IUser
    {
        [Key]
        public string FreelancerId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Display(Name = "Number of Jobs Completed")]
        public int JobsCompleted { get; set; } = 0;
        
        [Display(Name = "Rating")]
        public double Rating { get; set; } = 0;
        
        [Display(Name = "Joined Date")]
        public DateTimeOffset CreatedDate { get; set; }
        
        [Display(Name = "Last Updated")]
        public DateTimeOffset ModifiedDate { get; set; }
        
        [Display(Name = "Account Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "State")]
        public int StateId { get; set; }
        public virtual State State { get; set; }


        public List<JobPost> JobPosts { get; set; }

        public Freelancer()
        {
            CodingLanguages = new HashSet<CodingLanguage>();
        }

        public virtual ICollection<CodingLanguage> CodingLanguages { get; set; }
    }
}