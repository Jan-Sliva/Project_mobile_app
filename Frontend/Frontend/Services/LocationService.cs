using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Frontend.Services
{
    public static class LocationService
    {
        public static async Task<Location> GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                return location;
            }
            catch (Exception)
            {
                return await GetLastKnownLocation();
            }
        }

        public static async Task<Location> GetLastKnownLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                return location;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
