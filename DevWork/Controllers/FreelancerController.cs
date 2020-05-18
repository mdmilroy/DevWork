using Contracts;
using Models.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevWork.Controllers
{
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
        public IHttpActionResult Delete (string id)
        {

            if (!_freelancerService.DeleteFreelancer(id))
                return InternalServerError();

            return Ok();
        }
    }
}
