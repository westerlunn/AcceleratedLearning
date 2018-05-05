using System;
using System.Collections.Generic;

namespace Checkpoint06.Web
{
    public class Observation    
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Notes { get; set; }   
        public IEnumerable<Observation> Observations { get; set; }  
    }
}