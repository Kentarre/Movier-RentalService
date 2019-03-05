using System;
using Common.DataTypes.Services.InventoryService;
using InventoryService.Helpers;
using InventoryService.Interfaces;
using ServiceStack.Messaging;

namespace InventoryService.Handlers
{
    public class UpdateFilmCommandHandler : BaseMessageHandler
    {
        public override void HandleThisMessage(IMessage mqMessage, IMessageQueueClient client)
        {
            var m = mqMessage.Body as UpdateFilmCommand;

            InfraHelper.UpdateFilm(m.Film);
        }
    }
}
