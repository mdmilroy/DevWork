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
        private readonly string _userId;
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();
        public MessageService(string userId)
        {
            _userId = userId;
        }

        public bool CreateMessage(MessageCreate messageCreate)
        {
            var entity = new Message()
            {
                Content = messageCreate.Content,
                SentDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            };

            var user = _ctx.Users.Find(_userId);
            if (user.UserRole == "employer")
            {
                var sender = _ctx.Employers.Where(e => e.EmployerId == _userId).Select(e => e.FirstName).FirstOrDefault();
                entity.Sender = sender;
            }
            else if (user.UserRole == "freelancer")
            {
                var sender = _ctx.Freelancers.Where(e => e.FreelancerId == _userId).Select(e => e.FirstName).FirstOrDefault();
                entity.Sender = sender;
            }

            if (user.UserRole == "employer")
            {
                var recipient = _ctx.Employers.Where(e => e.EmployerId == messageCreate.RecipientId).Select(e => e.FirstName).FirstOrDefault();
                entity.Receiver = recipient;
            }
            else if (user.UserRole == "freelancer")
            {
                var recipient = _ctx.Freelancers.Where(e => e.FreelancerId == messageCreate.RecipientId).Select(e => e.FirstName).FirstOrDefault();
                entity.Receiver = recipient;
            }

            _ctx.Messages.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public List<MessageListItem> GetMessages()
        {
            var query = _ctx.Messages.Where(m => m.IsActive == true).Select(m => new MessageListItem
            {
                MessageId = m.MessageId,
                Sender = m.Sender,
                Recipient = m.Receiver,
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
                Sender = entity.Sender,
                Recipient = entity.Receiver,
                IsRead = entity.IsRead,
                SentDate = entity.SentDate,
                ModifiedDate = entity.ModifiedDate,
                IsActive = entity.IsActive
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
            entity.IsActive = false;
            //_ctx.Messages.Remove(entity);
            return _ctx.SaveChanges() == 1;
        }
    }
}
