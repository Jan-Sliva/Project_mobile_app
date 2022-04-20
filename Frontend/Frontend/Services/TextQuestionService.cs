using System;
using System.Collections.Generic;
using System.Text;
using Frontend.ViewModels;
using Frontend.Models;
using System.Text.RegularExpressions;

namespace Frontend.Services
{
    public class TextQuestionService : QuestionService
    {
        public TextQuestionViewModel ViewModel;
        public List<TextChoiceService> Choices;
        public DefaultChoiceService DefaultChoice;

        private TextQuestion Model;

        public TextQuestionService(AppShellViewModel appShell, TextQuestion textQuestion)
        {
            Model = textQuestion;

            ViewModel = new TextQuestionViewModel(appShell, textQuestion);

            ViewModel.ConfirmedQuestionEvent += OnConfirm;
        }

        public void OnConfirm(object sender, ConfirmedTextEventArgs e)
        {
            foreach (TextChoiceService choice in Choices)
            {
                if (Correspond(choice.Model, e.Text))
                {
                    choice.Process();
                    Hide();
                    return;
                }
            }

            if (DefaultChoice != null)
            {
                DefaultChoice.Process();
                Hide();
            }
            
        }


        public override void Ask()
        {
            ViewModel.Ask();
        }

        public override void Hide()
        {
            ViewModel.Hide();
        }


        private bool Correspond(ChoiceForTextQuestion password, string text)
        {
            string textToCompare = String.Copy(password.Text);

            if (!(bool)password.DiffUpperCase)
            {
                if (!(bool)password.UseRegex) textToCompare = textToCompare.ToLower();
                text = text.ToLower();
            }

            if (!(bool)password.UseRegex)
            {
                return text == textToCompare;
            }
            else
            {
                var regexToCompare = new Regex(textToCompare);
                return regexToCompare.IsMatch(text);
            }
        }
    }
}
