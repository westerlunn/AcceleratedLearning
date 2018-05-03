using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPILab.Controllers
{
    [Route("ex1")]
    public class Ex1Controller : Controller
    {
        [Route("Hello")]
        public string Hello()
        {
            return "Hello";
        }

        [Route("HelloWorld")]
        public IActionResult HelloWorld()
        {
            return Ok("Hello world!");
        }

       
    }
}
