using System.Collections.Generic;

namespace Project_mobile_app.Models
{
    public class DefaultChoice : Choice
    {
#nullable disable
        public TextQuestion Question { get; set; }

        public int QuestionId { get; set; }
    }
}
