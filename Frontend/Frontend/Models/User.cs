using System.Collections.Generic;

namespace Frontend.Models
{
    public class User : Account
    {

        public Statistics Statistics { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}