using System;
using Common.DataTypes.Services.InventoryService;
using InventoryService.Helpers;
using InventoryService.Interfaces;
using ServiceStack.Messaging;

namespace InventoryService.Handlers
{
    public class AddFilmCommandHandler : BaseMessageHandler
    {
        public override void HandleThisMessage(IMessage mqMessage, IMessageQueueClient client)
        {
            var m = mqMessage.Body as AddFilmCommand;

            InfraHelper.AddFilm(m.Film);
        }
    }
}
