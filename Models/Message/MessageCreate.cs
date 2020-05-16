using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Message
{
    public class MessageCreate
    {
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
    }
}
