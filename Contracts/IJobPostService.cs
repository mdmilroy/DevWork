using Models;
using Models.JobPost;
using System.Collections.Generic;

namespace Contracts
{
    public interface IJobPostService
    {
        bool CreateJobPost(JobPostCreate jobPostCreate);
        IEnumerable<JobPostList> GetJobs();
        JobPostDetail GetJobPostById(string jobPostId);
        bool JobPostUpdate(JobPostUpdate jobPostUpdate);
        bool JobPostDelete(string jobPostId);
    }
}
