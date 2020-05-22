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
        public string RecipientId { get; set; }
    }
}
