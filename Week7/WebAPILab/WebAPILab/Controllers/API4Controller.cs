using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace WebAPILab.Controllers
{
    [Route("webapi4")]
    public class API4Controller : Controller
    {
        [Route("addPerson")]
        public IActionResult AddPerson(SimplePerson person)
        {

            return Ok($"{person.Name} som är {person.Age} år lades till");
        }

        [Route("addPersonValidate")]
        public IActionResult AddPersonValidate(string name, int age)
        {



            return Ok($"{name}");
        }

    }
}

namespace WebAPILab
{
    class baj
    {

    }
}
