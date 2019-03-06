using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.Messaging;

namespace FileService.Interfaces
{
    public interface IHandleMessages
    {
        void HandleMessage(IMessage mqMessage, IMessageQueueClient client);
    }
}
