namespace Models.JobPost
{
    public class JobPostUpdate
    {
        public string JobPostId { get; set; }
        public string JobTitle { get; set; }
        public string Content { get; set; }
        public string EmployerId { get; set; }
        public bool IsAwarded { get; set; } = false;
        public string FreelancerId { get; set; }
        public string StateName { get; set; }

    }
}
