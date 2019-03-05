using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.DataTypes.Dto;
using Common.DataTypes.Services.RentalService;
using Common.Redis;
using Main.RedisMQ;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private RedisProxy rProxy => Redis.Get();

        [HttpGet("test")]
        public ActionResult Test()
        {
            var user = rProxy.Get<User>(new Guid("87bdcabe-d639-4ec3-ac94-94f35656fa31"));

            return Ok(user);
        }
    }
}
