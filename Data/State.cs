using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }

        public ICollection<Freelancer> Freelancers { get; set; }
        public ICollection<Employer> Employers { get; set; }
    }
}