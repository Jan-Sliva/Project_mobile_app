using System.Collections.Generic;

namespace Frontend.Models
{
    public class ChoiceQuestion : Question
    {
        public ICollection<ChoiceForChoiceQuestion> Choices { get; set; }

    }
}
