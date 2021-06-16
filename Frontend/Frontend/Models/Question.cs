using System.Collections.Generic;
using Frontend.Services;


namespace Frontend.Models
{
    public abstract class Question : DbBase
    {

        public string QuestionText { get; set; } // HTML

        public ICollection<Stop> StopsThatOpenThis { get; set; }

        public ICollection<Choice> ChoicesThatOpensThis { get; set; }

        public QuestionService Service { get; set; }

    }
}