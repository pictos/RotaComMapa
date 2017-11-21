using Newtonsoft.Json;

namespace RouteMap.Model
{
    public class ResultadoBounds
    {
        [JsonProperty("northeast")]
        public Localizacao NorthEast { get; set; }
   
        [JsonProperty("southwest")]
        public Localizacao SouthWest { get; set; }
    }
}
