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
            foreach (ChoiceStop opening in choice.OpensStops)
            {
                opening.Opens.Service.ProcessChange(opening.IfUnvisible, opening.IfVisible, opening.IfUnlocked, (int)opening.Value);
            }

            MapService.AddNotStops(choice.OpensMapPositions as List<MapPosition>);

            foreach (Question question in choice.OpensQuestions)
            {
                question.Service.Ask();
            }
        }
    }
}
