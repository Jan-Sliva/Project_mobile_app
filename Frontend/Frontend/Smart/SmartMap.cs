using Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Frontend.Smart
{
    public class SmartMap : Map
    {
        public SmartMap() : base() { }

        public SmartMap(MapSpan span) : base(span) 
        {       
        }

        public ObservableCollection<PinViewModel> SmartPins
        {
            get { return (ObservableCollection<PinViewModel>)GetValue(SmartPinsProperty); }
            set
            {
                SetValue(SmartPinsProperty, value);
            }
        }

        public static readonly BindableProperty SmartPinsProperty =
        BindableProperty.Create("SmartPins", typeof(ObservableCollection<PinViewModel>), typeof(SmartMap), null, BindingMode.TwoWay);
    }
}
