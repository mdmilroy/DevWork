using System;

namespace Models.Profiles
{
    public class EmployerDetail
    {
        public string EmployerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Rating { get; set; }
        public string Organization { get; set; }
        public string StateName { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
