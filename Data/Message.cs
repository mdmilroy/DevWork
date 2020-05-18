using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset ModifiedUTC { get; set; }
    }
}