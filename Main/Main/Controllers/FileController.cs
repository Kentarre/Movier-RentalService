using System;
using System.Linq;
using Common.DataTypes.Dto;
using Common.DataTypes.Services.FileService;
using Common.Redis;
using Main.RedisMQ;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private RedisProxy rProxy => Redis.Get();

        [HttpPost("create/{orderId}")]
        public ActionResult CreateInvoice(int orderId)
        {
            MessageAdapter.SendMessage(new CreateInvoiceCommand
            {
                OrderId = orderId
            });

            return Ok(new {status = "success"});
        }

        [HttpGet("isready/{orderId}")]
        public ActionResult IsInvoiceReady(int orderId)
        {
            var userInvoices = rProxy.GetAll<Invoice>();
            var invoice = userInvoices.Where(x => x.OrderId == orderId).ToList();

            if (invoice.Count != 1)
                return Ok(new {status = "not ready"});

            return Ok(new
            {
                status = "success",
                url = Url.Action("download", "file", new {invoiceId = invoice.First().Id})
            });
        }

        [HttpGet("download/{invoiceId}")]
        public FileResult Download(Guid invoiceId)
        {
            var invoice = rProxy.Get<Invoice>(invoiceId);

            var result = new FileContentResult(invoice.FileBytes, "application/pdf")
            {
                FileDownloadName = $"{invoice.OrderId}.pdf"
            };

            return result;
        }
    }
}
