using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Resources.UserResources
{
    public class StatisticsResource
    {
#nullable disable
        public int Id { get; set; }

        public int TimeInGames { get; set; } // in minutes

        public short NumberOfGamesPlayed { get; set; }

        public short SuccesfullGames { get; set; }
    }
}
