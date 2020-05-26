using System;
using System.Collections.Generic;

namespace Models.Profiles
{
    public class FreelancerDetail
    {
        public string FreelancerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Rating { get; set; }

        public List<string> CodingLanguage { get; set; }
        public int JobsCompleted { get; set; }
        public string StateName { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
