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
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        // api/Message/GetMessageList
        public IHttpActionResult Get()
        {
            var messages = _messageService.GetMessages();
            return Ok(messages);
        }

        // api/Message/GetMessageById
        public IHttpActionResult Get(int id)
        {
            var message = _messageService.GetMessageById(id);

            if (message == null)
                return NotFound();

            return Ok(message);
        }

        // api/Message/Create
        public IHttpActionResult Post(MessageCreate message)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_messageService.CreateMessage(message))
                return InternalServerError();

            return Ok();
        }

        // api/Message/Update
        public IHttpActionResult Put(MessageUpdate message)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_messageService.MessageUpdate(message))
                return InternalServerError();

            return Ok();
        }

        // api/Message/Delete
        public IHttpActionResult Delete(int id)
        {
            if (!_messageService.MessageDelete(id))
                return InternalServerError();

            return Ok();
        }
    }
}
