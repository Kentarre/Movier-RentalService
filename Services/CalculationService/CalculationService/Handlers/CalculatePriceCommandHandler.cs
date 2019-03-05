using System;
using System.Linq;
using CalculationService.Helpers;
using CalculationService.Interfaces;
using Common.DataTypes.Dto;
using Common.DataTypes.Enums;
using Common.DataTypes.Services.CalculationService;
using Common.Redis;
using ServiceStack.Messaging;

namespace CalculationService.Handlers
{
    public class CalculatePriceCommandHandler : BaseMessageHandler
    {
        public override void HandleThisMessage(IMessage mqMessage, IMessageQueueClient client)
        {
            var message = mqMessage.Body as CalculatePriceCommand;

            var rentals = rProxy.GetAll<Rent>();
            var activeRental = rentals.Where(x => x.FilmId == message.FilmId && x.UserId == message.UserId && x.IsRented);

            if (activeRental.Any())
                return;

            var price = Calculation.GetPrice(message.Type, (message.ActiveTo - message.ActiveFrom).Days, message.BonusPoints, message.UseBonuses);

            SetRental(message, price);
            SetBonuses(message.UserId, message.Type);
        }

        private void SetRental(CalculatePriceCommand message, decimal price)
        {
            var rental = new Rent
            {
                UserId = message.UserId,
                FilmId = message.FilmId,
                Id = Guid.NewGuid(),
                Price = price,
                ActiveTo = message.ActiveTo,
                ActiveFrom = message.ActiveFrom,
                OrderId = message.OrderId
            };

            rProxy.Set(rental);
        }

        private User GetUser(Guid id)
        {
            var user = rProxy.GetAll<User>().Where(x => x.Id == id);

            if (user.Count() != 1)
                throw new Exception();

            return user.First();
        }

        private void SetBonuses(Guid userId, FilmType type)
        {
            var user = GetUser(userId);
            user.AvailableBonus += Calculation.CreateNewBonus(type);

            rProxy.Set<User>(user);
        }
    }
}
