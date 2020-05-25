using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class JobPost
    {
        [ForeignKey("Freelancer")]
        public string JobPostId { get; set; }

        [Required]
        public string JobTitle { get; set; }
        
        [Required]
        public string Content { get; set; }

        public string StateName { get; set; }
        public bool IsAwarded { get; set; } = false;
        
        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset ModifiedUTC { get; set; }

        public string EmployerId { get; set; }
        public virtual Employer Employer { get; set; }


        public virtual Freelancer Freelancer { get; set; }

    }
}