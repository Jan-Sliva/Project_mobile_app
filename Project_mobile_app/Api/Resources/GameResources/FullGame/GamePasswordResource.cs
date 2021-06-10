namespace Project_mobile_app.Api.Resources.GameResources.FullGame
{
    public class GamePasswordResource : DbBaseResource
    {
#nullable disable
        public string Password { get; set; }

        public bool UseRegex { get; set; }

        public bool DiffUpperCase { get; set; }
    }
}