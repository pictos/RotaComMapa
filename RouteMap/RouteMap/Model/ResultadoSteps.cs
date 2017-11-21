using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteMap.Model
{
    public class ResultadoSteps
    {
        [JsonProperty("start_location")]
        public Localizacao StartLocation { get; set; }
        [JsonProperty("end_location")]
        public Localizacao EndLocation { get; set; }
        public TextValue Distance { get; set; }
        public TextValue Duration { get; set; }
        public Polyline Polyline { get; set; }
        [JsonProperty("html_instructions")]
        public string HtmlInstructions { get; set; }
    }
}
