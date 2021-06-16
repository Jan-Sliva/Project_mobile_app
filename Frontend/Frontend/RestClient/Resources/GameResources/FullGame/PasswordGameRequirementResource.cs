using System.Collections.Generic;

namespace Frontend.RestClient.Resources.GameResources.FullGame
{
    public class PasswordGameRequirementResource : DbBaseResource
    {

        public string Question { get; set; } // HTML

        public ICollection<GamePasswordResource> Passwords { get; set; }

    }
}