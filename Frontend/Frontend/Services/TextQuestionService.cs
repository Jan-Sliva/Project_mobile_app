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
        public TextQuestion Model { get; }

        public TextQuestionViewModel ViewModel { get; }

        public TextQuestionService(AppShell appShell, TextQuestion textQuestion, MapService mapService)
        {
            Model = textQuestion;

            Model.Service = this;

            MapService = mapService;

            ViewModel = new TextQuestionViewModel(appShell, textQuestion);

            ViewModel.ConfirmedQuestionEvent += OnConfirm;
        }

        public void OnConfirm(object sender, ConfirmedTextEventArgs e)
        {
            if (Model.Choices != null)
            {
                foreach (ChoiceForTextQuestion choice in Model.Choices)
                {
                    if (Correspond(choice, e.Text))
                    {
                        ProcessChoice(choice);
                        return;
                    }
                }
            }

            if (Model.DefaultChoice != null) ProcessChoice(Model.DefaultChoice);
        }


        public override void Ask()
        {
            ViewModel.Ask();
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
