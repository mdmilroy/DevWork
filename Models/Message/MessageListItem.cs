using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Message
{
    public class MessageListItem
    {
        public int MessageId { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public bool IsRead { get; set; }
        public DateTimeOffset SentDate { get; set; }
    }
}
