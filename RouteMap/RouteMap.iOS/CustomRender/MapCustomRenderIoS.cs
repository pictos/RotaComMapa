using MapKit;
using RouteMap.CustomRender;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps.iOS;
using System.ComponentModel;
using UIKit;
using CoreLocation;
using Xamarin.Forms;
using RouteMap.iOS.CustomRender;

[assembly: ExportRenderer(typeof(MapCustomRender),typeof(MapCustomRenderIoS))]
namespace RouteMap.iOS.CustomRender
{
    public class MapCustomRenderIoS : MapRenderer
    {
        MapCustomRender _map;
        MKPolylineRenderer polylineRenderer;

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if ((this.Element == null) || (this.Control == null))
                return; 

            if(e.PropertyName == MapCustomRender.CoordenadasRotaProperty.PropertyName)
            {
                _map = (MapCustomRender)sender;
                UpdatePolyline();
            }
        }


        [Foundation.Export("mapView:rendererForOverlay:")]
        MKOverlayRenderer GetOverlayRenderer(MKMapView mapView, IMKOverlay overlay)
        {
            if (polylineRenderer == null)
            {
                var o = ObjCRuntime.Runtime.GetNSObject(overlay.Handle) as MKPolyline;

                polylineRenderer = new MKPolylineRenderer(o)
                {
                    FillColor = UIColor.Blue,
                    StrokeColor = UIColor.Red,
                    LineWidth = 3,
                    Alpha = 0.4f
                };
            }
            return polylineRenderer;
        }

        private void UpdatePolyline()
        {
            var MapaIoS = Control as MKMapView;
            MapaIoS.OverlayRenderer = GetOverlayRenderer;

            CLLocationCoordinate2D[] coordenada = new CLLocationCoordinate2D[_map.CoordenadasRota.Count];

            int index = 0;
            foreach (var posicao in _map.CoordenadasRota)
            {
                coordenada[index] = new CLLocationCoordinate2D(posicao.Latitude, posicao.Longitude);
                index++;
            }

            var polilyne = MKPolyline.FromCoordinates(coordenada);
            MapaIoS.AddOverlay(polilyne);
        }
    }
}
