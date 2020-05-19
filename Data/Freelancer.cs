using Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Freelancer
    {
        public int FreelancerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Rating { get; set; } = 0;
        public int CodingLanguage { get; set; }
        public int JobsCompleted { get; set; } = 0;
        public int State { get; set; }
    }
}