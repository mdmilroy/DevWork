using Contracts;
using Data;
using Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class MessageService : IMessageService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();

        public MessageService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMessage(MessageCreate messageCreate)
        {
            var entity = new Message()
            {
                Content = messageCreate.Content,
                SenderId = _userId.ToString(),
                RecipientId = messageCreate.RecipientId,
                SentDate = DateTimeOffset.UtcNow
            };

            _ctx.Messages.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public List<MessageListItem> GetMessages()
        {
            var query = _ctx.Messages.Select(m => new MessageListItem
            {
                MessageId = m.MessageId,
                SenderId = m.SenderId,
                RecipientId = m.RecipientId,
                IsRead = m.IsRead,
                SentDate = m.SentDate
            });

            return query.ToList();
        }

        public MessageDetail GetMessageById(int messageId)
        {
            var entity = _ctx.Messages.Single(m => m.MessageId == messageId);
            return new MessageDetail()
            {
                Content = entity.Content,
                SenderId = entity.SenderId,
                RecipientId = entity.RecipientId,
                IsRead = entity.IsRead,
                SentDate = entity.SentDate,
                ModifiedDate = entity.ModifiedDate
            };
        }

        public bool MessageUpdate(MessageUpdate messageUpdate)
        {
            var entity = _ctx.Messages.Single(m => m.MessageId == messageUpdate.MessageId);
            entity.MessageId = messageUpdate.MessageId;
            entity.Content = messageUpdate.Content;
            entity.IsRead = messageUpdate.IsRead;
            entity.ModifiedDate = DateTimeOffset.UtcNow;

            return _ctx.SaveChanges() == 1;
        }

        public bool MessageDelete(int messageId)
        {
            var entity = _ctx.Messages.Single(m => m.MessageId == messageId);
            _ctx.Messages.Remove(entity);
            return _ctx.SaveChanges() == 1;
        }
    }
}
