﻿using Common.DataTypes.Dto;
using Common.Redis;
using Main.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
            var films = rProxy.GetAll<Film>().Where(x => x.IsAvailable);

            return Ok(films);
        }

        [HttpGet("getrentals/{userId}")]
        public ActionResult GetRentals(Guid userId)
        {
            var allRentals = rProxy.GetAll<Rent>();
            var userRentals = allRentals.Where(x => x.UserId == userId).ToList().OrderByDescending(x=> x.ActiveFrom);

            var rentDto = userRentals.Select(x => new UserRentalDto
            {
                Id = x.Id,
                ActiveFrom = x.ActiveFrom,
                ActiveTo = x.ActiveTo,
                IsRented = x.IsRented,
                IsDue = x.IsDue,
                Price = x.Price,
                ReturnedDate = x.ReturnedDate,
                Title = rProxy.Get<Film>(x.FilmId).Title,
                Description = rProxy.Get<Film>(x.FilmId).Description,
                OrderId = x.OrderId
            }).ToList();

            return Ok(rentDto);
        }

        [HttpGet("getuser/{userId}")]
        public ActionResult GetUser(Guid userId)
        {
            var user = rProxy.GetAll<User>().Where(x => x.Id == userId);

            return Ok(user);
        }
    }
}
