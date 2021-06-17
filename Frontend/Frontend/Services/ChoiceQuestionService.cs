using Frontend.Models;
using Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Services
{
    public class ChoiceQuestionService : QuestionService
    {
        public ChoiceQuestion Model { get; }

        public ChoiceQuestionViewModel ViewModel { get; }

        public ChoiceQuestionService(AppShell appShell, ChoiceQuestion textQuestion, MapService mapService)
        {
            Model = textQuestion;

            Model.Service = this;

            MapService = mapService;

            ViewModel = new ChoiceQuestionViewModel(appShell, textQuestion);

            ViewModel.ConfirmedQuestionEvent += OnConfirm;
        }

        public void OnConfirm(object sender, ConfirmedTextEventArgs e)
        {
            foreach (ChoiceForChoiceQuestion choice in Model.Choices)
            {
                if (choice.Text == e.Text)
                {
                    ProcessChoice(choice);
                    return;
                }
            }
        }


        public override void Ask()
        {
            ViewModel.Ask();
        }
    }
}
