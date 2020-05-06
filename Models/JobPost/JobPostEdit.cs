using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.JobPost
{
    public class JobPostEdit
    {
        public int JobPostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
