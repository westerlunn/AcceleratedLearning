using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace WebAPILab.Controllers
{
    [Route("Planet")]
    public class AddPlanet : Controller
    {
        [Route("AddPlanet"), HttpPost]
        public IActionResult Planet(string planet, int size)   
        {
            return Ok($"Du har skapat planeten {planet} med storlek {size}");
        }

        //[Route("GetPlanet"), HttpGet]
        //public IActionResult GetPlanet(string planet, int size)
        //{

        //}
    }
}
