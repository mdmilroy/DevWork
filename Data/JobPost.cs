using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class JobPost
    {
        public int JobPostId { get; set; }
        public string JobTitle { get; set; }
        public string Content { get; set; }
        public string EmployerId { get; set; }
        public bool IsAwarded { get; set; } = false;

        //public string FreelancerId { get; set; }

        [Display(Name = "Created On")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Modified On")]
        public DateTimeOffset ModifiedUTC { get; set; }

        [ForeignKey("EmployerId")]
        public virtual Employer Employer { get; set; }

        //[ForeignKey("FreelancerId")]
        //public virtual Freelancer Freelancer { get; set; }
    }
}