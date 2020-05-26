using System;

namespace Models
{
    public class JobPostDetail
    {
        public string JobTitle { get; set; }
        public string Content { get; set; }
        public string EmployerId { get; set; }
        public bool IsAwarded { get; set; } = false;
        public string FreelancerId { get; set; }
        public string StateName { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
