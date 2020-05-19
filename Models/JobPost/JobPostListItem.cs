using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JobPostList
    {
        public int JobPostId { get; set; }
        public string JobTitle { get; set; }
        public int State { get; set; }

        public bool IsAwarded { get; set; } = false;
    }
}
