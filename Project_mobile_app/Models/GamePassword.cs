namespace Project_mobile_app.Models
{
    public class GamePassword : DbBase
    {
        public string Password { get; set; }

        public bool UseRegex { get; set; }

        public bool DiffUpperCase { get; set; }

        public PasswordGameRequirement PasswordGameRequirement { get; set; }
    }
}