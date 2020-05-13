using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public string EmployerId { get; set; }
        public string FreelancerId { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset ModifiedUTC { get; set; }

        [ForeignKey("Employer")]
        public virtual Employer Employer { get; set; }

        [ForeignKey("Freelancer")]
        public virtual Freelancer Freelancer { get; set; }
    }
}