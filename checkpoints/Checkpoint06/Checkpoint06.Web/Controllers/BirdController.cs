using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkpoint06.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Remotion.Linq.Clauses;

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
                var list = context.Observations.OrderBy(o => o.Date).ToList();
                
                StringBuilder sb = new StringBuilder();
                //sb.Append("<table>");
                foreach (var item in list)
                {
                    sb.AppendFormat($"<tr><td>{item.Species}</td><td>{item.Date}</td><td>{item.Place}</td><td>{item.Notes}</td></tr>", item);
                }
                //sb.Append("</table>");
                return Ok(sb.ToString());
               
            }
        }
        [HttpGet("viewSpecies")]
        public IActionResult GetSpecies()
        {
            using (var context = new ObservationContext())
            {
                var list = context.Observations.OrderBy(n => n.Species).Select(s => s.Species).Distinct().ToList();

                StringBuilder sb = new StringBuilder();
                foreach (var item in list)
                {
                    sb.AppendFormat($"<tr><td>{item}</td></tr>");
                }

                return Ok(sb.ToString());


            }
        }


    }


}
