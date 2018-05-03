using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace WebAPILab.Controllers
{
    [Route("calculate")]
    public class CalculateController : Controller
    {
        [HttpGet("square")]
        public IActionResult Square(int number)
        {
            int kvadrerat = number * number;

            if (number > 100)
            {
                return BadRequest("Jobbigt!");
            }

            if (number == 0)
            {
                return BadRequest("Skriv ett tal");
            }
            return Ok(kvadrerat.ToString());
        }
    }
}
