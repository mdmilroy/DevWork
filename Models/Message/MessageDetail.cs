using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Models.Message
{
    public class MessageDetail
    {
        public string Content { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public bool IsRead { get; set; }
        public DateTimeOffset SentDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
