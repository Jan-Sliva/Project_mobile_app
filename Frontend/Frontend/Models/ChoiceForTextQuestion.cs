using System.Collections.Generic;

namespace Frontend.Models
{
    public class ChoiceForTextQuestion : Choice
    {

        public TextQuestion Question { get; set; }

        public string Text { get; set; } 

        public bool? UseRegex { get; set; }

        public bool? DiffUpperCase { get; set; }
    }
}
