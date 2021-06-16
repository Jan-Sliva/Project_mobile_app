using System.Collections.Generic;

namespace Frontend.RestClient.Resources.GameResources.FullGame
{
    public class IntroductionResource : DbBaseResource
    {

        public string Title { get; set; } // HTML


        public ICollection<MapPositionResource> MapPositions { get; set; }

        public ICollection<DisplayObjectResource> DisplayObjects { get; set; }

    }
}