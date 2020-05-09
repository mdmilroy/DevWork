using Data;
using Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MessageService
    {
        private readonly Guid _userId;

        public MessageService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMessage(MessageCreate message)
        {
            var entity =
                new Message()
                {
                    Sender = _userId,
                    Recipient = Guid.Parse(message.Recipient),
                    Content = message.Content,
                    Timestamp = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Messages.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<MessageListItem> GetMessages()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Messages
                        .Where(e => e.Sender == _userId || e.Recipient == _userId)
                        .Select(
                            e =>
                                new MessageListItem
                                {
                                    MessageId = e.Id,
                                    Content = e.Content,
                                    TimeSent = e.Timestamp,
                                    Recipient = e.Recipient
                                }
                        );

                return query.ToArray();
            }
        }

        public MessageDetail GetMessageById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Messages
                        .Single(e => e.Id == id && e.Sender == _userId || e.Recipient == _userId);
                return
                    new MessageDetail
                    {
                        Id = entity.Id,
                        Content = entity.Content,
                        Timestamp = entity.Timestamp
                    };
            }
        }

        public bool UpdateMessage(MessageEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Messages
                        .Single(e => e.Id == model.Id && e.Sender == _userId);

                entity.Content = model.Content;
                entity.Timestamp = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMessage(int messageToDelete)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Messages
                        .Single(e => e.Id == messageToDelete && e.Sender == _userId);

                ctx.Messages.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
