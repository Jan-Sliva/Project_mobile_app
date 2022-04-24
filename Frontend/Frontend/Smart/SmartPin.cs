using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
using Xamarin.Forms;

namespace Frontend.Smart
{
    public class SmartPin : Cell
    {
        public static readonly BindableProperty PositionProperty = BindableProperty.Create("Position", typeof(Position), typeof(SmartPin), default(Position));

        public static readonly BindableProperty LabelProperty = BindableProperty.Create("Label", typeof(string), typeof(SmartPin), default(string));

        public static readonly BindableProperty ColourProperty = BindableProperty.Create("Colour", typeof(float), typeof(SmartPin), default(float));

        public static readonly BindableProperty RadiusProperty = BindableProperty.Create("Radius", typeof(int), typeof(SmartPin), default(int));

        public static readonly BindableProperty FillColourProperty = BindableProperty.Create("FillColour", typeof(Color), typeof(SmartPin), default(Color));

        public static readonly BindableProperty StrokeColourProperty = BindableProperty.Create("StrokeColour", typeof(Color), typeof(SmartPin), default(Color));

        public static readonly BindableProperty StrokeWidthProperty = BindableProperty.Create("StrokeWidth", typeof(float), typeof(SmartPin), default(float));

        public static readonly BindableProperty ShowCircleProperty = BindableProperty.Create("ShowCircle", typeof(bool), typeof(SmartPin), default(bool));

        public Position Position
        {
            get { return (Position)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public float Colour  // hue
        {
            get { return (float)GetValue(ColourProperty); }
            set { SetValue(ColourProperty, value); }
        }

        public int Radius
        {
            get { return (int)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public Color FillColour
        {
            get { return (Color)GetValue(FillColourProperty); }
            set { SetValue(FillColourProperty, value); }
        }

        public Color StrokeColour
        {
            get { return (Color)GetValue(StrokeColourProperty); }
            set { SetValue(StrokeColourProperty, value); }
        }

        public float StrokeWidth
        {
            get { return (float)GetValue(StrokeWidthProperty); }
            set { SetValue(StrokeWidthProperty, value); }
        }


        public bool ShowCircle
        {
            get { return (bool)GetValue(ShowCircleProperty); }
            set { SetValue(ShowCircleProperty, value); }
        }
    }
}
