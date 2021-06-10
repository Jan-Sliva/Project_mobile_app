using System.Collections.Generic;

namespace Project_mobile_app.Api.Resources.GameResources.FullGame
{
    public class ChoiceForTextQuestionResource : ChoiceResource
    {
#nullable disable
        public string Text { get; set; } 

        public bool UseRegex { get; set; }

        public bool DiffUpperCase { get; set; }
    }
}
