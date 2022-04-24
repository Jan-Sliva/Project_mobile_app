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
using NativeCircle = Android.Gms.Maps.Model.Circle;
using Frontend.ViewModels;
using Frontend.Smart;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SmartMap), typeof(SmartMapRenderer))]
namespace CustomRenderer.Droid
{
    public class SmartMapRenderer : MapRenderer
    {
        private List<Marker> markers;
        private List<NativeCircle> nativeCircles;

        public SmartMapRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (this.Element == null)
                return;
            if (e.PropertyName == SmartMap.SmartPinsProperty.PropertyName)
            {
                if (markers != null)
                {
                    if (markers.Count > 0)
                        markers.ForEach(x => x.Remove());
                }
                if (nativeCircles != null)
                {
                    if (nativeCircles.Count > 0)
                        nativeCircles.ForEach(x => x.Remove());
                }
                SetColouredPins();
            }
        }

        private void SetColouredPins()
        {
            markers = new List<Marker>();
            nativeCircles = new List<NativeCircle>();

            if (((SmartMap)this.Element).SmartPins == null)
                return;
            foreach (var smartPin in ((SmartMap)this.Element).SmartPins)
            {
                var marker = new MarkerOptions();
                marker.SetPosition(new LatLng(smartPin.Position.Latitude, smartPin.Position.Longitude));
                marker.SetTitle(smartPin.Label);
                marker.SetIcon(BitmapDescriptorFactory.DefaultMarker(smartPin.Colour));

                Marker m = NativeMap.AddMarker(marker);
                markers.Add(m);

                if (smartPin.ShowCircle && smartPin.Radius > 0)
                {
                    var nativeCircle = new CircleOptions();
                    nativeCircle.InvokeCenter(new LatLng(smartPin.Position.Latitude, smartPin.Position.Longitude));
                    nativeCircle.InvokeRadius((double)smartPin.Radius);
                    nativeCircle.InvokeStrokeColor(smartPin.StrokeColour.ToAndroid());
                    nativeCircle.InvokeFillColor(smartPin.FillColour.ToAndroid());
                    nativeCircle.InvokeStrokeWidth(smartPin.StrokeWidth);

                    NativeCircle nc = NativeMap.AddCircle(nativeCircle);
                    nativeCircles.Add(nc);
                }
            }
        }
    }
}
