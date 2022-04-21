using CustomRenderer.Droid;
using NativeCircle = Android.Gms.Maps.Model.Circle;

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
            if (e.PropertyName == ((SmartMap)this.Element).SmartPinsProperty.PropertyName)
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
                marker.SetSnippet(smartPin.Address);
                marker.SetIcon(BitmapDescriptorFactory.DefaultMarker(smartPin.Colour));

                Marker m = NativeMap.AddMarker(marker);
                markers.Add(m);

                if (smartPin.ShowCircle && smartPin.Radius > 0)
                {
                    var nativeCircle = new CircleOptions();
                    nativeCircle.InvokeCenter(new LatLng(smartPin.Position.Latitude, smartPin.Position.Longitude));
                    nativeCircle.InvokeRadius(float.Parse(smartPin.Radius));
                    nativeCircle.InvokeStrokeColor(smartPin.StrokeColor.ToAndroid());
                    nativeCircle.InvokeFillColor(smartPin.FillColor.ToAndroid());
                    nativeCircle.InvokeStrokeWidth(smartPin.StrokeWidth * this.ScaledDensity);

                    NativeCircle nc = NativeMap.AddCircle(nativeCircle);
                    nativeCircles.Add(nc);
                }
            }
        }
    }
}
