using System;
using Common.DataTypes.Services.InventoryService;
using InventoryService.Helpers;
using InventoryService.Interfaces;
using ServiceStack.Messaging;

namespace InventoryService.Handlers
{
    public class SetFilmAvailableCommandHandler : BaseMessageHandler
    {
        public override void HandleThisMessage(IMessage mqMessage, IMessageQueueClient client)
        {
            var m = mqMessage.Body as SetFilmAvailableCommand;

            var film = InfraHelper.GetFilm(m.FilmId);

            film.IsAvailable = true;

            InfraHelper.UpdateFilm(film);
        }
    }
}
