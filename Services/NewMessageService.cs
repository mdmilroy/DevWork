using Contracts;
using Data;
using Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NewMessageService : IMessageService
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        private readonly Guid _userId;

        public NewMessageService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMessage(MessageCreate messageCreate)
        {
            var entity = new Message()
            {
                Content = messageCreate.Content,
                RecipientId = messageCreate.RecipientId
            };

            ctx.Messages.Add(entity);
            return ctx.SaveChanges() == 1;
        }

        public MessageDetail GetMessageById(int messageId)
        {
            var message = ctx.Messages.Single(e => e.MessageId == messageId);
            var entity = new MessageDetail()
            {
                Content = message.Content,
                SenderId = message.SenderId,
                RecipientId = message.RecipientId,
                IsRead = message.IsRead,
            };

            return entity;
        }

        public IEnumerable<MessageListItem> GetMessages()
        {
            var messageList = ctx.Messages.Select(e => new MessageListItem()
            {
                MessageId = e.MessageId,
                RecipientId = e.RecipientId,
                Content = e.Content,
                IsRead = e.IsRead
            }).ToArray();

            return messageList;
        }

        public bool MessageDelete(int messageId)
        {
            var message = ctx.Messages.Single(e => e.MessageId == messageId);
            ctx.Messages.Remove(message);
            return ctx.SaveChanges() == 1;
        }

        public bool MessageUpdate(int messageId, MessageUpdate messageUpdate)
        {
            var message = ctx.Messages.Single(e => e.MessageId == messageId);

            message.Content = messageUpdate.Content;
            message.IsRead = messageUpdate.IsRead;

            return ctx.SaveChanges() == 1;
        }
    }
}
