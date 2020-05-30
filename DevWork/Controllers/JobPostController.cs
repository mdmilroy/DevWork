using Microsoft.AspNet.Identity;
using Models;
using Models.JobPost;
using Services;
using System;
using System.Web.Http;

namespace DevWork.Controllers
{
    [Authorize]
    [RoutePrefix("api/JobPosts")]
    public class JobPostController : ApiController
    {
        [Authorize(Roles="employer")]
        private JobPostService CreateJobPostService()
        {
            var userId = User.Identity.GetUserId();
            var jobPostService = new JobPostService(userId);
            return jobPostService;
        }

        // api/Freelancer/GetJobPostList
        [Route("GetAllPosts")]
        public IHttpActionResult Get()
        {
            JobPostService jobPostService = CreateJobPostService();
            var jobPosts = jobPostService.GetJobs();
            return Ok(jobPosts);
        }

        // api/Freelancer/GetJobPostById
        [Route("GetPostsById")]
        public IHttpActionResult Get(int id)
        {
            JobPostService jobPostService = CreateJobPostService();
            var jobPost = jobPostService.GetJobPostById(id);

            if (jobPost == null)
                return NotFound();

            return Ok(jobPost);
        }

        // api/Freelancer/GetJobPostByEmployerId
        [Route("GetByEmployerId")]
        public IHttpActionResult Get(string employerId)
        {
            JobPostService jobPostService = CreateJobPostService();
            var jobPosts = jobPostService.GetJobsByEmployerId(employerId);
            return Ok(jobPosts);
        }

        // api/JobPost/Create
        [Route("Create")]
        public IHttpActionResult Post(JobPostCreate jobPost)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateJobPostService();

            if (!service.CreateJobPost(jobPost))
                return InternalServerError();

            return Ok();
        }

        // api/JobPost/Update
        [Route("UpdateById")]
        public IHttpActionResult Put(JobPostUpdate jobPost)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateJobPostService();

            if (!service.JobPostUpdate(jobPost))
                return InternalServerError();

            return Ok();
        }

        // api/JobPost/Delete
        [Route("DeleteById")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateJobPostService();

            if (!service.JobPostDelete(id))
                return InternalServerError();

            return Ok();
        }
    }
}
