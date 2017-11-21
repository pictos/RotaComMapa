using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace RouteMap.Model
{
    public class Polyline
    {
        public string Points { get; set; }
     
        [JsonIgnore]
        public IEnumerable<Position> Positions
        {
            get
            {
                return GooglePoints.Decode(this.Points);
            }
        }
    }
}
