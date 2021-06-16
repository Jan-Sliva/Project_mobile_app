using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_mobile_app.Models
{
    public abstract class Question : DbBase
    {
#nullable disable
        public string QuestionText { get; set; } // HTML

#nullable enable
        public ICollection<Stop>? StopsThatOpenThis { get; set; }

        public ICollection<Choice>? ChoicesThatOpensThis { get; set; }

    }
}