using Models.Message;
using System.Collections.Generic;

namespace Contracts
{
    public interface IMessageService
    {
        bool CreateMessage(MessageCreate messageCreate);
        List<MessageListItem> GetMessages();
        MessageDetail GetMessageById(int messageId);
        bool MessageUpdate(MessageUpdate messageUpdate);
        bool MessageDelete(int messageId);
    }
}
