using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Frontend.Views;

namespace Frontend.ViewModels
{
    public class TextQuestionViewModel : QuestionViewModel
    {

        private string _answer;

        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }

        public TextQuestion BaseObject { get; }

        public TextQuestionPage TextQuestionPage { get; }

        public TextQuestionViewModel(AppShell appShell, TextQuestion textQuestion)
        {
            this.Question = textQuestion.QuestionText;
            this.BaseObject = textQuestion;
            this.Title = "Otázka " + NumberOfQuestion;
            NumberOfQuestion++;
            this.AppShell = appShell;
            this.ConfirmQuestion = new Command(OnAnswerConfirmed);

            FlyOutItem = new FlyoutItem()
            {
                Title = this.Title,
                Icon = "icon_question.png",
            };

            TextQuestionPage = new TextQuestionPage(this) { Title = this.Title };

            ShellContent = new ShellContent { Content = TextQuestionPage };

            FlyOutItem.Items.Add(ShellContent);

            appShell.AddFlyoutItemAtIndex(2, FlyOutItem);
        }

        public void OnAnswerConfirmed()
        {
            RaiseConfirmedQuestionEvent(this, new ConfirmedTextEventArgs(this.Answer));
            AppShell.RemoveFlyoutItem(this.FlyOutItem);
        }

    }
}
