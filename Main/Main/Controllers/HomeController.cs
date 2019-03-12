using System;
using System.Linq;
using Common.DataTypes.Dto;
using Common.Redis;
using Main.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private RedisProxy rProxy => Redis.Get();

        [HttpGet("getfilms")]
        public ActionResult GetFilms()
        {
            var films = rProxy.GetAll<Film>().Where(x => x.IsAvailable == true);

            return Ok(films);
        }

        [HttpGet("getrentals/{userId}")]
        public ActionResult GetRentals(Guid userId)
        {
            var allRentals = rProxy.GetAll<Rent>();
            var userRentals = allRentals.Where(x => x.UserId == userId);
            var films = userRentals.Select(x => rProxy.Get<Film>(x.FilmId));

            return Ok(films);
        }
    }
}
