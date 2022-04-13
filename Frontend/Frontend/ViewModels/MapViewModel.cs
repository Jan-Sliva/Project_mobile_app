using Frontend.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Frontend.Models;
using System.Collections.ObjectModel;
using Frontend.Smart;

namespace Frontend.ViewModels
{
    public class MapViewModel : PageViewModel<MapPage>
    {
        public SmartCollection<PinViewModel> PinViewModels { get; set; }

        public MapViewModel(AppShellViewModel appShell) : base(appShell)
        {
            this.Title = "Mapa";

            this.IconFileName = "icon_map.png";

            this.PinViewModels = new SmartCollection<PinViewModel>();
        }

        public void AddPinViewModel(PinViewModel addedPin)
        {
            PinViewModels.Add(addedPin);
        }

        public void RemovePinViewModel(PinViewModel removedPin)
        {
            PinViewModels.Remove(removedPin);
        }
    }
}
