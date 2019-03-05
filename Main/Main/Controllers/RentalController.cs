using System;
using System.Collections.Generic;
using System.Linq;
using Common.DataTypes.Dto;
using Common.DataTypes.Services.RentalService;
using Common.Redis;
using Main.Dto;
using Main.Helpers;
using Main.RedisMQ;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private RedisProxy rProxy => Redis.Get();

        [HttpPost("start")]
        public ActionResult StartRental([FromForm] List<NewOrderDto> rentedFilms)
        {
            var orderId = DbMethods.GetNextOrderId();

            foreach (var item in rentedFilms)
                MessageAdapter.SendMessage(new StartRentalCommand
                {
                    UserId = item.UserId,
                    FilmId = item.FilmId,
                    ActiveFrom = item.RentFrom,
                    ActiveTo = item.RentTo,
                    UseBonuses = item.UseBonuses,
                    OrderId = orderId
                });

            return Ok(new { status = "success" });
        }

        [HttpPost("stop")]
        public ActionResult StopRental()
        {
            MessageAdapter.SendMessage(new StartRentalCommand
            {
                FilmId = new Guid("f790aa11-5032-44a2-8868-aab9a84ab97c"),
                OrderId = DbMethods.GetNextOrderId(),
                UserId = new Guid(),
                UseBonuses = true,
                ActiveTo = DateTime.Now.AddDays(7),
                ActiveFrom = DateTime.Now
            });

            return Ok(new { status = "success" });
        }
    }
}
