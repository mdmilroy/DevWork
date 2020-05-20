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

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Organization { get; set; }

        [Required]
        public double Rating { get; set; } = 0;


        //[ForeignKey("User")]
        public string Id { get; set; }
        //public virtual ApplicationUser User { get; set; }


        //[ForeignKey("State")]
        public int StateId { get; set; }
        //public virtual State State { get; set; }
    }
}