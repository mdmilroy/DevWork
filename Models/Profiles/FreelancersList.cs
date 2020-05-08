using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Profile
{
    public class FreelancersList
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JobsCompleted { get; set; }
        public double Rating { get; set; }
        public string State { get; set; }
        public string CodingLanguage { get; set; }
    }
}
