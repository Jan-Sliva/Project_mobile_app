using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Project_mobile_app.Models
{
    public class Stop : DbBase
    {

#nullable disable
        public string Name { get; set; } // HTML

        public bool IsFinal { get; set; }

        public Game PartOfGame { get; set; }

        public int GameFirstStopId { get; set; }

#nullable enable

        public ICollection<Stop>? Opens { get; set; }

        public ICollection<Stop>? StopsThatOpenThis { get; set; }

        public Game? FirstStopOfGame { get; set; }

        public ICollection<Question>? Questions { get; set; }

        public ICollection<Choice>? ChoicesThatOpenThis { get; set; }

        public ICollection<DisplayObjectStopDisplayAfterDisplay>? DisplayObjectsHints { get; set; }

        public ICollection<DisplayObjectStopDisplayAfterUnlock>?  DisplayObjectsRewards { get; set; }

        public MapPosition? Position { get; set; }

        public ICollection<MapPosition>? PositionsDisplayAfterDisplay { get; set; }

        public ICollection<MapPosition>? PositionsDisplayAfterUnlock { get; set; }

        public ICollection<PasswordGameRequirement>? Passwords { get; set; }
    }
}
