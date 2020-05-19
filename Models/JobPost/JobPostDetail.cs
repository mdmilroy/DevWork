using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JobPostDetail
    {
        public string JobTitle { get; set; }
        public string Content { get; set; }
        public int EmployerId { get; set; }
        public bool IsAwarded { get; set; } = false;
        public int FreelancerId { get; set; }
        public int State { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
