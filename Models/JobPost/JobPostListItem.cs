using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JobPostListItem
    {
        public int JobPostId { get; set; }
        public string Title { get; set; }
        [Display(Name = "Created On")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
