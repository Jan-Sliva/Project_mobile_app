using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Frontend.Views;

namespace Frontend.ViewModels
{
    public class TextQuestionViewModel : QuestionViewModel<TextQuestionPage>
    {

        private string _answer;
        public string Answer { get => _answer; set => SetProperty(ref _answer, value); }

        public TextQuestionViewModel(AppShellViewModel appShell, TextQuestion textQuestion) :
            base(appShell, textQuestion)
        { }

        public event ConfirmedQuestionEventHandler ConfirmedQuestionEvent;

        public delegate void ConfirmedQuestionEventHandler(TextQuestionViewModel sender, ConfirmedTextEventArgs e);

        protected void RaiseConfirmedQuestionEvent(TextQuestionViewModel sender, ConfirmedTextEventArgs e)
        {
            ConfirmedQuestionEvent?.Invoke(sender, e);
        }
        public override void OnAnswerConfirmed()
        {
            RaiseConfirmedQuestionEvent(this, new ConfirmedTextEventArgs(this.Answer));
            Hide();
        }

        public override void Ask()
        {
            Answer = "";
            ShowAtPos(2);
        }

    }
}
