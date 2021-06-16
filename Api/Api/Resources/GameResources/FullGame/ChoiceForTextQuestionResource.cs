using System.Collections.Generic;

namespace Api.Resources.GameResources.FullGame
{
    public class ChoiceForTextQuestionResource : ChoiceResource
    {
#nullable disable
        public string Text { get; set; } 

        public bool UseRegex { get; set; }

        public bool DiffUpperCase { get; set; }
    }
}
