using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class JobPost
    {
        [Key]
        public int JobPostId { get; set; }

        public string JobTitle { get; set; }
        public string Content { get; set; }
        public string StateName { get; set; }
        public bool IsAwarded { get; set; } = false;
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public bool IsActive { get; set; } = true;


        public string EmployerId { get; set; }
        public virtual Employer Employer { get; set; }


        public string FreelancerId { get; set; }
        public virtual Freelancer Freelancer { get; set; }

    }
}