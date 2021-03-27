using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_mobile_app.Models
{
    public abstract class DisplayObject : DbBase
    {
#nullable enable

        public Introduction? Introduction { get; set; }

        public short? PositionInIntroduction { get; set; }

        public string? Title { get; set; } // HTML

        public ICollection<DisplayObjectStopDisplayAfterDisplay>? HintForTheseStops { get; set; }

        public ICollection<DisplayObjectStopDisplayAfterUnlock>? RewardForTheseStops { get; set; }

    }
}