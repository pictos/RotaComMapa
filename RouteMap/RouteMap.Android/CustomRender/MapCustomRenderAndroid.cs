using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Platform.Android;
using RouteMap.CustomRender;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Xamarin.Forms;
using RouteMap.Droid.CustomRender;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(MapCustomRender),typeof(MapCustomRenderAndroid))]
namespace RouteMap.Droid.CustomRender
{
    public class MapCustomRenderAndroid : MapRenderer, IOnMapReadyCallback
    {
        #region Funciona
        GoogleMap map;
        Polyline polyline;
 

        public MapCustomRenderAndroid(Context context) : base(context)
        {
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            map.MapType = 1;
            UpdatePolyline();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null) return;

            if (e.NewElement != null)
                Control.GetMapAsync(this);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (this.Element == null || this.Control == null) return;

            if (e.PropertyName == MapCustomRender.CoordenadasRotaProperty.PropertyName)
            {
                UpdatePolyline();
            }
        }

        private void UpdatePolyline()
        {
            if (polyline != null)
            {
                polyline.Remove();
                polyline.Dispose();
            }
            var polilyneOptions = new PolylineOptions();
            polilyneOptions.InvokeColor(Android.Graphics.Color.Red);
            var coordenadas = ((MapCustomRender)this.Element).CoordenadasRota;
            foreach (var position in coordenadas)
            {
                polilyneOptions.Add(new LatLng(position.Latitude, position.Longitude));
            }
          
            polyline = map.AddPolyline(polilyneOptions);
        }

        #endregion
    }
}
