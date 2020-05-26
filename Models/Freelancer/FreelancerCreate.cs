using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Freelancer
{
    public class FreelancerCreate
    {
        public string FreelancerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CodingLanguage { get; set; }

        [MaxLength(2)]
        public string State { get; set; }

    }
}
