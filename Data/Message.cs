using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ConvoId { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "You must at least 1 character to send")]
        public string Content { get; set; }
        [Required]
        public DateTimeOffset Timestamp { get; set; }
        [Required]
        public bool Unread { get; set; }
        [Required]
        public Guid Sender { get; set; }
        [Required]
        public Guid Recipient { get; set; }
    }
}