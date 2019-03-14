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
        public ActionResult StartRental([FromBody] List<NewOrderDto> rentedFilms)
        {
            if (rentedFilms.Count == 0)
                return Ok(new { status = "error", message = "No films selected" });

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
    }
}
