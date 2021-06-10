using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_mobile_app.Api.Resources.GameResources.FullGame
{
    public abstract class DisplayObjectResource : DbBaseResource
    {
#nullable enable

        public short? PositionInIntroduction { get; set; }

        public string? Title { get; set; } // HTML

    }
}