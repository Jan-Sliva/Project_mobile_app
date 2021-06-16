using System;
using System.Collections.Generic;

namespace Api.Resources.GameResources.FullGame
{
    public class GameResource : DbBaseResource
    {
#nullable disable
        public string Name { get; set; } // HTML

        public string Description { get; set; } // HTML 

        public ICollection<StopResource> Stops { get; set; }

        public IntroductionResource Introduction { get; set; }

        public ICollection<UserResourceForFullGame> Owners { get; set; }

#nullable enable

        public short? PlayingTime { get; set; } // in minutes

        public short? Limit { get; set; } // in minutes

    }
}