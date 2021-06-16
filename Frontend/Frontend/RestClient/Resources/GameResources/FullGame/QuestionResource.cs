using System.Collections.Generic;

namespace Frontend.RestClient.Resources.GameResources.FullGame
{
    public class QuestionResource : DbBaseResource
    {
        public ICollection<ChoiceResource> Choices { get; set; }

        public ChoiceResource DefaultChoice { get; set; }

        public string QuestionText { get; set; } // HTML

        public ICollection<ChoiceResource> ChoicesThatOpensThis { get; set; }

    }
}