using RouteMap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace RouteMap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapaPage : ContentPage
    {
        public MapaPage()
        {
            InitializeComponent();
            BindingContext = new MapaViewModel();
            MapaViewModel.myMap = MyMap;
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(-19.6303, -43.8983), Distance.FromKilometers(1.0)));
            //MyMap.CoordenadasRota.Add(new Position(-19.6303, -43.8983));
            //MyMap.CoordenadasRota.Add(new Position(-19.6303, -44.8983));
        }
    }
}