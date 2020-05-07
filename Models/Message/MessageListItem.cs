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
        public string Content { get; set; }
        public DateTimeOffset TimeSent { get; set; }
        public Guid Sender { get; set; }
        public Guid Recipient { get; set; }
    }
}
