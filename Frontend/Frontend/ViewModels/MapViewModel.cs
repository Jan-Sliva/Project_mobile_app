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
    public class MapViewModel<T> : PageViewModel<T> where T : BasePage
    {
        public SmartCollection<PinViewModel<T>> PinViewModels { get; set; }

        public MapViewModel(AppShellViewModel appShell) : base(appShell)
        {
            this.Title = "Mapa";

            this.IconFileName = "icon_map.png";

            this.PinViewModels = new SmartCollection<PinViewModel<T>>();
        }

        public void AddPinViewModel(PinViewModel<T> addedPin)
        {
            PinViewModels.Add(addedPin);
        }

        public void RemovePinViewModel(PinViewModel<T> removedPin)
        {
            PinViewModels.Remove(removedPin);
        }
    }
}
