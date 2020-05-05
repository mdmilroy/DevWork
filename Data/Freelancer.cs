using System;

namespace Data
{
    public class Freelancer
    {
        public Guid FreeLancerId { get; set; }
        public string FullName { get; set; }
        public int JobsCompleted { get; set; }
        public double Rating { get; set; }
        public Enum Locations { get; set; }
        public Enum CodingLanguage { get; set; }
    }
}