using System;
using Common.DataTypes.Services.RentalService;
using Main.Interfaces;
using ServiceStack.Messaging;

namespace Main.ResponseHost.Handlers
{
    public class AnotherRentalServiceTestCommandResponseHandler : IHandleMessages
    {
        public void HandleMessage(IMessage mqMessage)
        {
            var message = mqMessage.Body as AnotherRentalServiceTestCommandResponse;

            Console.WriteLine("Received AnotherRentalServiceTestCommandResponse: " + message.Result);
        }
    }
}
