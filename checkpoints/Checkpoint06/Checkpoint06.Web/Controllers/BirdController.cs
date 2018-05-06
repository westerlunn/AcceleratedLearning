using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                var list = context.Observations.ToList();
                StringBuilder sb = new StringBuilder();
                sb.Append("<table>");
                foreach (var item in list)
                {
                    sb.AppendFormat($"<tr><td>{item.Species}</td><td>{item.Date}</td><td>{item.Place}</td><td>{item.Notes}</td></tr>", item);
                }
                sb.Append("</table>");
                return Ok(sb.ToString());
                /*
                var observations = context.Observations.ToList();
                var list = new List<string>();

                foreach (var observation in observations)
                {
                    list.Add(observation.Species);
                }

                return Ok(list);
                */
                /*
                var observations = context.Observations.ToList();
                var list = new List<string>();
                
                foreach (var observation in observations)
                {
                    list.Add(observation.Species);
                }

                return Ok(string.Join("<br>", list));
                */
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
