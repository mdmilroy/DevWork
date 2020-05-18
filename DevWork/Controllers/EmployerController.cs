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
    public class EmployerController : ApiController
    {
        private readonly IEmployerService _employerService;

        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        // api/Employer/Create
        public IHttpActionResult Post(EmployerCreate employer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!_employerService.CreateEmployer(employer))
                return InternalServerError();

            return Ok();
        }

        // api/Employer/GetEmployersList
        public IHttpActionResult Get()
        {
            var employers = _employerService.GetEmployers();
            return Ok(employers);
        }

        // api/Employer/GetEmployerById
        public IHttpActionResult Get(string id)
        {
            var employer = _employerService.GetEmployerById(id);
            return Ok(employer);
        }

        // api/Employer/Update
        public IHttpActionResult Put(EmployerUpdate employer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!_employerService.UpdateEmployer(employer))
                return InternalServerError();

            return Ok();
        }

        // api/Employer/Delete
        public IHttpActionResult Post(string id)
        {

            if (!_employerService.DeleteEmployer(id))
                return InternalServerError();

            return Ok();
        }
    }
}
