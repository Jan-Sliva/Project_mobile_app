using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Resources.GameResources.FullGame
{
    public abstract class StopOpeningResource : DbBaseResource
    {
        public byte IfUnvisible { get; set; }

        public byte IfVisible { get; set; }

        public byte IfUnlocked { get; set; }

        public short Value { get; set; }

    }
}
