using System.Collections.Generic;

namespace Frontend.Models
{
    public class DefaultChoice : Choice
    {

        public TextQuestion Question { get; set; }

        public int QuestionId { get; set; }
    }
}
