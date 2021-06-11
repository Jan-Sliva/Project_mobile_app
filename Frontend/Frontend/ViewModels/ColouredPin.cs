using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Frontend.ViewModels
{
    public class ColouredPin : Pin
    {
        public ColouredPin() : base() { Colour = 0; }
        
        public float Colour { get; set; }
    }
}
