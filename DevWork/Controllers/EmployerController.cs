using Microsoft.AspNet.Identity;
using Models.Employer;
using Services;
using System;
using System.Web.Http;

namespace DevWork.Controllers
{
    [Authorize]
    [RoutePrefix("api/Employers")]
    public class EmployerController : ApiController
    {
        private EmployerService CreateEmployerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var employerService = new EmployerService(userId);
            return employerService;
        }

        // api/Employer/GetEmployerList
        public IHttpActionResult Get()
        {
            EmployerService employerService = CreateEmployerService();
            var employers = employerService.GetEmployers();
            return Ok(employers);
        }

        // api/Employer/GetEmployerById
        public IHttpActionResult Get(string id)
        {
            EmployerService employerService = CreateEmployerService();
            var employer = employerService.GetEmployerById(id);

            if (employer == null)
                return NotFound();

            return Ok(employer);
        }

        // api/Employer/Create
        public IHttpActionResult Post(EmployerCreate employer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEmployerService();

            if (!service.CreateEmployer(employer))
                return InternalServerError();

            return Ok();
        }

        // api/Employer/Update
        [Authorize(Roles="employer")]
        public IHttpActionResult Put(EmployerUpdate employer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEmployerService();

            if (!service.UpdateEmployer(employer))
                return InternalServerError();

            return Ok();
        }

        // api/Employer/Delete
        public IHttpActionResult Delete(string id)
        {
            var service = CreateEmployerService();

            if (!service.DeleteEmployer(id))
                return InternalServerError();

            return Ok();
        }
    }
}
