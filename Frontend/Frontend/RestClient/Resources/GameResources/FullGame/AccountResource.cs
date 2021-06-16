namespace Frontend.RestClient.Resources.GameResources.FullGame
{
    public abstract class AccountResource : DbBaseResource
    {

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}