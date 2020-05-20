using Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Freelancer
    {
        [Key]
        public int FreelancerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Rating { get; set; } = 0;
        public int CodingLanguage { get; set; }
        public int JobsCompleted { get; set; } = 0;


        //[ForeignKey("State")]
        public int StateId { get; set; }
        //public virtual State State { get; set; }



        //[ForeignKey("CodingLanguage")]
        public int CodingLanguageId { get; set; }
        //public virtual CodingLanguage CodingLangauge { get; set; }
    }
}