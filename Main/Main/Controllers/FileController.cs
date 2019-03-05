using System;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet("create")]
        public ActionResult CreateInvoice(Guid userId)
        {
            return Ok(new {status = "success"});
        }
    }
}
