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
            if (!(mqMessage.Body is CalculatePriceCommand message)) return;

            var state = State.GetState(rProxy, message.FilmId, message.UserId);

            if (state.RentAlreadyActive)
                return;

            var user = GetUser(message.UserId);
            var daysCanBeDiscounted = GetDaysDiscounted(user);

            var price = Calculation.GetPrice(message.Type, (message.ActiveTo - message.ActiveFrom).Days,
                daysCanBeDiscounted, message.UseBonuses);

            SetRental(message, price);
            SetBonuses(user, message.Type, message.UseBonuses, daysCanBeDiscounted);
        }

        private class State
        {
            public bool RentAlreadyActive { get; private set;  }

            public static State GetState(IRedisProxy rProxy, Guid filmId, Guid userId)
            {
                var rentals = rProxy.GetAll<Rent>();

                return new State
                {
                    RentAlreadyActive = rentals.Any(x => x.FilmId == filmId && x.UserId == userId && x.IsRented)
                };
            }
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
            var user = rProxy.GetAll<User>().Where(x => x.Id == id).ToList();

            if (user.Count != 1)
                throw new Exception();

            return user.First();
        }

        private void SetBonuses(User user, FilmType type, bool paidWithBonuses, int discountedDays)
        {
            if (paidWithBonuses)
                user.AvailableBonus -= discountedDays * 25;

            user.AvailableBonus += Calculation.CreateNewBonus(type);

            rProxy.Set<User>(user);
        }

        private int GetDaysDiscounted(User user)
        {
            return user.AvailableBonus / 25;
        }
    }
}
