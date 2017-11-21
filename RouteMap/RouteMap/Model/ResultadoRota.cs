using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteMap.Model
{
   public class ResultadoRota
    {
        public string Summary { get; set; }

        [JsonProperty("overview_polyline")]
        public Polyline Polyline { get; set; }
    
        public ResultadoBounds Bounds { get; set; }
       
        public IEnumerable<ResultadoLeg> Legs { get; set; }
    }
}
