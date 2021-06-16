using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Models;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    public class ChoiceForChoiceQuestionViewModel : BaseViewModel
    {
        private bool _isChosen = false;

        public bool IsChosen
        {
            get { return _isChosen; }
            set { SetProperty(ref _isChosen, value, onChanged : OnCheckBoxChanged); }
        }

        public string ChoiceText { get; private set; }

        public ChoiceForChoiceQuestion choiceForChoiceQuestion;

        public ChoiceQuestionViewModel ChoiceQuestion { get; private set; }

        public ChoiceForChoiceQuestionViewModel(ChoiceQuestionViewModel choiceQuestion, ChoiceForChoiceQuestion choiceForChoiceQuestion)
        {
            ChoiceQuestion = choiceQuestion;
            ChoiceText = choiceForChoiceQuestion.Text;
        }

        public void OnCheckBoxChanged()
        {
            if (IsChosen) ChoiceQuestion.SetAllOtherToFalse(this);
        }
    }
}
