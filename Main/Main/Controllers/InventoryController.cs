using System;
using Common.DataTypes.Dto;
using Common.DataTypes.Services.InventoryService;
using Common.Redis;
using Main.RedisMQ;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private RedisProxy rProxy => Redis.Get();

        [HttpPost("add")]
        public ActionResult AddNew([FromForm] Film film)
        {
            MessageAdapter.SendMessage(new AddFilmCommand
            {
                Film = film
            });

            return Ok(new { status = "success" });
        }

        [HttpPost("edit")]
        public ActionResult Edit([FromForm] Film film)
        {
            MessageAdapter.SendMessage(new UpdateFilmCommand
            {
                Film = film
            });

            return Ok(new { status = "success" });
        }

        [HttpPost("delete")]
        public ActionResult Delete([FromForm] Guid filmId)
        {
            MessageAdapter.SendMessage(new RemoveFilmCommand
            {
                FilmId = filmId
            });

            return Ok(new { status = "success" });
        }
    }
}
