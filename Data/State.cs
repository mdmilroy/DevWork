using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class State
    {
        [Key]
        [Display(Name = "State Id")]
        public int StateId { get; set; }
        [Display(Name = "State Name")]
        public string StateName { get; set; }

        public ICollection<Freelancer> Freelancers { get; set; }
        public ICollection<Employer> Employers { get; set; }
        public ICollection<JobPost> JobPosts { get; set; }
    }
}