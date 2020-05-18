using Contracts;
using Microsoft.AspNet.Identity;
using Models.Profiles;
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
    [RoutePrefix("api/Freelancers")]
    public class FreelancerController : ApiController
    {
        private FreelancerService CreateFreelancerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var freelancerService = new FreelancerService(userId);
            return freelancerService;
        }

        // api/Freelancer/GetFreelancerList
        public IHttpActionResult Get()
        {
            FreelancerService freelancerService = CreateFreelancerService();
            var freelancers = freelancerService.GetFreelancers();
            return Ok(freelancers);
        }

        // api/Freelancer/GetFreelancerById
        public IHttpActionResult Get(int id)
        {
            FreelancerService freelancerService = CreateFreelancerService();
            var freelancer = freelancerService.GetFreelancerById(id);
            return Ok(freelancer);
        }

        // api/Freelancer/Create
        public IHttpActionResult Post(FreelancerCreate freelancer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFreelancerService();

            if (!service.CreateFreelancer(freelancer))
                return InternalServerError();

            return Ok();
        }

        // api/Freelancer/Update
        public IHttpActionResult Put(int id, FreelancerUpdate freelancer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFreelancerService();

            if (!service.UpdateFreelancer(id, freelancer))
                return InternalServerError();

            return Ok();
        }

        // api/Freelancer/Delete
        public IHttpActionResult Delete(int id)
        {
            var service = CreateFreelancerService();

            if (!service.DeleteFreelancer(id))
                return InternalServerError();

            return Ok();
        }
    }
}
