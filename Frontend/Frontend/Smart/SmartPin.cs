using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
using Xamarin.Forms;

namespace Frontend.Smart
{
    public class SmartPin : Cell
    {
        public Position Position { get; set; }

        public string Label { get; set; }

        public float Colour { get; set; } // hue

        public int Radius { get; set; }

        public Color FillColour { get; set; }

        public Color StrokeColour { get; set; }

        public float StrokeWidth { get; set; }

        public bool ShowCircle { get; set; }
    }
}
