using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class JobPost
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public DateTimeOffset DatePosted { get; set; }
        [Required]
        public DateTimeOffset Deadline { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "You must enter at least 3 characters for the title")]
        public string Title { get; set; }
        [Required]
        [MinLength(20, ErrorMessage = "You must enter at least 20 characters for the content")]
        public string Content { get; set; }
        [Required]
        public double Budget { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}