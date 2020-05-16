using Data;
using Models;
using Models.JobPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class JobPostService
    {
        private readonly Guid _userId;

        public JobPostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateJobPost(JobPostCreate model)
        {
            var entity = new JobPost()
            {
                JobTitle = model.JobTitle,
                Content = model.Content,
                CreatedUTC = DateTimeOffset.UtcNow
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.JobPosts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<JobPostList> GetJobPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .JobPosts
                    .Where(e => e.EmployerId == _userId.ToString())
                    .Select(e => new JobPostList
                    {
                        JobPostId = e.JobPostId,
                        JobTitle = e.JobTitle,
                        IsAwarded = e.IsAwarded,
                        //FreelancerId = e.FreelancerId
                    });
                return query.ToArray();
            }
        }

        public JobPostDetail GetJobPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .JobPosts
                    .Single(e => e.JobPostId == id && e.EmployerId == _userId.ToString());
                return
                    new JobPostDetail
                    {
                        JobTitle = entity.JobTitle,
                        Content = entity.Content,
                        EmployerId = entity.EmployerId,
                        IsAwarded = entity.IsAwarded,
                        //FreelancerId = entity.FreelancerId,
                        CreatedUTC = entity.CreatedUTC
                    };
            }
        }

        public bool UpdateJobPost(JobPostUpdate jobPostToUpdate)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .JobPosts
                    .Single(e => e.JobPostId == jobPostToUpdate.JobPostId && e.EmployerId == _userId.ToString());

                entity.JobPostId = jobPostToUpdate.JobPostId;
                entity.JobTitle = jobPostToUpdate.JobTitle;
                entity.Content = jobPostToUpdate.Content;
                entity.EmployerId = jobPostToUpdate.EmployerId;
                entity.IsAwarded = jobPostToUpdate.IsAwarded;
                //entity.FreelancerId = jobPostToUpdate.FreelancerId;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteJobPost(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .JobPosts
                        .Single(e => e.JobPostId == id && e.EmployerId == _userId.ToString());

                ctx.JobPosts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
