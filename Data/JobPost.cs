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
        public int EmployerId { get; set; }
        public bool IsAwarded { get; set; } = false;
        public int State { get; set; }
        public int FreelancerId { get; set; }
    }
}