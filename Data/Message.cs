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
        public string SenderId { get; set; }
        public string RecipientId { get; set; }
        public bool IsRead { get; set; } = false;
    }
}