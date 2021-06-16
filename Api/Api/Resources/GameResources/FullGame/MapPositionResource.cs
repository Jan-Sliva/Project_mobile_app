using System.Collections.Generic;

namespace Api.Resources.GameResources.FullGame
{
    public class MapPositionResource : DbBaseResource
    {
#nullable disable
        public double X { get; set; }

        public double Y { get; set; }

        public double Radius { get; set; } // meters
#nullable enable
        public string? Description { get; set; }

        public bool? IsVisibleAsStopPosition { get; set; }
    }
}