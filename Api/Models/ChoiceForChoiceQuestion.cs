using System.Collections.Generic;

namespace Project_mobile_app.Models
{
    public class ChoiceForChoiceQuestion : Choice
    {
#nullable disable
        public ChoiceQuestion Question { get; set; }

        public string Text { get; set; } // HTML
    }
}
