using System;
using Common.DataTypes.Services.InventoryService;
using Common.DataTypes.Services.RentalService;
using RentalService.Helpers;
using RentalService.Interfaces;
using ServiceStack.Messaging;

namespace RentalService.Handlers
{
    public class StopRentalCommandHandler : BaseMessageHandler
    {
        public override void HandleThisMessage(IMessage mqMessage, IMessageQueueClient client)
        {
            var m = mqMessage.Body as StopRentalCommand;

            var rent = InfraHelper.GetRent(m.RentId);

            rent.ReturnedDate = DateTime.Now;

            InfraHelper.UpdateRent(rent);

            client.Publish(new SetFilmAvailableCommand
            {
                FilmId = rent.FilmId
            });
        }
    }
}
