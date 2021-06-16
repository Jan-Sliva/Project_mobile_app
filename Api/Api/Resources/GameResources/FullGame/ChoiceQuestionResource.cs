using System.Collections.Generic;

namespace Api.Resources.GameResources.FullGame
{
    public class ChoiceQuestionResource : QuestionResource
    {
#nullable disable
        public ICollection<ChoiceForChoiceQuestionResource> Choices { get; set; }

    }
}
