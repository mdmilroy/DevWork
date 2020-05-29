using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTimeOffset SentDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public virtual ApplicationUser Sender { get; set; }

        [ForeignKey("Recipient")]
        public string RecipientId { get; set; }
        public virtual ApplicationUser Recipient { get; set; }

    }
}