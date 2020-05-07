﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Message
{
    public class MessageCreate
    {
        [Required]
        public Guid Recipient { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
