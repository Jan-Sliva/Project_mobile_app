using System.ComponentModel.DataAnnotations.Schema;

namespace Project_mobile_app.Api.Resources.GameResources.FullGame
{
    public abstract class AccountResource : DbBaseResource
    {
#nullable disable
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}