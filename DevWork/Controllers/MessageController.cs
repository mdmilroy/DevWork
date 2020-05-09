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
    [RoutePrefix("api/Message")]
    public class MessageController : ApiController
    {
        private MessageService CreateMessageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var messageService = new MessageService(userId);
            return messageService;
        }

        public IHttpActionResult Get()
        {
            MessageService messageService = CreateMessageService();
            var notes = messageService.GetMessages();
            return Ok(notes);
        }

        public IHttpActionResult Post(MessageCreate message)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMessageService();

            if (!service.CreateMessage(message))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            MessageService messageService = CreateMessageService();
            var message = messageService.GetMessageById(id);
            return Ok(message);
        }

        public IHttpActionResult Put(MessageEdit messageToEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMessageService();

            if (!service.UpdateMessage(messageToEdit))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateMessageService();

            if (!service.DeleteMessage(id))
                return InternalServerError();

            return Ok();
        }
    }
}
