using System.Collections.Generic;

namespace Frontend.Models
{
    public class PasswordGameRequirement : DbBase
    {

        public string Question { get; set; } // HTML

        public ICollection<GamePassword> Passwords { get; set; }

        public Stop Stop { get; set; }

    }
}