using Common.DataTypes.Services.RentalService;
using Main.Dto;
using Main.Helpers;
using Main.RedisMQ;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
                    ActiveFrom = item.RentFrom.ToLocalTime(),
                    ActiveTo = item.RentTo.AddDays(1).ToLocalTime(),
                    UseBonuses = item.UseBonuses,
                    OrderId = orderId
                });

            return Ok(new { status = "success" });
        }

        [HttpPost("stop/{rentId}")]
        public ActionResult StopRental(Guid rentId)
        {
            MessageAdapter.SendMessage(new StopRentalCommand
            {
                RentId = rentId
            });

            return Ok(new { status = "success" });
        }
    }
}
