using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JobPostCreate
    {
        public string JobTitle { get; set; }
        public string Content { get; set; }
        public int EmployerId { get; set; }
        public int StateId { get; set; }
    }
}
