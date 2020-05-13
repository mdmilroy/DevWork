using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Profiles
{
    public class EmployerDetail
    {
        public string EmployerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Rating { get; set; }
        public string Organization { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
