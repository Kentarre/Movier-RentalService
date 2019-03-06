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
        public ActionResult StopRental(List<Guid> rentIdList)
        {
            foreach (var item in rentIdList)
                MessageAdapter.SendMessage(new StopRentalCommand
                {
                    RentId = item
                });

            return Ok(new { status = "success" });
        }

        [HttpPost("start/{filmId}")]
        public ActionResult StartRental(Guid filmId)
        {
            var orderId = DbMethods.GetNextOrderId();

            MessageAdapter.SendMessage(new StartRentalCommand
            {
                UserId = new Guid("fce02e91-faba-418b-9e1d-5865aa26456d"),
                FilmId = filmId,
                ActiveFrom = DateTime.Now,
                ActiveTo = DateTime.Now.AddDays(7),
                UseBonuses = true,
                OrderId = orderId
            });

            return Ok(new { status = "success" });
        }
    }
}
