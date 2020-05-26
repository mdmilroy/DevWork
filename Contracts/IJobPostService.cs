using Models;
using Models.JobPost;
using System.Collections.Generic;

namespace Contracts
{
    public interface IJobPostService
    {
        bool CreateJobPost(JobPostCreate jobPostCreate);
        List<JobPostListItem> GetJobs();
        JobPostDetail GetJobPostById(int jobPostId);
        bool JobPostUpdate(JobPostUpdate jobPostUpdate);
        bool JobPostDelete(int jobPostId);
    }
}
