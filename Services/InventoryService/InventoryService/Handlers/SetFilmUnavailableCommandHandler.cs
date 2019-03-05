﻿using System;
using Common.DataTypes.Services.InventoryService;
using InventoryService.Helpers;
using InventoryService.Interfaces;
using ServiceStack.Messaging;

namespace InventoryService.Handlers
{
    public class SetFilmUnavailableCommandHandler : BaseMessageHandler
    {
        public override void HandleThisMessage(IMessage mqMessage, IMessageQueueClient client)
        {
            var m = mqMessage.Body as SetFilmUnavailableCommand;

            var film = InfraHelper.GetFilm(m.FilmId);

            film.IsAvailable = false;

            InfraHelper.UpdateFilm(film);
        }
    }
}
