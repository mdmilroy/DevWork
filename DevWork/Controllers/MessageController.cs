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
    [RoutePrefix("api/Messages")]
    public class MessageController : ApiController
    {
        private MessageService CreateMessageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var messageService = new MessageService(userId);
            return messageService;
        }

        // api/Message/Create
        public IHttpActionResult Post(MessageCreate message)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMessageService();

            if (!service.CreateMessage(message))
                return InternalServerError();

            return Ok();
        }

        // api/Message/GetMessageList
        public IHttpActionResult Get()
        {
            MessageService messageService = CreateMessageService();
            var messages = messageService.GetMessages();
            return Ok(messages);
        }

        // api/Message/GetMessageById
        public IHttpActionResult Get(int id)
        {
            MessageService messageService = CreateMessageService();
            var message = messageService.GetMessageById(id);
            return Ok(message);
        }

        // api/Message/Update
        public IHttpActionResult Put(MessageUpdate message)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMessageService();

            if (!service.UpdateMessage(message))
                return InternalServerError();

            return Ok();
        }

        // api/Message/Delete
        public IHttpActionResult Post(int id)
        {
            var service = CreateMessageService();

            if (!service.DeleteMessage(id))
                return InternalServerError();

            return Ok();
        }
    }
}
