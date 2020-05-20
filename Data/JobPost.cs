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
        public int EmployerId { get; set; }
        public bool IsAwarded { get; set; } = false;
        public int FreelancerId { get; set; }


        [ForeignKey("State")]
        public int StateId { get; set; }
        public virtual State State { get; set; }
    }
}