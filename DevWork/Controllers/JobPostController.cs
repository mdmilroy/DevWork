using Microsoft.AspNet.Identity;
using Models;
using Models.JobPost;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevWork.Controllers
{
    [Authorize]
    public class JobPostController : ApiController
    {
        private JobPostService CreateJobPostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var jobPostService = new JobPostService(userId);
            return jobPostService;
        }

        public IHttpActionResult Get()
        {
            JobPostService jobPostService = CreateJobPostService();
            var jobpost = jobPostService.GetAllJobPosts();
            return Ok(jobpost);
        }

        public IHttpActionResult Post(JobPostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateJobPostService();

            if (!service.CreateJobPost(post))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            JobPostService jobPostService = CreateJobPostService();
            var jobPost = jobPostService.GetJobPostById(id);
            return Ok(jobPost);
        }

        public IHttpActionResult Put(JobPostEdit jobPost)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateJobPostService();

            if (!service.UpdateJobPost(jobPost))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateJobPostService();

            if (!service.DeleteJobPost(id))
                return InternalServerError();

            return Ok();
        }
    }
}
