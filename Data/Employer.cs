using Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Employer
    {
        [Key]
        public int EmployerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Rating { get; set; } = 0;
        public string Organization { get; set; }

        //[ForeignKey("State")]
        public int StateId { get; set; }
        //public virtual State State { get; set; }
    }
}