using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPILab.Controllers
{
    [Route("webapi")]
    public class WebAPI2Controller : Controller
    {


        [Route("Frukost"), HttpPost]
        public IActionResult Frukost(string frukost)
        {
            var text = "";
            if (frukost == "ägg")
            {
                text = "Å nej, du norde inte äta ägg.";
            }

            else
            {
                text = $"Ja, {frukost} är gott!";
            }

            return Ok($"{text}");
        }

        [Route("background"), HttpPost]

        public IActionResult Bakgrund(BackgroundColor Bcolor)
        {
            return Content("<html><head><style> body {background-color: " + Bcolor.Color +"; }", "text/html");
        }

        [Route("kvadrera")]
        public IActionResult Kvadrera(int number)
        {
            int kvadrera = number * number;
            return Ok($"{number} * {number} = {kvadrera}");
        }

        [Route("Siffror")]
        public IActionResult Siffror(int number1, int number2)
        {
            var list = new List<int>();
            for (var i = number1; i <= number2; i++)
            {
                list.Add(i);
            }

            return Ok(string.Join(',', list));
        }

        [Route("choklad")]
        public IActionResult Choklad(float antalPersoner)
        {
            var errorMessage = "";
            int choklad = 25;
            if (antalPersoner <= 0)
            {
                errorMessage = "Ogiltigt antal";
                return BadRequest($"{errorMessage}");
            }
            else
            {
            float chokladBitar = choklad / antalPersoner;
            return Ok($"{chokladBitar}");
            }

        }

        [Route("getOrder")]

        public IActionResult Order(string order)
        {


            return Ok("");
        }
    }

    public class BackgroundColor
    {
        public string Color { get; set; }   
    }
}
