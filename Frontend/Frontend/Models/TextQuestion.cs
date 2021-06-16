using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Services;

namespace Frontend.Models
{
    public class TextQuestion : Question
    {
        public DefaultChoice DefaultChoice { get; set; }

        public ICollection<ChoiceForTextQuestion> Choices { get; set; }
    }
}
