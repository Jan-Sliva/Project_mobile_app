using System.Collections.Generic;
using Frontend.Services;

namespace Frontend.Models
{
    public class ChoiceQuestion : Question
    {
        public ICollection<ChoiceForChoiceQuestion> Choices { get; set; }
    }
}
