using Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Frontend.Smart
{
    public class SmartMap : Map
    {

        public SmartMap(MapSpan span, SmartCollection<PinViewModel> pins) : base(span) 
        {       
            pins.CollectionChanged += OnPinsChanged;
            PinViewModels = pins;
        }

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



        public IList<PinViewModel> PinViewModels { get; set; }

        private void OnPinsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Update();
        }


        private void Update()
        {
            var smartPins = new List<SmartPin>();
            foreach (var pin in this.PinViewModels)
            {
                smartPins.Add(new SmartPin { Colour = pin.Colour, FillColour = pin.FillColour, Label = pin.Label, Position = pin.Position,
                                             Radius = (int)pin.Radius, ShowCircle = pin.ShowCircle, StrokeColour = pin.StrokeColour, StrokeWidth = pin.StrokeWidth  }); 
            }

            SmartPins = smartPins;
        }


    }
}
