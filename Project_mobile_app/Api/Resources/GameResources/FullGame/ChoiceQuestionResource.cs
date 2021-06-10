using System.Collections.Generic;

namespace Project_mobile_app.Api.Resources.GameResources.FullGame
{
    public class ChoiceQuestionResource : QuestionResource
    {
#nullable disable
        public ICollection<ChoiceForChoiceQuestionResource> Choices { get; set; }

    }
}
