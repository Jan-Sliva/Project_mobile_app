using System;
using System.Collections.Generic;
using System.Text;

namespace Project_mobile_app.Api.Resources.UserResources
{
    public class GameForUserResource
    {
#nullable disable
        public int Id { get; set; }

        public string Name { get; set; } // HTML

        public string Description { get; set; } // HTML 

#nullable enable

        public short? PlayingTime { get; set; } // in minutes

        public short? Limit { get; set; } // in minutes
    }
}
