using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Color;

namespace Frontend.Custom
{
    public class ColouredPin : Pin
    {
        public ColouredPin() : base() { Colour = 0; }

        public float Colour { get; set; } // hue

        public int Radius { get; set; }

        public Color FillColour { get; set; }

        public Color StrokeColour { get; set; }

        public float StrokeWidth { get; set; }
    }
}
