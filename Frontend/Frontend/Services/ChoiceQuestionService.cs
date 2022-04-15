using Frontend.Models;
using Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Services
{
    public class ChoiceQuestionService : QuestionService
    {
        private ChoiceQuestion Model;
        public ChoiceQuestionViewModel ViewModel;

        public ChoiceQuestionService(AppShellViewModel appShell, ChoiceQuestion textQuestion)
        {
            Model = textQuestion;
            ViewModel = new ChoiceQuestionViewModel(appShell, textQuestion);
        }

        public override void Ask()
        {
            ViewModel.Ask();
        }

        public override void Hide()
        {
            ViewModel.Hide();
        }
    }
}
