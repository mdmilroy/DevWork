using Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
