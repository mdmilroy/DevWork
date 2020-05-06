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
            var entity =
                new JobPost()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.JobPosts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<JobPostListItem> GetAllJobPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .JobPosts
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new JobPostListItem
                                {
                                    JobPostId = e.Id,
                                    Title = e.Title,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public JobPostDetail GetJobPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .JobPosts
                        .Single(e => e.Id == id && e.OwnerId == _userId);
                return
                    new JobPostDetail
                    {
                        JobPostId = entity.Id,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }

        public bool UpdateJobPost(JobPostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .JobPosts
                        .Single(e => e.Id == model.JobPostId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteJobPost(int jobPostId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .JobPosts
                        .Single(e => e.Id == jobPostId && e.OwnerId == _userId);

                ctx.JobPosts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
