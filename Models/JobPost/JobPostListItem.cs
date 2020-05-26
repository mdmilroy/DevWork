namespace Models
{
    public class JobPostList
    {
        public string JobPostId { get; set; }
        public string JobTitle { get; set; }
        public string StateName { get; set; }

        public bool IsAwarded { get; set; } = false;
    }
}
