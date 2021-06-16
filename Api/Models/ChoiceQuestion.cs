using System.Collections.Generic;

namespace Project_mobile_app.Models
{
    public class ChoiceQuestion : Question
    {
#nullable disable
        public ICollection<ChoiceForChoiceQuestion> Choices { get; set; }

    }
}
