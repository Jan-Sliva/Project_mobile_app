using System.Collections.Generic;

namespace Project_mobile_app.Models
{
    public class MapPosition : DbBase
    {
#nullable disable
        public double X { get; set; }

        public double Y { get; set; }

        public double Radius { get; set; } // meters
#nullable enable
        public string? Description { get; set; }

        public Introduction? Introduction { get; set; }

        public ICollection<Choice>? ChoicesThatOpenThis { get; set; }

        public Stop? PositionOfStop { get; set; }

        public int? PositionOfStopId { get; set; }

        public bool? IsVisibleAsStopPosition { get; set; }

        public ICollection<Stop>? StopDisplayAfterDisplay { get; set; }

        public ICollection<Stop>? StopDisplayAfterUnlock { get; set; }
    }
}