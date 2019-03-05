using System;
using ServiceStack.Messaging;

namespace InventoryService.Interfaces
{
    public interface IHandleMessages
    {
        void HandleMessage(IMessage mqMessage, IMessageQueueClient client);
    }
}
