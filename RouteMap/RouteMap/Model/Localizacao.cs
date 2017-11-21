using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteMap.Model
{
   public class Localizacao
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("Lng")]
        public double Longitude { get; set; }
    }
}
