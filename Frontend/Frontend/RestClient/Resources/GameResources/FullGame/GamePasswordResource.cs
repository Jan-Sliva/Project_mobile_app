namespace Frontend.RestClient.Resources.GameResources.FullGame
{
    public class GamePasswordResource : DbBaseResource
    {

        public string Password { get; set; }

        public bool? UseRegex { get; set; }

        public bool? DiffUpperCase { get; set; }
    }
}