using System.Collections.Generic;

namespace Frontend.Models
{
    public class Introduction : DbBase
    {

        public string Title { get; set; } // HTML

        public Game Game { get; set; }

        public int GameId { get; set; }

        public ICollection<MapPosition> MapPositions { get; set; }

        public ICollection<DisplayObject> DisplayObjects { get; set; }

    }
}