using Frontend.Models;
using Frontend.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    public abstract class QuestionViewModel<T> : PageViewModel<T> where T : BasePage
    {
        private string _question;
        public string Question { get => _question; set => SetProperty(ref _question, value); }
        
        public Command ConfirmQuestion { get; protected set; }

        private static int NumberOfQuestion = 1;

        protected QuestionViewModel(AppShellViewModel appShell, Question question) : base(appShell)
        {
            this.Question = question.QuestionText;
            this.Title = "Otázka " + NumberOfQuestion;
            NumberOfQuestion++;
            this.ConfirmQuestion = new Command(OnAnswerConfirmed);
        }

        public abstract void OnAnswerConfirmed();
    }
}
