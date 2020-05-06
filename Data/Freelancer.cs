using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Freelancer
    {
        [Key]
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JobsCompleted { get; set; }
        public double Rating { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }
        public virtual string State { get; set; }

        [ForeignKey("CodingLanguage")]
        public int CodeId { get; set; }
        public virtual string CodingLanguage { get; set; }
    }
}