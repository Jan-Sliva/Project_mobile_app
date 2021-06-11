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
        public MapViewModel mapViewModel { get; set; }

        private MapWithColouredPins _map { get; set; }

        private List<PinViewModel> _pins { get; set; }

        public MapPage(MapViewModel mapViewModel)
        {
            this.mapViewModel = mapViewModel;

            InitMap();

            InitializeComponent();
        }

        public async Task InitMap()
        {
            var location = await LocationService.GetLastKnownLocation();
            _map = new MapWithColouredPins(new MapSpan(new Position(location.Latitude, location.Longitude), 0.03, 0.03))
            {
                MapType = MapType.Hybrid,
                IsShowingUser = true
            };
            this.Content =  _map;
        }

        public void AddPinToMap(Pin pin)
        {
            _map.Pins.Add(pin);
        }

        public void RemovePinFromMap(Pin pin)
        {
            _map.Pins.Remove(pin);
        }

        public void AddMapElementToMap(MapElement mapElement)
        {
            _map.MapElements.Add(mapElement);
        }

        public void RemoveMapElementFromMap(MapElement mapElement)
        {
            _map.MapElements.Remove(mapElement);
        }
    }
}
