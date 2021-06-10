using System;
using System.Collections.Generic;
using System.Text;

namespace Project_mobile_app.Api.Resources.GameResources.FullGame
{
    public class TextQuestionResource : QuestionResource
    {
#nullable disable
        public DefaultChoiceResource DefaultChoice { get; set; }
#nullable enable
        public ICollection<ChoiceForTextQuestionResource>? Choices { get; set; }

    }
}
