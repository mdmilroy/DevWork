using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Freelancer : IUser
    {
        [Key]
        public string FreelancerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int JobsCompleted { get; set; } = 0;

        public double Rating { get; set; } = 0;

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }


        public int StateId { get; set; }
        public virtual State State { get; set; }


        public virtual JobPost JobPost { get; set; }

        public List<string> CodingLanguages { get; set; }
    }
}