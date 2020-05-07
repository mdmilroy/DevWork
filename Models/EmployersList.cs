using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Profile
{
    public class ProfilesList
    {
        public Guid UserId { get; set; }
        public string Organization { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Rating { get; set; }
        public virtual string State { get; set; }
    }
}
