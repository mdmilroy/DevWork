using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.JobPost
{
    public class JobPostListItem
    {
        public int JobPostId { get; set; }
        public string JobTitle { get; set; }
        public string StateName { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
