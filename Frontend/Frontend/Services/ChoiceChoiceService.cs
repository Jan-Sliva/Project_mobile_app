using Frontend.Models;
using Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Services
{
    public class ChoiceChoiceService : ChoiceService
    {
        private ChoiceForChoiceQuestionViewModel ViewModel;
        private ChoiceQuestionService ChoiceQuestion;
        public ChoiceForChoiceQuestion Model;

        public ChoiceChoiceService(ChoiceQuestionService choiceQuestion, ChoiceForChoiceQuestion choiceForChoiceQuestion, MapViewModel map) 
            : base(choiceForChoiceQuestion, map)
        {
            ViewModel = new ChoiceForChoiceQuestionViewModel(choiceQuestion.ViewModel, choiceForChoiceQuestion);
            ViewModel.ChoiceSubmitted += OnSubmitted;
            ChoiceQuestion = choiceQuestion;
            Model = choiceForChoiceQuestion;
        }

        private void OnSubmitted(object sender, EventArgs e)
        {
            Process();
            ChoiceQuestion.Hide();
        }
    }
}
