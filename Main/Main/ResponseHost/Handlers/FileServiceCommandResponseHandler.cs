using System;
using Common.DataTypes.Services.FileService;
using Main.Interfaces;
using ServiceStack.Messaging;

namespace Main.ResponseHost.Handlers
{
    public class FileServiceCommandResponseHandler : IHandleMessages
    {
        public void HandleMessage(IMessage mqMessage)
        {
            var message = mqMessage.Body as CreateInvoiceCommandResponse;


        }
    }
}
