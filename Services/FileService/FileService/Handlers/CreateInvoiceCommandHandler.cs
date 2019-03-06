using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.DataTypes.Dto;
using Common.DataTypes.Services.FileService;
using Common.Redis;
using FileService.Helpers;
using ServiceStack.Messaging;

namespace FileService.Handlers
{
    public class CreateInvoiceCommandHandler : BaseMessageHandler
    {
        public override void HandleThisMessage(IMessage mqMessage, IMessageQueueClient client)
        {
            if (!(mqMessage.Body is CreateInvoiceCommand m)) return;

            var state = State.GetState(rProxy, m.OrderId);

            if (!state.HasRentals || state.HasInvoiceAlready)
                return;

            var userId = state.UserRentals.First().UserId;

            var user = rProxy.Get<User>(userId);
            var invoice = FileHelper.CreateInvoice(user, state.UserRentals);

            rProxy.Set<Invoice>(new Invoice
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                OrderId = m.OrderId,
                FileBytes = invoice,
                UserId = userId
            });
        }

        private class State
        {
            public bool HasRentals { get; set; }
            public bool HasInvoiceAlready { get; set; }
            public List<Rent> UserRentals { get; set; }

            public static State GetState(RedisProxy rProxy, int orderId)
            {
                var rentals = rProxy.GetAll<Rent>();
                var invoices = rProxy.GetAll<Invoice>();

                return new State 
                {
                    UserRentals = rentals.Where(x => x.OrderId == orderId).ToList(),
                    HasRentals = rentals.Where(x => x.OrderId == orderId).Any(),
                    HasInvoiceAlready = invoices.Where(x => x.OrderId == orderId).Any()
                };
            }
        }
    }
}
