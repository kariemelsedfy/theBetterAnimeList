using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class userSpecificCallsController : ControllerBase
    {
        [HttpGet("getUserAnimeList")]
        public string getUserAnimeList([FromQuery] string token) {
            Console.WriteLine(token);
        }
    }
}