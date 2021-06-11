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
    public class PinViewModel
    {
        private const float _lockedPinColour = PinColours.Orange;

        private const float _unLockedPinColour = PinColours.LightGreen;

        private const float _notStopPinColour = PinColours.Violet;

        private ColouredPin _pin { get; set; }

        private bool _pinOnMap { get; set; }

        private Circle _circle { get; set; }

        private bool _circleOnMap { get; set; }

        private bool _showCircle { get; set; }

        public bool ShowCircle
        {
            get { return _showCircle; }
            set { _showCircle = value; RefreshCircleOnMap(); }
        }

        private MapViewModel _mapView { get; set; }

        private double _X { get; }

        private double _Y { get; }

        private double _radius { get; }

        private string _label { get; set; }

        private PinDisplayType _colourType;

        public PinDisplayType ColourType
        {
            get { return _colourType; }
            set
            {
                _colourType = value;
                RefreshPinOnMap();
                RefreshCircleOnMap();
             }
        }

        public MapPosition MapPosition { get;  }

        public PinViewModel(MapViewModel mapView, MapPosition position, PinDisplayType type, bool showCircle)
        {
            _X = position.X;
            _Y = position.Y;
            _radius = position.Radius;
            _label = position.Description;
            if (_label == null) _label = "";
            _mapView = mapView;
            MapPosition = position;
            _colourType = type;
            _showCircle = showCircle;

            _pin = new ColouredPin()
            {
                Position = new Position(_X, _Y),
                Type = PinType.Generic,
                Label = _label
            };

            _circle = new Circle()
            {
                Center = new Position(_X, _Y),
                Radius = new Distance(_radius),
                StrokeWidth = 7
            };

            if (type != PinDisplayType.NOT_VISIBLE)
            {
                _mapView.mapPage.AddPinToMap(_pin);
                _pinOnMap = true;
            }
            else
            {
                _pinOnMap = false;
            }

            if (_showCircle)
            {
                mapView.mapPage.AddMapElementToMap(_circle);
                _circleOnMap = true;
            }
            else
            {
                _circleOnMap = false;
            }

            RefreshPinOnMap();
            RefreshCircleOnMap();
        }


        private float _getColourByDisplayType(PinDisplayType pinDisplayType)
        {
            switch (ColourType)
            {
                case PinDisplayType.LOCKED: return _lockedPinColour;
                case PinDisplayType.UNLOCKED: return _unLockedPinColour;
                case PinDisplayType.NOT_STOP: return _notStopPinColour;
                default: return 0;
            }
        }

        public void RefreshCircleOnMap()
        {
            if ((_showCircle && !_circleOnMap) && ColourType != PinDisplayType.NOT_VISIBLE)
            {
                _mapView.mapPage.AddMapElementToMap(_circle);
                _circleOnMap = true;
            }
            else if (!_showCircle && _circleOnMap)
            {
                _mapView.mapPage.RemoveMapElementFromMap(_circle);
                _circleOnMap = false;
            }

            if (_circleOnMap)
            {
                _circle.FillColor = Color.FromHsva(_getColourByDisplayType(ColourType) / 360, 1, 0.5, 0.5);
                _circle.StrokeColor = Color.FromHsva(_getColourByDisplayType(ColourType) / 360, 1, 0.5, 1);
            }
        }

        public void RefreshPinOnMap()
        {
            if (ColourType != PinDisplayType.NOT_VISIBLE && !_pinOnMap)
            {
                _mapView.mapPage.AddPinToMap(_pin);
                _pinOnMap = true;
            }
            else if (ColourType == PinDisplayType.NOT_VISIBLE && _pinOnMap)
            {
                _mapView.mapPage.RemovePinFromMap(_pin);
                _pinOnMap = false;
            }

            if (_pinOnMap)
            {
                _pin.Colour = _getColourByDisplayType(ColourType);
            }
        }

        public void Remove()
        {
            ColourType = PinDisplayType.NOT_VISIBLE;
            ShowCircle = false;
        }
    }
}
