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
        public SmartCollection<PinViewModel> PinViewModels { get; set; } = new SmartCollection<PinViewModel>();

        public MapViewModel(AppShellViewModel appShell) : base(appShell, "Mapa", "icon_map.png")
        {
            ShowAtPos(1);
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
