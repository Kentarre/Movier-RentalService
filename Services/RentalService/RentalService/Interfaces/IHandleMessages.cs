using System;
using ServiceStack.Messaging;

namespace RentalService.Interfaces
{
    public interface IHandleMessages
    {
        void HandleMessage(IMessage mqMessage, IMessageQueueClient client);
    }
}
