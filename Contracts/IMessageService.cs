using Models.Message;
using System.Collections.Generic;

namespace Contracts
{
    public interface IMessageService
    {
        bool CreateMessage(MessageCreate messageCreate);
        IEnumerable<MessageListItem> GetMessages();
        MessageDetail GetMessageById(int messageId);
        bool MessageUpdate(int messageId, MessageUpdate messageUpdate);
        bool MessageDelete(int messageId);
    }
}
