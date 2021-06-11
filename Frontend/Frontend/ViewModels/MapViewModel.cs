using Frontend.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Frontend.Models;

namespace Frontend.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        private List<PinViewModel> _pins { get; set; }

        private FlyoutItem _map { get; set; }

        public MapPage mapPage { get; set; }

        private ShellContent _shellContent { get; set; }

        public MapViewModel(AppShell appShell)
        {
            this.Title = "Mapa";

            this._pins = new List<PinViewModel>();

            _map = new FlyoutItem()
            {
                Title = "Mapa",
                Icon = "icon_map.png",
            };

            mapPage = new MapPage(this) { Title = this.Title };

            _shellContent = new ShellContent { Content = mapPage};

            _map.Items.Add(_shellContent);

            appShell.AddFlyoutItemAtIndex(1, _map);
        }

        public PinViewModel AddMapPosition(MapPosition mapPosition, PinDisplayType type, bool showCircle)
        {
            foreach(PinViewModel model in _pins)
            {
                if (model.MapPosition == mapPosition)
                {
                    model.ColourType = type;
                    model.ShowCircle = showCircle;
                    return model;
                }
            }

            var pinViewModel = new PinViewModel(this, mapPosition, type, showCircle);
            _pins.Add(pinViewModel);
            return pinViewModel;
        }

        public PinViewModel RemoveMapPosition(MapPosition mapPosition)
        {
            var removedPin = _pins.Find(p => p.MapPosition == mapPosition);
            removedPin.Remove();
            _pins.Remove(removedPin);
            return removedPin;
        }

        public void RemovePinViewModel(PinViewModel removedPin)
        {
            removedPin.Remove();
            _pins.Remove(removedPin);
        }
    }
}
