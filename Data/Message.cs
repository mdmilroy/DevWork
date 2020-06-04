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
        [Display(Name = "Message Id")]
        public int MessageId { get; set; }
        
        [Display(Name = "Message")]
        public string Content { get; set; }
        
        [Display(Name = "Read")]
        public bool IsRead { get; set; } = false;
        
        [Display(Name = "Sent")]
        public DateTimeOffset SentDate { get; set; }
        
        [Display(Name = "Edited")]
        public DateTimeOffset ModifiedDate { get; set; }
        
        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;
        
        [Display(Name = "Sender")]
        public string Sender { get; set; }
        
        [Display(Name = "Recipient")]
        public string Receiver { get; set; }

        public virtual ApplicationUser Recipient { get; set; }
    }
}
