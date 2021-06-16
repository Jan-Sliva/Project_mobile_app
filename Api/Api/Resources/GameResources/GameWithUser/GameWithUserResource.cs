using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Resources.GameResources.GameWithUser
{
    public class GameWithUserResource
    {
#nullable disable
        public int Id { get; set; }

        public string Name { get; set; } // HTML

        public string Description { get; set; } // HTML 

        public ICollection<UserForGameResource> Owners { get; set; }

#nullable enable

        public short? PlayingTime { get; set; } // in minutes

        public short? Limit { get; set; } // in minutes
    }
}
