using System;
using Common.DataTypes.Services.RentalService;
using RentalService.Interfaces;
using ServiceStack.Messaging;

namespace RentalService.Handlers
{
    public class RentalServiceTestCommandHandler : IHandleMessages
    {
        public void HandleMessage(IMessage mqMessage, IMessageQueueClient client)
        {
            var message = mqMessage.Body as RentalServiceTestCommand;

            Console.WriteLine($"Recieved message with body: {message.Request}");
        }
    }
}
