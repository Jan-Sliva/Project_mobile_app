using Frontend.Models;
using Frontend.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using Frontend.Smart;

namespace Frontend.ViewModels
{
    public class ChoiceQuestionViewModel : QuestionViewModel<ChoiceQuestionPage>
    {

        public SmartCollection<ChoiceForChoiceQuestionViewModel> Choices { get; set; }

        public ChoiceQuestionViewModel(AppShellViewModel appShell, ChoiceQuestion choiceQuestion) : base(appShell, choiceQuestion)
        {
            Choices = new SmartCollection<ChoiceForChoiceQuestionViewModel>();

            //foreach(ChoiceForChoiceQuestion choice in choiceQuestion.Choices)
            //{
            //    var newChoice = new ChoiceForChoiceQuestionViewModel(this, choice);
            //    Choices.Add(newChoice);
            //}
        }

        public void Ask()
        {
            SetAllToFalse();
            Show();
        }

        public override void OnAnswerConfirmed()
        {
            var chosenAnswer = Choices.Where(cha => cha.IsChosen).FirstOrDefault();
            if (chosenAnswer != null)
            {
                chosenAnswer.RaiseChoiceSubmitted();
                Hide();
            }
        }

        public void SetAllOtherToFalse(ChoiceForChoiceQuestionViewModel choiceNotFalse)
        {
            foreach(ChoiceForChoiceQuestionViewModel choice in Choices)
            {
                choice.IsChosen = (choice == choiceNotFalse);
            }
        }

        public void SetAllToFalse()
        {
            foreach(ChoiceForChoiceQuestionViewModel choice in Choices)
            {
                choice.IsChosen = false;
            }
        }
    }
}
