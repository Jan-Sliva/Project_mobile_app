using System.Collections.Generic;

namespace Api.Resources.GameResources.FullGame
{
    public class IntroductionResource : DbBaseResource
    {
#nullable disable
        public string Title { get; set; } // HTML

#nullable enable
        public ICollection<MapPositionResource>? MapPositions { get; set; }

        public ICollection<DisplayObjectResource>? DisplayObjects { get; set; }

    }
}