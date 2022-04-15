using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Models;
using Frontend.ViewModels;
using System.Text.RegularExpressions;

namespace Frontend.Services
{
    public class PasswordService
    {
        PasswordGameRequirement Model;

        public GamePasswordViewModel ViewModel;

        public event EventHandler PasswordCompleted;

        public PasswordService(PasswordGameRequirement model)
        {
            Model = model;

            ViewModel = new GamePasswordViewModel(model, 0);

            ViewModel.ConfirmedPasswordEvent += OnPasswordRecieved;
        }

        public void OnPasswordRecieved(object sender, ConfirmedTextEventArgs e)
        {
            if (Model.Passwords != null)
            {
                foreach (GamePassword password in Model.Passwords)
                {
                    if (Correspond(password, e.Text))
                    {
                        ViewModel.IsDone = true;
                        PasswordCompleted?.Invoke(this, EventArgs.Empty);
                        return;
                    }
                }
            }
        }

        private bool Correspond(GamePassword password, string text)
        {
            string textToCompare = String.Copy(password.Password);

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

        public void AskForPassword()
        {
            ViewModel.IsDone = false;
        }

        public void Unshow()
        {
            ViewModel.IsDone = true;
        }
    }
}
