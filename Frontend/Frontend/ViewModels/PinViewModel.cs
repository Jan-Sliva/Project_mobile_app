using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Models;
using Xamarin.Forms.Maps;
using Frontend.Resources;
using Xamarin.Forms;
using Frontend.Smart;
using System.ComponentModel;
using Frontend.Views;

namespace Frontend.ViewModels
{
    public enum PinDisplayType
    {
        NOT_VISIBLE,
        LOCKED,
        UNLOCKED,
        NOT_STOP
    }
    public class PinViewModel<T> : BaseViewModel where T : BasePage
    {
        private PinDisplayType _state;
        public PinDisplayType State { get  => _state; set => SetProperty(ref _state, value); }

        private Position _position;
        public Position Position { get => _position; set => SetProperty(ref _position, value); }

        private string _label;
        public string Label { get => _label; set => SetProperty(ref _label, value);}

        public double Radius { get; private set; }

        public bool ShowCircle { get; private set; }

        public float Colour { get; private set; }

        public Color FillColour { get; private set; }

        public Color StrokeColour { get; private set; }

        public float StrokeWidth { get; private set; } = 7;

        private bool _isVisible = false;

        private MapViewModel<T> MapView;

        private const float _lockedPinColour = PinColours.Orange;

        private const float _unLockedPinColour = PinColours.LightGreen;

        private const float _notStopPinColour = PinColours.Violet;


        public PinViewModel(MapViewModel<T> mapView, MapPosition position, PinDisplayType state)
        {
            Position = new Position(position.X, position.Y);
            Radius = position.Radius;
            Label = position.Description;
            if (Label == null) Label = "";
            MapView = mapView;
            State = state;

            PropertyChanged += ChangedProperty;
        }

        private void ChangedProperty(object sender, PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName;

            if (propertyName == nameof(State))
            {
                UpdateState();
            }
        }

        private void UpdateState()
        {
            switch (this.State)
            {
                case PinDisplayType.NOT_VISIBLE:
                    Hide();
                    break;
                case PinDisplayType.UNLOCKED:
                    Colour = _unLockedPinColour;
                    FillColour = Color.FromHsva(_unLockedPinColour / 360, 1, 0.5, 0.5);
                    StrokeColour = Color.FromHsva(_unLockedPinColour / 360, 1, 0.5, 1);
                    ShowCircle = false;
                    Show();
                    break;
                case PinDisplayType.LOCKED:
                    Colour = _lockedPinColour;
                    FillColour = Color.FromHsva(_lockedPinColour / 360, 1, 0.5, 0.5);
                    StrokeColour = Color.FromHsva(_lockedPinColour / 360, 1, 0.5, 1);
                    ShowCircle = true;
                    Show();
                    break;
                case PinDisplayType.NOT_STOP:
                    Colour = _notStopPinColour;
                    FillColour = Color.FromHsva(_notStopPinColour / 360, 1, 0.5, 0.5);
                    StrokeColour = Color.FromHsva(_notStopPinColour / 360, 1, 0.5, 1);
                    ShowCircle = true;
                    Show();
                    break;
                default: break;
            }
        }

        public void Show()
        {
            if (!_isVisible) MapView.AddPinViewModel(this);

            _isVisible = true;
        }

        public void Hide()
        {
            if (_isVisible) MapView.RemovePinViewModel(this);

            _isVisible = false;
        }
        
    }
}
