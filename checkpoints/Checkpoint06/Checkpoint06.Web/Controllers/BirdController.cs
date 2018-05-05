using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkpoint06.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Checkpoint06.Web
{
    [Route("birds")]
    public class BirdController : Controller
    {

        [HttpPost("addObservations")]
        public void AddObservation(Observation observation)
        {
            using (var context = new ObservationContext())
            {
                context.Observations.Add(observation);
                context.SaveChanges();
            }
        }

        [HttpGet("viewObservations")]
        public IActionResult ViewObservations() //IEnumerable<Observation> observations
        {
            using (var context = new ObservationContext())
            {
                
                var observations = context.Observations.ToList();
                var list = new List<string>();
                
                foreach (var observation in observations)
                {
                    list.Add(observation.Species);
                }

                return Ok(string.Join("<br>", list));
                
                    //return Content($"<p>{observations}</p>", "text/html");
                //return Content()
                //return Ok(josa);
                //return Ok(string.Join(',', observations));

                /*
                return Json(new
                {
                    Message = observations
                });
                */
            }


        }

    }


}
