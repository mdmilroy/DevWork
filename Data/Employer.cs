using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Employer : IUser
    {
        [Key]
        public string EmployerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
        public double Rating { get; set; } = 0;
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public int JobsCompleted { get; set; } = 0;
        public bool IsActive { get; set; } = true;


        public int StateId { get; set; }
        public virtual State State { get; set; }

        public List<JobPost> JobPosts { get; set; }


    }
}