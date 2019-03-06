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
        //[HttpPost("start")]
        //public ActionResult StartRental([FromForm] List<NewOrderDto> rentedFilms)
        //{
        //    var orderId = DbMethods.GetNextOrderId();

        //    foreach (var item in rentedFilms)
        //        MessageAdapter.SendMessage(new StartRentalCommand
        //        {
        //            UserId = item.UserId,
        //            FilmId = item.FilmId,
        //            ActiveFrom = item.RentFrom,
        //            ActiveTo = item.RentTo,
        //            UseBonuses = item.UseBonuses,
        //            OrderId = orderId
        //        });

        //    return Ok(new { status = "success" });
        //}

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

        [HttpPost("start")]
        public ActionResult StartRental()
        {
            var orderId = DbMethods.GetNextOrderId();

            MessageAdapter.SendMessage(new StartRentalCommand
            {
                UserId = new Guid("75f569d6-6ca9-44a4-9adc-b04f66e1e332"),
                FilmId = new Guid("1e8d1152-7a93-4f1b-827b-d2585fdfb880"),
                ActiveFrom = DateTime.Now,
                ActiveTo = DateTime.Now.AddDays(7),
                UseBonuses = true,
                OrderId = orderId
            });

            return Ok(new { status = "success" });
        }
    }
}
