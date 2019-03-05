using System;
using Common.DataTypes.Services.RentalService;
using Main.Interfaces;
using ServiceStack.Messaging;

namespace Main.ResponseHost.Handlers
{
    public class RentalServiceTestCommandResponseHandler : IHandleMessages
    {
        public void HandleMessage(IMessage mqMessage)
        {
            var message = mqMessage.Body as RentalServiceTestCommandResponse;

            Console.WriteLine("Received RentalServiceTestCommandResponse: " + message.Result);
        }
    }
}
