using System.Collections.Generic;

namespace Frontend.RestClient.Resources.GameResources.FullGame
{
    public class ChoiceResource : DbBaseResource
    {
        public string Text { get; set; }

        public bool? UseRegex { get; set; }

        public bool? DiffUpperCase { get; set; }

        public ICollection<MapPositionResource> OpensMapPositions { get; set; }
    }
}