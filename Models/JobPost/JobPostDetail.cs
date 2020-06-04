using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.JobPost
{
    public class JobPostDetail
    {
        public string JobTitle { get; set; }
        public string Content { get; set; }
        public string State { get; set; }
        public bool IsAwarded { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string EmployerId { get; set; }
        public string FreelancerId { get; set; }
        public bool IsActive { get; set; }
    }
}
