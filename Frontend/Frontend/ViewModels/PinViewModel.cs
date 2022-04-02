using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Models;
using Xamarin.Forms.Maps;
using Frontend.Resources;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    public enum PinDisplayType
    {
        NOT_VISIBLE,
        LOCKED,
        UNLOCKED,
        NOT_STOP
    }
    public class PinViewModel : BaseViewModel
    {
        private const float _lockedPinColour = PinColours.Orange;

        private const float _unLockedPinColour = PinColours.LightGreen;

        private const float _notStopPinColour = PinColours.Violet;

        private ColouredPin Pin { get; }

        private bool PinOnMap { get; set; }

        private Circle Circle { get; }

        private bool CircleOnMap { get; set; }

        private MapViewModel MapView { get; }

        private double X { get; }

        private double Y { get; }

        private double Radius { get; }

        private string Label { get; set; }

        private PinDisplayType _state;

        public PinDisplayType State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }

        private bool _showCircle;

        public bool ShowCircle
        {
            get { return _showCircle; }
            set { SetProperty(ref _showCircle, value); }
        }

        public PinViewModel(MapViewModel mapView, MapPosition position, PinDisplayType state)
        {
            X = position.X;
            Y = position.Y;
            Radius = position.Radius;
            Label = position.Description;
            if (Label == null) Label = "";
            MapView = mapView;
            State = state;

            this.PropertyChanged += (_, __) => RefreshPinOnMap();
            this.PropertyChanged += (_, __) => RefreshCircleOnMap();

            Pin = new ColouredPin()
            {
                Position = new Position(X, Y),
                Type = PinType.Generic,
                Label = Label
            };

            Circle = new Circle()
            {
                Center = new Position(X, Y),
                Radius = new Distance(Radius),
                StrokeWidth = 7
            };

            if (type != PinDisplayType.NOT_VISIBLE)
            {
                MapView.MapPage.AddPinToMap(Pin);
                PinOnMap = true;
            }
            else
            {
                PinOnMap = false;
            }

            if (_showCircle)
            {
                mapView.MapPage.AddMapElementToMap(Circle);
                CircleOnMap = true;
            }
            else
            {
                CircleOnMap = false;
            }

            RefreshPinOnMap();
            RefreshCircleOnMap();
        }

        public void SetState(PinDisplayType state)
        {
            State = state;

        }

        private float GetColourByDisplayType(PinDisplayType pinDisplayType)
        {
            switch (pinDisplayType)
            {
                case PinDisplayType.LOCKED: return _lockedPinColour;
                case PinDisplayType.UNLOCKED: return _unLockedPinColour;
                case PinDisplayType.NOT_STOP: return _notStopPinColour;
                default: return 0;
            }
        }

        public void RefreshCircleOnMap()
        {
            if ((_showCircle && !CircleOnMap) && ColourType != PinDisplayType.NOT_VISIBLE)
            {
                MapView.MapPage.AddMapElementToMap(Circle);
                CircleOnMap = true;
            }
            else if (!_showCircle && CircleOnMap)
            {
                MapView.MapPage.RemoveMapElementFromMap(Circle);
                CircleOnMap = false;
            }

            if (CircleOnMap)
            {
                Circle.FillColor = Color.FromHsva(GetColourByDisplayType(ColourType) / 360, 1, 0.5, 0.5);
                Circle.StrokeColor = Color.FromHsva(GetColourByDisplayType(ColourType) / 360, 1, 0.5, 1);
            }
        }

        public void RefreshPinOnMap()
        {
            if (ColourType != PinDisplayType.NOT_VISIBLE && !PinOnMap)
            {
                MapView.MapPage.AddPinToMap(Pin);
                PinOnMap = true;
            }
            else if (ColourType == PinDisplayType.NOT_VISIBLE && PinOnMap)
            {
                MapView.MapPage.RemovePinFromMap(Pin);
                PinOnMap = false;
            }

            if (PinOnMap)
            {
                Pin.Colour = GetColourByDisplayType(ColourType);
            }
        }

        public void Remove()
        {
            ColourType = PinDisplayType.NOT_VISIBLE;
            ShowCircle = false;
        }
    }
}
