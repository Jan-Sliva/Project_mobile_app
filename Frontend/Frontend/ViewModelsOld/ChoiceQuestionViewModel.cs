using Frontend.Models;
using Frontend.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace Frontend.ViewModels
{
    public class ChoiceQuestionViewModel : QuestionViewModel
    {
        public ChoiceQuestion BaseObject { get; }

        public ChoiceQuestionPage TextQuestionPage { get; }

        public ObservableCollection<ChoiceForChoiceQuestionViewModel> Choices { get; set; }

        public ChoiceQuestionViewModel(AppShell appShell, ChoiceQuestion choiceQuestion)
        {
            this.Question = choiceQuestion.QuestionText;
            this.BaseObject = choiceQuestion;
            this.Title = "Otázka " + NumberOfQuestion;
            NumberOfQuestion++;
            this.AppShell = appShell;
            this.ConfirmQuestion = new Command(OnAnswerConfirmed);

            Choices = new ObservableCollection<ChoiceForChoiceQuestionViewModel>();

            foreach(ChoiceForChoiceQuestion choice in choiceQuestion.Choices)
            {
                var newChoice = new ChoiceForChoiceQuestionViewModel(this, choice);
                Choices.Add(newChoice);
            }

            FlyOutItem = new FlyoutItem()
            {
                Title = this.Title,
                Icon = "icon_question.png",
            };

            TextQuestionPage = new ChoiceQuestionPage(this) { Title = this.Title };

            ShellContent = new ShellContent { Content = TextQuestionPage };

            FlyOutItem.Items.Add(ShellContent);
        }

        public void Ask()
        {
            AppShell.AddFlyoutItemAtIndex(2, FlyOutItem);
        }

        public void RemoveFromBar()
        {
            AppShell.RemoveFlyoutItem(this.FlyOutItem);
        }

        public void OnAnswerConfirmed()
        {
            var chosenAnswer = Choices.Where(cha => cha.IsChosen).FirstOrDefault();
            RaiseConfirmedQuestionEvent(this, new ConfirmedTextEventArgs(chosenAnswer.ChoiceText));
            AppShell.RemoveFlyoutItem(this.FlyOutItem);
        }

        public void SetAllOtherToFalse(ChoiceForChoiceQuestionViewModel choiceNotFalse)
        {
            foreach(ChoiceForChoiceQuestionViewModel choice in Choices)
            {
                choice.IsChosen = (choice == choiceNotFalse);
            }
        }
    }
}
