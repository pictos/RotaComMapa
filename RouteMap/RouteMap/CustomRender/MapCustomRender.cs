using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace RouteMap.CustomRender
{
    public class MapCustomRender : Map
    {

        public static readonly BindableProperty CoordenadasRotaProperty =
            BindableProperty.Create(nameof(CoordenadasRota),
                typeof(List<Position>),
                typeof(MapCustomRender),
                new List<Position>(), BindingMode.TwoWay);

        public List<Position> CoordenadasRota
        {
            get { return (List<Position>)GetValue(CoordenadasRotaProperty); }
            set { SetValue(CoordenadasRotaProperty, value); }
        }

        public MapCustomRender() => CoordenadasRota = new List<Position>();
    }
}
