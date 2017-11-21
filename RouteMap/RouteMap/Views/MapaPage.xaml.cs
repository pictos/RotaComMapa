using RouteMap.ViewModels;
using Xamarin.Forms;
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
        }
    }
}