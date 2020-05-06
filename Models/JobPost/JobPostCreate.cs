using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JobPostCreate
    {
        [Required]
        [MinLength(5, ErrorMessage = "Please enter at least 5 characters.")]
        [MaxLength(125, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        [MaxLength(8000, ErrorMessage = "Shorten your message below 8000 characters")]
        public string Content { get; set; }

    }
}
