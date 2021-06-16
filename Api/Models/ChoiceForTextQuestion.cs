using System.Collections.Generic;

namespace Project_mobile_app.Models
{
    public class ChoiceForTextQuestion : Choice
    {
#nullable disable
        public TextQuestion Question { get; set; }

        public string Text { get; set; } 

        public bool UseRegex { get; set; }

        public bool DiffUpperCase { get; set; }
    }
}
