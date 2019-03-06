using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.DataTypes.Dto;
using Common.DataTypes.Services.FileService;
using FileService.Helpers;
using ServiceStack.Messaging;

namespace FileService.Handlers
{
    public class CreateInvoiceCommandHandler : BaseMessageHandler
    {
        public override void HandleThisMessage(IMessage mqMessage, IMessageQueueClient client)
        {
            if (!(mqMessage.Body is CreateInvoiceCommand m)) return;

            var rentals = rProxy.GetAll<Rent>();
            var userRentals = rentals.Where(x => x.OrderId == m.OrderId).ToList();

            if (!userRentals.Any())
                return;

            var user = rProxy.Get<User>(userRentals.First().UserId);
            var invoice = FileHelper.CreateInvoice(user, userRentals);

            rProxy.Set<Invoice>(new Invoice
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                OrderId = m.OrderId,
                FileBytes = invoice,
                UserId = userRentals.First().UserId
            });
        }
    }
}
