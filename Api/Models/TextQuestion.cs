using System;
using System.Collections.Generic;
using System.Text;

namespace Project_mobile_app.Models
{
    public class TextQuestion : Question
    {
#nullable disable
        public DefaultChoice DefaultChoice { get; set; }
#nullable enable
        public ICollection<ChoiceForTextQuestion>? Choices { get; set; }

    }
}
