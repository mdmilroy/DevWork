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
        public bool IsActive { get; set; } = true;


        public int StateId { get; set; }
        public virtual State State { get; set; }


        public List<JobPost> JobPosts { get; set; }

        public Freelancer()
        {
            CodingLanguages = new HashSet<CodingLanguage>();
        }

        public virtual ICollection<CodingLanguage> CodingLanguages { get; set; }
    }
}