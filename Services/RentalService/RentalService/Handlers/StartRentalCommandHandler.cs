using System;
using Common.DataTypes.Dto;
using Common.DataTypes.Enums;
using Common.DataTypes.Services.CalculationService;
using Common.DataTypes.Services.InventoryService;
using Common.DataTypes.Services.RentalService;
using Common.Redis;
using RentalService.Helpers;
using RentalService.Interfaces;
using ServiceStack.Messaging;

namespace RentalService.Handlers
{
    public class StartRentalCommandHandler : BaseMessageHandler
    {
        public override void HandleThisMessage(IMessage mqMessage, IMessageQueueClient client)
        {
            if (!(mqMessage.Body is StartRentalCommand m)) return;

            var film = InfraHelper.GetFilm(m.FilmId);

            if (!film.IsAvailable)
                return;

            client.Publish(new CalculatePriceCommand
            {
                UserId = m.UserId,
                FilmId = m.FilmId,
                Type = film.Type,
                UseBonuses = m.UseBonuses,
                ActiveTo = m.ActiveTo,
                ActiveFrom = m.ActiveFrom,
                OrderId = m.OrderId
            });

            client.Publish(new SetFilmUnavailableCommand
            {
                FilmId = m.FilmId
            });
        }
    }
}
