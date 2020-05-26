using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Employer
{
    public class EmployerListItem
    {
        public string EmployerId { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
        public string State { get; set; }
        public int JobPostsActive { get; set; }
    }
}
