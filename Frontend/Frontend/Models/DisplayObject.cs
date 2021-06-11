using System.Collections.Generic;


namespace Frontend.Models
{
    public abstract class DisplayObject : DbBase
    {


        public Introduction Introduction { get; set; }

        public short? PositionInIntroduction { get; set; }

        public string Title { get; set; } // HTML

        public ICollection<DisplayObjectStopDisplayAfterDisplay> HintForTheseStops { get; set; }

        public ICollection<DisplayObjectStopDisplayAfterUnlock> RewardForTheseStops { get; set; }

    }
}