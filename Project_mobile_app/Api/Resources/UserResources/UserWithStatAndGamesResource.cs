using System;
using System.Collections.Generic;
using System.Text;

namespace Project_mobile_app.Api.Resources.UserResources
{
    public class UserWithStatAndGamesResource
    {

#nullable disable
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public StatisticsResource Statistics { get; set; }
#nullable enable
        public ICollection<GameForUserResource>? Games { get; set; }


    }
}
