using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.JobPost
{
    public class JobPostCreate
    {
        public string JobTitle { get; set; }
        public string Content { get; set; }
        public int StateId { get; set; }
    }
}
