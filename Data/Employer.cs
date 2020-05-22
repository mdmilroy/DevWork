using Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Employer
    {
        [Key]
        public string EmployerId { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Organization { get; set; }

        [Required]
        public double Rating { get; set; } = 0;

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        
        public DateTimeOffset ModifiedUTC { get; set; }


        public int StateId { get; set; }
        public virtual State State { get; set; }

        public ICollection<JobPost> JobPosts { get; set; }
    }
}