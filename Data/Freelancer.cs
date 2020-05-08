using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Freelancer
    {
        [Key]
        public Guid UserId { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public int JobsCompleted { get; set; }
        public double Rating { get; set; }


        [ForeignKey("State")]
        public int StateId { get; set; }
        public virtual State State { get; set; }

        //[ForeignKey("CodingLanguage")]
        //public int LanguageId { get; set; }
        //public virtual string CodingLanguage { get; set; }
    }
}