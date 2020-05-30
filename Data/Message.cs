using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string SenderId { get; set; }
        public string RecipientId { get; set; }

        public virtual ApplicationUser Recipient { get; set; }
    }
}
