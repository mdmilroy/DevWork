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
    [RoutePrefix("api/Employers")]
    public class EmployerController : ApiController
    {
        private EmployerService CreateEmployerService()
        {
            //UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>();
            var userId = Guid.Parse(User.Identity.GetUserId());
            var employerService = new EmployerService(userId);
            return employerService;
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

        // api/Employer/GetEmployersList
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
            return Ok(employer);
        }

        // api/Employer/Update
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
        public IHttpActionResult Post(string id)
        {
            var service = CreateEmployerService();

            if (!service.DeleteEmployer(id))
                return InternalServerError();

            return Ok();
        }
    }
}
