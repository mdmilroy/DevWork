using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Message
{
    public class MessageDetail
    {
        public Guid Sender { get; set; }
        public Guid Recipient { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
