using System.Collections.Generic;

namespace Frontend.RestClient.Resources.GameResources.FullGame
{
    public class MapPositionResource : DbBaseResource
    {

        public double? X { get; set; }

        public double? Y { get; set; }

        public double? Radius { get; set; } // meters

        public string Description { get; set; }

        public bool? IsVisibleAsStopPosition { get; set; }
    }
}