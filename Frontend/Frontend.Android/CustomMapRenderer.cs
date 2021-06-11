using System;
using System.Collections.Generic;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Widget;
using CustomRenderer;
using CustomRenderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Frontend.ViewModels;

[assembly: ExportRenderer(typeof(MapWithColouredPins), typeof(CustomMapRenderer))]
namespace CustomRenderer.Droid
{
    public class CustomMapRenderer : MapRenderer
    {

        public CustomMapRenderer(Context context) : base(context)
        {
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);
            //if (pin.GetType().Equals(typeof(ColouredPin)))
            //{
                marker.SetIcon(BitmapDescriptorFactory.DefaultMarker((pin as ColouredPin).Colour));
            //}
            //else
            //{
            //    marker.SetIcon(BitmapDescriptorFactory.DefaultMarker());
            //}
            return marker;
        }
    }
}
