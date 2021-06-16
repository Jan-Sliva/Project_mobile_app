using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Services;


namespace Frontend.Models
{
    public class Stop : DbBase
    {
        public StopService Service;
        public string Name { get; set; } // HTML

        public bool? IsFinal { get; set; }

        public bool? IsInitial { get; set; }

        public Game PartOfGame { get; set; }

        public short? State1Requirement { get; set; }

        public short? State2Requirement { get; set; }

        public short? State3Requirement { get; set; }

        public short? State4Requirement { get; set; }

        public ICollection<StopStop> Opens { get; set; }

        public ICollection<StopStop> StopsOpenThis { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<ChoiceStop> ChoicesOpenThis { get; set; }

        public ICollection<DisplayObjectStopDisplayAfterDisplay> DisplayObjectsHints { get; set; }

        public ICollection<DisplayObjectStopDisplayAfterUnlock>  DisplayObjectsRewards { get; set; }

        public MapPosition Position { get; set; }

        public ICollection<MapPosition> PositionsDisplayAfterDisplay { get; set; }

        public ICollection<MapPosition> PositionsDisplayAfterUnlock { get; set; }

        public ICollection<PasswordGameRequirement> Passwords { get; set; }
    }
}
