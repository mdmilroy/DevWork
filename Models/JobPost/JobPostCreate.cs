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
        public string EmployerId { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
