using Contracts;
using Data;
using Models;
using Models.JobPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NewJobPostService : IJobPostService
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        private readonly Guid _userId;

        public NewJobPostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateJobPost(JobPostCreate jobPostCreate)
        {
            var entity = new JobPost()
            {
                JobTitle = jobPostCreate.JobTitle,
                Content = jobPostCreate.Content,
                EmployerId = jobPostCreate.EmployerId,
            };

            ctx.JobPosts.Add(entity);
            return ctx.SaveChanges() == 1;

        }

        public JobPostDetail GetJobPostById(int jobPostId)
        {
            var post = ctx.JobPosts.Single(e => e.JobPostId == jobPostId);
            var entity = new JobPostDetail()
            {
                JobTitle = post.JobTitle,
                Content = post.Content,
                EmployerId = post.EmployerId,
                IsAwarded = post.IsAwarded,
                FreelancerId = post.FreelancerId,
            };

            return entity;
        }

        public IEnumerable<JobPostList> GetJobs()
        {
            var jobsList = ctx.JobPosts.Select(e => new JobPostList()
            {
                JobPostId = e.JobPostId,
                JobTitle = e.JobTitle,
                IsAwarded = e.IsAwarded
            }).ToArray();

            return jobsList;
        }

        public bool JobPostDelete(int jobPostId)
        {
            var post = ctx.JobPosts.Single(e => e.JobPostId == jobPostId);
            ctx.JobPosts.Remove(post);
            return ctx.SaveChanges() == 1;
        }

        public bool JobPostUpdate(int jobPostId, JobPostUpdate jobPostUpdate)
        {
            var post = ctx.JobPosts.Single(e => e.JobPostId == jobPostId);

            post.JobTitle = jobPostUpdate.JobTitle;
            post.Content = jobPostUpdate.Content;
            post.EmployerId = jobPostUpdate.EmployerId;
            post.IsAwarded = jobPostUpdate.IsAwarded;
            post.FreelancerId = jobPostUpdate.FreelancerId;

            return ctx.SaveChanges() == 1;
        }
    }
}
