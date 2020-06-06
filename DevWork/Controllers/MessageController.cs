using Contracts;
using Microsoft.AspNet.Identity;
using Models.Message;
using Services;
using System;
using System.Web.Http;

namespace DevWork.Controllers
{
    [Authorize]
    [RoutePrefix("api/Messages")]
    public class MessageController : ApiController
    {
        private MessageService CreateMessageService()
        {
            var userId = User.Identity.GetUserId();
            var messageService = new MessageService(userId);
            return messageService;
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

            if (message == null)
                return NotFound();

            return Ok(message);
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

        // api/Message/Update
        [Authorize(Roles = "message")]
        public IHttpActionResult Put(MessageUpdate message)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMessageService();

            if (!service.MessageUpdate(message))
                return InternalServerError();

            return Ok();
        }

        // api/Message/Delete
        public IHttpActionResult Delete(int id)
        {
            var service = CreateMessageService();

            if (!service.MessageDelete(id))
                return InternalServerError();

            return Ok();
        }
    }
}
