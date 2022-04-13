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
        public bool IsChosen { get => _isChosen; set => SetProperty(ref _isChosen, value); }

        private string _choiceText;
        public string ChoiceText { get => _choiceText; set => SetProperty(ref _choiceText, value); }

        public ChoiceQuestionViewModel ChoiceQuestion { get; private set; }

        public delegate void ChoiceEventHandler(object sender, EventArgs e);

        public event ChoiceEventHandler ChoiceSubmitted;

        public void RaiseChoiceSubmitted()
        {
            ChoiceSubmitted.Invoke(this, EventArgs.Empty);
        }

        public ChoiceForChoiceQuestionViewModel(ChoiceQuestionViewModel choiceQuestion, ChoiceForChoiceQuestion choiceForChoiceQuestion)
        {
            ChoiceQuestion = choiceQuestion;
            ChoiceText = choiceForChoiceQuestion.Text;
            _isChosen = false;
        }

        protected new void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(IsChosen))
            {
                OnCheckBoxChanged();
            }
        }

        public void OnCheckBoxChanged()
        {
            if (IsChosen) ChoiceQuestion.SetAllOtherToFalse(this);
        }
    }
}
