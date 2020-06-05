using Contracts;
using Microsoft.AspNet.Identity;
using Models.Freelancer;
using Services;
using System;
using System.Web.Http;

namespace DevWork.Controllers
{
    [Authorize]
    [RoutePrefix("api/Freelancers")]
    public class FreelancerController : ApiController
    {
        private readonly IFreelancerService _freelancerService;

        public FreelancerController(IFreelancerService freelancerService)
        {
            _freelancerService = freelancerService;
        }

        // api/Freelancer/Create
        public IHttpActionResult Post(FreelancerCreate freelancer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!_freelancerService.CreateFreelancer(freelancer))
                return InternalServerError();

            return Ok();
        }

        // api/Freelancer/GetFreelancersList
        public IHttpActionResult Get()
        {
            var freelancers = _freelancerService.GetFreelancers();
            return Ok(freelancers);
        }

        // api/Freelancer/GetFreelancerById
        public IHttpActionResult Get(string id)
        {
            var freelancer = _freelancerService.GetFreelancerById(id);
            return Ok(freelancer);
        }

        // api/Freelancer/Update
        public IHttpActionResult Put(FreelancerUpdate freelancer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!_freelancerService.UpdateFreelancer(freelancer))
                return InternalServerError();

            return Ok();
        }

        // api/Freelancer/Delete
        public IHttpActionResult Post(string id)
        {

            if (!_freelancerService.DeleteFreelancer(id))
                return InternalServerError();

            return Ok();
        }
    }
}