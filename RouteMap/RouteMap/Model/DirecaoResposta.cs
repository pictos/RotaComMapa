using Newtonsoft.Json;
using System.Collections.Generic;

namespace RouteMap.Model
{
   public class DirecaoResposta
    {
        [JsonProperty("status")]
        private string StatusText { get; set; }
        
        [JsonProperty("routes")]
        public IEnumerable<ResultadoRota> Rotas { get; set; }
    }
}
