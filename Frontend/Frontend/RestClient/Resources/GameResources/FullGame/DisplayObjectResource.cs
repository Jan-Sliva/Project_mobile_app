using System.Collections.Generic;

namespace Frontend.RestClient.Resources.GameResources.FullGame
{
    public class DisplayObjectResource : DbBaseResource
    {
        public string OwnText { get; set; } // HTML

        public byte[] Image { get; set; }

        public short? PositionInIntroduction { get; set; }

        public string Title { get; set; } // HTML

    }
}