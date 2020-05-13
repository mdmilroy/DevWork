using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Employer
    {
        //public int EmployerId { get; set; }
        public string EmployerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Rating { get; set; } = 0;
        public string Organization { get; set; }

        [Display(Name = "Join Date")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Last Updated")]
        public DateTimeOffset ModifiedUTC { get; set; }

    }
}