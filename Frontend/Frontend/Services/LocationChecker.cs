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
            CheckingThread.Abort();

            Locations.Add(newLocation);

            CheckingThread = new Thread(CheckLocation);
            CheckingThread.IsBackground = true;
            CheckingThread.Start(this);
        }

        public void AddRangeOfLocations(IEnumerable<LocationToCheck> newLocations)
        {
            CheckingThread.Abort();

            foreach(LocationToCheck newLocation in newLocations)
            {
                Locations.Add(newLocation);
            }

            CheckingThread = new Thread(CheckLocation);
            CheckingThread.IsBackground = true;
            CheckingThread.Start(this);
        }

        public void RemoveLocation(LocationToCheck location)
        {
            CheckingThread.Abort();

            Locations.Remove(location);

            CheckingThread = new Thread(CheckLocation);
            CheckingThread.IsBackground = true;
            CheckingThread.Start(this);
        }

        public void RemoveRangeOfLocations(IEnumerable<LocationToCheck> locations)
        {
            CheckingThread.Abort();

            foreach (LocationToCheck location in locations)
            {
                Locations.Add(location);
            }

            CheckingThread = new Thread(CheckLocation);
            CheckingThread.IsBackground = true;
            CheckingThread.Start(this);
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
                        location.RaiseLocationReached();

                        // this removes location from the list and reloads the thread
                        var interruptThread = new Thread(RemoveLocationFromThread);
                        interruptThread.IsBackground = true;
                        interruptThread.Start(new ThreadWithLocation() { Location = location, LocationChecker = locationsChecker, Thread = Thread.CurrentThread });
                    }
                }
                Thread.Sleep(500);
            }
        }

        static void RemoveLocationFromThread(Object threadWithLocationObject)
        {
            ThreadWithLocation threadWithLocation = threadWithLocationObject as ThreadWithLocation;

            threadWithLocation.Thread.Abort();

            threadWithLocation.LocationChecker.Locations.Remove(threadWithLocation.Location);

            threadWithLocation.LocationChecker.CheckingThread = new Thread(CheckLocation);
            threadWithLocation.LocationChecker.CheckingThread.IsBackground = true;
            threadWithLocation.LocationChecker.CheckingThread.Start(threadWithLocation.LocationChecker);
        }
    }

    public class ThreadWithLocation
    {
        public LocationToCheck Location { get; set; }

        public LocationChecker LocationChecker { get; set; }

        public Thread Thread { get; set; }
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
