using System;
using System.Collections.Generic;
using System.Text;
using Frontend.ViewModels;
using Frontend.Models;

namespace Frontend.Services
{
    public class MapService
    {
        private MapViewModel MapViewModel;

        public MapService(AppShell appShell)
        {
            MapViewModel = new MapViewModel(appShell);
        }

        public void AddNotStops(List<MapPosition> mapPositions)
        {
            foreach(MapPosition position in mapPositions)
            {
                MapViewModel.AddMapPosition(position, PinDisplayType.NOT_STOP, true);
            }
        }

        public PinViewModel AddStop(MapPosition position, int state)
        {
            if (state == 1) return MapViewModel.AddMapPosition(position, PinDisplayType.NOT_VISIBLE, false);
            else if (state == 2) return MapViewModel.AddMapPosition(position, PinDisplayType.LOCKED, true);
            else if (state == 3) return MapViewModel.AddMapPosition(position, PinDisplayType.UNLOCKED, false);
            return null;
        }

        public void SetPinViewModelToState(PinViewModel pinView, int state)
        {
            if (state == 1)
            {
                pinView.ColourType = PinDisplayType.NOT_VISIBLE;
                pinView.ShowCircle = false;
            }
            else if (state == 2)
            {
                pinView.ColourType = PinDisplayType.LOCKED;
                pinView.ShowCircle = true;
            }
            else if (state == 3)
            {
                pinView.ColourType = PinDisplayType.UNLOCKED;
                pinView.ShowCircle = false;
            }
        }
    }
}
