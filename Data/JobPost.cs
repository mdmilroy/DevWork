using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class JobPost
    {
        [Key]
        [Display(Name = "Job Post Id")]
        public int JobPostId { get; set; }

        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        
        [Display(Name = "Job Description")]
        public string Content { get; set; }

        [Display(Name = "State")]
        public int StateId { get; set; }
        public virtual State State { get; set; }

        [Display(Name = "Awarded")]
        public bool IsAwarded { get; set; } = false;
        
        [Display(Name = "Created On")]
        public DateTimeOffset CreatedDate { get; set; }
        
        [Display(Name = "Last Modified")]
        public DateTimeOffset ModifiedDate { get; set; }
        
        [Display(Name = "Active User")]
        public bool IsActive { get; set; } = true;


        [Display(Name = "Employer")]
        public string EmployerId { get; set; }
        public virtual Employer Employer { get; set; }


        [Display(Name = "Freelancer")]
        public string FreelancerId { get; set; }
        public virtual Freelancer Freelancer { get; set; }

    }
}