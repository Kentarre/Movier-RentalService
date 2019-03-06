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
            if (mqMessage.Body is UpdateFilmCommand m)
                InfraHelper.UpdateFilm(m.Film);
        }
    }
}
