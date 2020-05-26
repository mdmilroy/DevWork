namespace Models.Profiles
{
    public class FreelancerUpdate
    {
        public string FreelancerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Rating { get; set; }
        public string CodingLanguage { get; set; }
        public int JobsCompleted { get; set; }
        public int StateId { get; set; }
    }
}
