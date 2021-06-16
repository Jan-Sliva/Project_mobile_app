using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        public string Question { get; protected set; }
        public Command ConfirmQuestion { get; protected set; }

        protected AppShell AppShell { get; set;  }

        protected FlyoutItem FlyOutItem { get; set; }

        protected ShellContent ShellContent { get; set; }

        public string Title { get; protected set; }

        public static int NumberOfQuestion = 1;

        public event ConfirmedQuestionEventHandler ConfirmedQuestionEvent;

        public delegate void ConfirmedQuestionEventHandler(QuestionViewModel sender, ConfirmedTextEventArgs e);

        protected void RaiseConfirmedQuestionEvent(QuestionViewModel sender, ConfirmedTextEventArgs e)
        {
            ConfirmedQuestionEvent?.Invoke(sender, e);
        }
    }
}
