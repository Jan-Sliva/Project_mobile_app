using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Models;
using Frontend.ViewModels;
using Frontend.Services;

namespace Frontend.Services
{
    public abstract class QuestionService
    {
        public abstract void Ask();

        protected MapService MapService { get; set; }

        protected void ProcessChoice(Choice choice)
        {
            if (choice.OpensStops != null)
            {
                foreach (ChoiceStop opening in choice.OpensStops)
                {
                    opening.Opens.Service.ProcessChange(opening.IfUnvisible, opening.IfVisible, opening.IfUnlocked, (int)opening.Value);
                }
            }

            if (choice.OpensMapPositions != null) MapService.AddNotStops(choice.OpensMapPositions as List<MapPosition>);

            if (choice.OpensQuestions != null)
            {
                foreach (Question question in choice.OpensQuestions)
                {
                    question.Service.Ask();
                }
            }
        }
    }
}
