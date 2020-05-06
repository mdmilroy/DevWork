using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Employer
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string Organization { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        public double Rating { get; set; }

        [ForeignKey("State")]
        public int Id { get; set; }
        public virtual string State { get; set; }
    }
}