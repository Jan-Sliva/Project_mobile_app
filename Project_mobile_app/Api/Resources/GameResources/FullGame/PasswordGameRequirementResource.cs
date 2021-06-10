using System.Collections.Generic;

namespace Project_mobile_app.Api.Resources.GameResources.FullGame
{
    public class PasswordGameRequirementResource : DbBaseResource
    {
#nullable disable
        public string Question { get; set; } // HTML

        public ICollection<GamePasswordResource> Passwords { get; set; }

    }
}