using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Resources.GameResources.FullGame
{
    public abstract class AccountResource : DbBaseResource
    {
#nullable disable
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}