using System.Collections.Generic;

namespace Project_mobile_app.Models
{
    public class PasswordGameRequirement : DbBase
    {
#nullable disable
        public string Question { get; set; } // HTML

        public ICollection<GamePassword> Passwords { get; set; }

        public Stop Stop { get; set; }

    }
}