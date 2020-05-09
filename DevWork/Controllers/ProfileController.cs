using Data;
using Microsoft.AspNet.Identity;
using Models.Message;
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
    [RoutePrefix("api/Profile")]
    public class ProfileController : ApiController
    {
        private ProfileService CreateProfileService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var profileService = new ProfileService(userId);
            return profileService;
        }

        [HttpGet]
        [Route("GetEmployers")]
        public IHttpActionResult GetEmployers()
        {
            ProfileService profileService = CreateProfileService();
            var notes = profileService.GetEmployers();
            return Ok(notes);
        }

        [HttpGet]
        [Route("GetFreelancers")]
        public IHttpActionResult GetFreelancers()
        {
            ProfileService profileService = CreateProfileService();
            var notes = profileService.GetFreelancers();
            return Ok(notes);
        }

        [HttpGet]
        [Route("GetEmployerById")]
        public IHttpActionResult GetEmployer(int id)
        {
            ProfileService profileService = CreateProfileService();
            var employer = profileService.GetEmployerById(id);
            return Ok(employer);
        }

        [HttpGet]
        [Route("GetFreelancerById")]
        public IHttpActionResult GetFreelancer(int id)
        {
            ProfileService profileService = CreateProfileService();
            var freelancer = profileService.GetFreelancerById(id);
            return Ok(freelancer);
        }
    }
}
