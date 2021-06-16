using System;
using System.Collections.Generic;

namespace Project_mobile_app.Models
{
    public class Game : DbBase
    {
#nullable disable
        public string Name { get; set; } // HTML

        public string Description { get; set; } // HTML 

        public ICollection<Stop> Stops { get; set; }

        public Introduction Introduction { get; set; }

        public ICollection<User> Owners { get; set; }

#nullable enable

        public short? PlayingTime { get; set; } // in minutes

        public short? Limit { get; set; } // in minutes

    }
}