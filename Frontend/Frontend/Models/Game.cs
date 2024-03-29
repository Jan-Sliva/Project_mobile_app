﻿using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public class Game : DbBase
    {

        public string Name { get; set; } // HTML

        public string Description { get; set; } // HTML 

        public ICollection<Stop> Stops { get; set; }

        public Introduction Introduction { get; set; }

        public ICollection<User> Owners { get; set; }

        public TimeSpan PlayingTime { get; set; } // in minutes

        public TimeSpan Limit { get; set; } // in minutes

    }
}