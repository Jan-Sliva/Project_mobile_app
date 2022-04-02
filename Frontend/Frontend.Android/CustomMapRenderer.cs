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
using Frontend.Custom;

[assembly: ExportRenderer(typeof(MapWithColouredPins), typeof(CustomMapRenderer))]
namespace CustomRenderer.Droid
{
    public class CustomMapRenderer : MapRenderer
    {
        private List<Marker> markers;
        private List<NativeCircle> nativeCircles;

        //public CustomMapRenderer(context context) : base(context)
        //{
        //}

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (this.Element == null || this.Control == null)
                return;
            if (e.PropertyName == ColouredMap.ColouredPinsProperty.PropertName)
            {
                if (markers != null)
                {
                    if (markers.Count > 0)
                        markers.ForEach(x => x.Remove());
                }
                if (nativeCircles != null)
                {
                    if(nativeCircles.Count > 0)
                        nativeCircles.ForEach(x => x.Remove());
                }
                SetColouredPins();
            }
        }

        private void SetColouredPins()
        {
            markers = new List<Marker>();
            nativeCircles = new List<NativeCircle>();

            if (((MapWithColouredPins)this.Element).ColouredPins == null)
                return;
            foreach (var colouredPin in ((MapWithColouredPins)this.Element).ColouredPins)
            {
                var marker = new MarkerOptions();
                marker.SetPosition(new LatLng(colouredPin.Position.Latitude, colouredPin.Position.Longitude));
                marker.SetTitle(colouredPin.Label);
                marker.SetSnippet(colouredPin.Address);
                marker.SetIcon(BitmapDescriptorFactory.DefaultMarker(colouredPin.Colour));

                Marker m = NativeMap.AddMarker(marker);
                markers.Add(m);


                var nativeCircle = new CircleOptions();
                nativeCircle.InvokeCenter(new LatLng(colouredPin.Position.Latitude, colouredPin.Position.Longitude));
                nativeCircle.InvokeRadius(float.Parse(colouredPin.Radius));
                nativeCircle.InvokeStrokeColor(nativeCircle.StrokeColor.ToAndroid());
                nativeCircle.InvokeFillColor(nativeCircle.FillColor.ToAndroid());
                nativeCircle.InvokeStrokeWidth(nativeCircle.StrokeWidth * this.ScaledDensity);

                nativeCircle nc = NativeMap.AddCircle(nativeCircle);
                nativeCircles.Add(nc);
            }
        }
    }
}
