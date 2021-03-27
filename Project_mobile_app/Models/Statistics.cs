using System;

namespace Project_mobile_app.Models
{
    public class Statistics : DbBase
    {
#nullable disable
        public User User { get; set; }

        public int UserId { get; set; }

        public DateTime TimeInGames { get; set; }

        public short NumberOfGamesPlayed { get; set; }

        public short SuccesfullGames { get; set; }
    }
}