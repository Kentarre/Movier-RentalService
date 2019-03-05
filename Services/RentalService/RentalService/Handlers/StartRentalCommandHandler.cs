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
            var m = mqMessage.Body as StartRentalCommand;

            var film = InfraHelper.GetFilm(m.FilmId);

            if (!film.IsAvailable)
                return;

            var user = InfraHelper.GetUser(m.UserId);

            client.Publish(new CalculatePriceCommand
            {
                UserId = m.UserId,
                FilmId = m.FilmId,
                Type = film.Type,
                UseBonuses = m.UseBonuses,
                ActiveTo = m.ActiveTo,
                ActiveFrom = m.ActiveFrom,
                BonusPoints = user.AvailableBonus,
                OrderId = m.OrderId
            });

            client.Publish(new SetFilmUnavailableCommand
            {
                FilmId = m.FilmId
            });
        }
    }
}
