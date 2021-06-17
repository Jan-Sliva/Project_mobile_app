using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Essentials;

namespace Frontend.Services
{
    public class LocationChecker
    {
        private List<LocationToCheck> Locations { get; }

        public Thread CheckingThread { get; set; }

        public LocationChecker()
        {
            Locations = new List<LocationToCheck>();
            CheckingThread = new Thread(CheckLocation);
            CheckingThread.IsBackground = true;
            CheckingThread.Start(this);
        }

        public void AddLocation(LocationToCheck newLocation)
        {
            Locations.Add(newLocation);
        }

        public void AddRangeOfLocations(IEnumerable<LocationToCheck> newLocations)
        {
            foreach (LocationToCheck newLocation in newLocations)
            {
                Locations.Add(newLocation);
            }
        }

        public void RemoveLocation(LocationToCheck location)
        {
            if (Locations.Contains(location)) Locations.Remove(location);
        }

        public void RemoveRangeOfLocations(IEnumerable<LocationToCheck> locations)
        {
            foreach (LocationToCheck location in locations)
            {
                if (Locations.Contains(location)) Locations.Remove(location);
            }
        }

        static async void CheckLocation(Object locationsCheckerObject)
        {
            var locationsChecker = locationsCheckerObject as LocationChecker;

            var locationsToCheck = locationsChecker.Locations;

            while (true)
            {
                var currentLocation = await LocationService.GetLastKnownLocation();

                foreach (LocationToCheck location in locationsToCheck)
                {
                    if (Location.CalculateDistance(currentLocation, 
                        location.Latitude, location.Longitude, DistanceUnits.Kilometers) * 1000 < 
                        location.Radius + Math.Min(15, (double)currentLocation.Accuracy))
                    {
                        var InterruptThread = new Thread(ProcessPositionWithThread);
                        InterruptThread.IsBackground = true;
                        InterruptThread.Start(new LocationWithThread() { Thread = Thread.CurrentThread, Location = location, LocationChecker = locationsChecker });
                        while (true) ;
                    }
                }
                Thread.Sleep(500);
            }
        }

        static void ProcessPositionWithThread (Object locationWithThreadObject)
        {
            var locationWithThread = locationWithThreadObject as LocationWithThread;

            locationWithThread.Thread.Abort();

            locationWithThread.LocationChecker.RemoveLocation(locationWithThread.Location);
            locationWithThread.Location.RaiseLocationReached();

            locationWithThread.LocationChecker.CheckingThread = new Thread(CheckLocation);
            locationWithThread.LocationChecker.CheckingThread.IsBackground = true;
            locationWithThread.LocationChecker.CheckingThread.Start(locationWithThread.LocationChecker);
        }
    }

    public class LocationWithThread
    {
        public Thread Thread;

        public LocationToCheck Location;

        public LocationChecker LocationChecker;
    }

    public class LocationToCheck
    {
        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public double Radius { get; private set; }

        public event EventHandler LocationReached;

        public LocationToCheck(double latitude, double longitude, double radius)
        {
            Latitude = latitude;
            Longitude = longitude;
            Radius = radius;
        }

        public void RaiseLocationReached()
        {
            LocationReached(this, EventArgs.Empty);
        }
    }
}
