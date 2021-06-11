using System;

namespace Frontend.Models
{
    public class Statistics : DbBase
    {

        public User User { get; set; }

        public int UserId { get; set; }

        public int TimeInGames { get; set; } // in minutes

        public short NumberOfGamesPlayed { get; set; }

        public short SuccesfullGames { get; set; }
    }
}