using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Frontend.Smart
{
    public class SmartMap : Map
    {
        public SmartMap() : base() { }

        public List<SmartPin> SmartPins
        {
            get { return (List<SmartPin>)GetValue(SmartPinsProperty); }
            set
            {
                SetValue(SmartPinsProperty, value);
            }
        }

        public static readonly BindableProperty SmartPinsProperty =
        BindableProperty.Create("SmartPins", typeof(List<SmartPin>), typeof(SmartMap), null, BindingMode.TwoWay);
    }
}
