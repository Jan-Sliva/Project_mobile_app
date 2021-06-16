using System.Collections.Generic;

namespace Project_mobile_app.Models
{
    public class User : Account
    {
#nullable disable
        public Statistics Statistics { get; set; }
#nullable enable
        public ICollection<Game>? Games { get; set; }
    }
}