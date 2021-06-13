using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Frontend.ViewModels;
using Frontend.Models;
using Xamarin.Forms.Maps;
using Frontend.Services;
using System.Threading;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private MapViewModel MapViewModel { get; }

        private MapWithColouredPins Map { get; set; }

        private List<PinViewModel> Pins { get; set; }

        public MapPage(MapViewModel mapViewModel)
        {
            this.MapViewModel = mapViewModel;

            InitMap();

            InitializeComponent();
        }

        public async Task InitMap()
        {
            var location = await LocationService.GetLastKnownLocation();
            Map = new MapWithColouredPins(new MapSpan(new Position(location.Latitude, location.Longitude), 0.03, 0.03))
            {
                MapType = MapType.Hybrid,
                IsShowingUser = true
            };
            this.Content =  Map;
        }

        public void AddPinToMap(Pin pin)
        {
            Map.Pins.Add(pin);
        }

        public void RemovePinFromMap(Pin pin)
        {
            Map.Pins.Remove(pin);
        }

        public void AddMapElementToMap(MapElement mapElement)
        {
            Map.MapElements.Add(mapElement);
        }

        public void RemoveMapElementFromMap(MapElement mapElement)
        {
            Map.MapElements.Remove(mapElement);
        }
    }
}
