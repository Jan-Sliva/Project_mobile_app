using System.Collections.Generic;

namespace Project_mobile_app.Models
{
    public class Introduction : DbBase
    {
#nullable disable
        public string Title { get; set; } // HTML

        public Game Game { get; set; }

        public int GameId { get; set; }
#nullable enable
        public ICollection<MapPosition>? MapPositions { get; set; }

        public ICollection<DisplayObject>? DisplayObjects { get; set; }

    }
}