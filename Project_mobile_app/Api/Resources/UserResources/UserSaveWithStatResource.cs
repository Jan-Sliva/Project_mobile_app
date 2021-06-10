﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project_mobile_app.Api.Resources.UserResources
{
    public class UserSaveWithStatResource
    {
#nullable disable
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public StatisticsSaveResource Statistics { get; set; }
    }
}
