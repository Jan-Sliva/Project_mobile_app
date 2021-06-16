using System.Collections.Generic;

namespace Api.Resources.GameResources.FullGame
{
    public class PasswordGameRequirementResource : DbBaseResource
    {
#nullable disable
        public string Question { get; set; } // HTML

        public ICollection<GamePasswordResource> Passwords { get; set; }

    }
}