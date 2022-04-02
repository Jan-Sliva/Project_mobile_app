using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Frontend.Custom
{
    public class MapWithColouredPins : Map
    {
        public MapWithColouredPins(MapSpan mapSpan) : base(mapSpan) { }

        public List<ColouredPin> ColouredPins { get; set; }

        public static readonly BindableProperty ColouredPinsProperty =
       BindableProperty.Create("ColouredPins", typeof(List<ColouredPin>), typeof(MapWithColouredPins), null, BindingMode.TwoWay);
    }
}
