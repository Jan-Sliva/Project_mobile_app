using System;
using System.Collections.Generic;
using System.Text;

namespace Project_mobile_app.Api.Resources.UserResources
{
    public class StatisticsSaveResource
    {
#nullable disable
        public int TimeInGames { get; set; } // in minutes

        public short NumberOfGamesPlayed { get; set; }

        public short SuccesfullGames { get; set; }
    }
}
