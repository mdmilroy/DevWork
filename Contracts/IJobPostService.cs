using Models;
using Models.JobPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IJobPostService
    {
        bool CreateJobPost(JobPostCreate jobPostCreate);
        IEnumerable<JobPostList> GetJobs();
        JobPostDetail GetJobPostById(int jobPostId);
        bool JobPostUpdate(int jobPostId, JobPostUpdate jobPostUpdate);
        bool JobPostDelete(int jobPostId);
    }
}
