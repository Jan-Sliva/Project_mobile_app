using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;
    
 namespace Frontend.Services
{
    public class LocationChecker
    {
        private List<LocationToCheck> Locations { get; }
        public LocationChecker()
        {
            Locations = new List<LocationToCheck>();
            _ = CheckLocationPeriodically();
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
        private Task CheckLocationPeriodically()
        {
            return Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        await CheckLocation();
                    }
                    catch (Exception e)
                    {
                        //TODO
                        Console.WriteLine(e.ToString());
                    }

                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            });
        }
        private async Task CheckLocation()
        {
            var currentLocation = await LocationService.GetLastKnownLocation();
            
            foreach (LocationToCheck location in Locations.ToArray())
            {
                if (Location.CalculateDistance(currentLocation,
                location.Latitude, location.Longitude, DistanceUnits.Kilometers) * 1000 <
                location.Radius + Math.Min(15, (double)currentLocation.Accuracy))
                {
                    RemoveLocation(location);
                    location.RaiseLocationReached();
                }
            }
        }

        private void WriteLocations()
        {
            Console.WriteLine("Locations:");
            foreach (LocationToCheck location in Locations)
            {
                location.WriteLocation();
            }
        }

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

        public void WriteLocation()
        {
            Console.WriteLine("Loc: " + this.Latitude + ", " + this.Longitude + ", radius: " + this.Radius);

        }
    }
}

