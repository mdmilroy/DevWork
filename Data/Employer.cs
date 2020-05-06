using System;

namespace Data
{
    public class Employer
    {
        public Guid EmployerId { get; set; }
        public string Organization { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Rating { get; set; }
        public Enum Location { get; set; }
    }
}