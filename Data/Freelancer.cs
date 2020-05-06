using System;

namespace Data
{
    public class Freelancer
    {
        public Guid FreeLancerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JobsCompleted { get; set; }
        public double Rating { get; set; }
        public Enum Location { get; set; }
        public Enum CodingLanguage { get; set; }
    }
}