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
        private List<PinViewModel> Pins { get;  }

        private FlyoutItem FlyOutItem { get; }

        public MapPage MapPage { get; }

        private ShellContent ShellContent { get; }

        private AppShell AppShell { get; set; }

        private string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MapViewModel(AppShell appShell)
        {
            this.Title = "Mapa";

            this.AppShell = appShell;

            this.Pins = new List<PinViewModel>();

            FlyOutItem = new FlyoutItem()
            {
                Title = this.Title,
                Icon = "icon_map.png",
            };

            MapPage = new MapPage(this) { Title = this.Title };

            ShellContent = new ShellContent { Content = MapPage};

            FlyOutItem.Items.Add(ShellContent);

            AddToBar();
        }


        public void AddToBar()
        {
            AppShell.AddFlyoutItemAtIndex(1, FlyOutItem);
        }

        public void RemoveFromBar()
        {
            AppShell.RemoveFlyoutItem(this.FlyOutItem);
        }
        public PinViewModel AddMapPosition(MapPosition mapPosition, PinDisplayType type, bool showCircle)
        {
            foreach(PinViewModel model in Pins)
            {
                if (model.MapPosition == mapPosition)
                {
                    model.ColourType = type;
                    model.ShowCircle = showCircle;
                    return model;
                }
            }

            var pinViewModel = new PinViewModel(this, mapPosition, type, showCircle);
            Pins.Add(pinViewModel);
            return pinViewModel;
        }

        public void AddPinViewModel(PinViewModel addedPin)
        {
            Pins.Add(addedPin);
        }

        public PinViewModel RemoveMapPosition(MapPosition mapPosition)
        {
            var removedPin = Pins.Find(p => p.MapPosition == mapPosition);
            if (removedPin != null)
            {
                removedPin.Remove();
                Pins.Remove(removedPin);
            }
            return removedPin;
        }

        public void RemovePinViewModel(PinViewModel removedPin)
        {
            removedPin.Remove();
            Pins.Remove(removedPin);
        }
    }
}
