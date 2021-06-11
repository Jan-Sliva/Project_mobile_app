using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Frontend.ViewModels
{
    public class MapWithColouredPins : Map
    {
        public MapWithColouredPins(MapSpan mapSpan) : base(mapSpan) { }
    }
}
