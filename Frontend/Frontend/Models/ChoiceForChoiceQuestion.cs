using System.Collections.Generic;

namespace Frontend.Models
{
    public class ChoiceForChoiceQuestion : Choice
    {

        public ChoiceQuestion Question { get; set; }

        public string Text { get; set; } // HTML
    }
}
