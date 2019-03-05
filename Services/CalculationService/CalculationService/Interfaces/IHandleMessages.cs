using System;
using ServiceStack.Messaging;

namespace CalculationService.Interfaces
{
    public interface IHandleMessages
    {
        void HandleMessage(IMessage mqMessage, IMessageQueueClient client);
    }
}
