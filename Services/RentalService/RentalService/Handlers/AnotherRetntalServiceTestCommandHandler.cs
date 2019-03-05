using System;
using Common.DataTypes.Services.RentalService;
using RentalService.Interfaces;
using ServiceStack.Messaging;

namespace RentalService.Handlers
{
    public class AnotherRetntalServiceTestCommandHandler : IHandleMessages
    {
        public void HandleMessage(IMessage mqMessage, IMessageQueueClient client)
        {
            var message = mqMessage.Body as AnotherRentalServiceTestCommand;

            Console.WriteLine($"Recieved message with body: {message.Request}");
        }
    }
}
