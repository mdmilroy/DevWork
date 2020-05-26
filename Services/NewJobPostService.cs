using Contracts;
using Data;
using Models;
using Models.JobPost;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class NewJobPostService : IJobPostService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();


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
                StateName = jobPostCreate.StateName,
                EmployerId = _userId.ToString(),
                CreatedUTC = DateTimeOffset.UtcNow
            };
            ctx.JobPosts.Add(entity);
            return ctx.SaveChanges() == 1; //TODO AUTO-INCREMENT JOBPOSTID

        }

        public JobPostDetail GetJobPostById(string jobPostId)
        {
            var post = ctx.JobPosts.Single(e => e.JobPostId == jobPostId);
            var entity = new JobPostDetail()
            {
                JobTitle = post.JobTitle,
                Content = post.Content,
                EmployerId = post.EmployerId,
                IsAwarded = post.IsAwarded,
                FreelancerId = post.Freelancer.FreelancerId,
                StateName = post.StateName,
                CreatedUTC = post.CreatedUTC

            };

            return entity;
        }

        public IEnumerable<JobPostList> GetJobs()
        {
            var jobsList = ctx.JobPosts.Select(e => new JobPostList()
            {
                JobPostId = e.JobPostId,
                JobTitle = e.JobTitle,
                IsAwarded = e.IsAwarded,
                StateName = e.StateName
            }).ToArray();

            return jobsList;
        }

        public bool JobPostDelete(string jobPostId)
        {
            var post = ctx.JobPosts.Single(e => e.JobPostId == jobPostId);
            ctx.JobPosts.Remove(post);
            return ctx.SaveChanges() == 1;
        }

        public bool JobPostUpdate(JobPostUpdate jobPostUpdate)
        {
            var post = ctx.JobPosts.Single(e => e.JobPostId == jobPostUpdate.JobPostId);

            post.JobTitle = jobPostUpdate.JobTitle;
            post.Content = jobPostUpdate.Content;
            post.EmployerId = jobPostUpdate.EmployerId;
            post.IsAwarded = jobPostUpdate.IsAwarded;
            post.Freelancer.FreelancerId = jobPostUpdate.FreelancerId;
            post.StateName = jobPostUpdate.StateName;
            post.ModifiedUTC = DateTimeOffset.UtcNow;

            return ctx.SaveChanges() == 1;
        }
    }
}
