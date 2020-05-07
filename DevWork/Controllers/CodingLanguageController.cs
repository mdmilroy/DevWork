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
    public class CodingLanguageController : ApiController
    {
        private CodingLanguageService CreateCodingLanguageService()
        {
            var languageService = new CodingLanguageService();
            return languageService;
        }


        public IHttpActionResult Get()
        {
            CodingLanguageService languageService = CreateCodingLanguageService();
            var notes = languageService.GetAllCodingLanguages();
            return Ok(notes);
        }

        public IHttpActionResult Post(LanguageCreate language)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCodingLanguageService();

            if (!service.CreateCodingLanguage(language))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(LanguageEdit languageToEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCodingLanguageService();

            if (!service.UpdateCodingLanguage(languageToEdit))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCodingLanguageService();

            if (!service.DeleteCodingLanguage(id))
                return InternalServerError();

            return Ok();
        }
    }
}
