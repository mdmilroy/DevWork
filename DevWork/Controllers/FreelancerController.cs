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
        private FreelancerService CreateFreelancerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var freelancerService = new FreelancerService(userId);
            return freelancerService;
        }

        // api/Freelancer/Create
        [Route("Create")]
        public IHttpActionResult Post(FreelancerCreate freelancer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFreelancerService();

            if (!service.CreateFreelancer(freelancer))
                return InternalServerError();

            return Ok();
        }

        // api/Freelancer/GetFreelancerList
        [Route("GetAllFreelancers")]
        public IHttpActionResult Get()
        {
            FreelancerService freelancerService = CreateFreelancerService();
            var freelancers = freelancerService.GetFreelancers();
            return Ok(freelancers);
        }

        // api/Freelancer/GetFreelancerById
        [Route("GetById")]
        public IHttpActionResult Get(string id)
        {
            FreelancerService freelancerService = CreateFreelancerService();
            var freelancer = freelancerService.GetFreelancerById(id);
            return Ok(freelancer);
        }

        // api/Freelancer/Update
        [Authorize(Roles="freelancer")]
        [Route("Update")]
        public IHttpActionResult Put(FreelancerUpdate freelancer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFreelancerService();

            if (!service.UpdateFreelancer(freelancer))
                return InternalServerError();

            return Ok();
        }

        // api/Freelancer/AddCodingLanguage
        [Authorize(Roles="freelancer")]
        [Route("AddCodingLanguage")]
        public IHttpActionResult Put(FreelancerAddCodingLanguage codingLanguageId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFreelancerService();

            if (!service.AddCodingLanguage(codingLanguageId))
                return InternalServerError();

            return Ok();
        }

        // api/Freelancer/RemoveCodingLanguage
        [Authorize(Roles="freelancer")]
        [Route("RemoveCodingLanguage")]
        public IHttpActionResult Put(FreelancerRemoveCodingLanguage codingLanguageId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFreelancerService();

            if (!service.RemoveCodingLanguage(codingLanguageId))
                return InternalServerError();

            return Ok();
        }

        // api/Freelancer/Delete
        [Route("Delete")]
        public IHttpActionResult Delete(string id)
        {
            var service = CreateFreelancerService();

            if (!service.DeleteFreelancer(id))
                return InternalServerError();

            return Ok();
        }
    }
}
