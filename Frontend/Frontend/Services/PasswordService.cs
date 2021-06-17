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
        PasswordGameRequirement Model { get; set; }

        StopService StopService { get; set; }

        GamePasswordViewModel PasswordViewModel { get; set; }

        private bool isVisible = false;

        public event EventHandler PasswordCompleted;

        public PasswordService(StopService stopService, PasswordGameRequirement model)
        {
            StopService = stopService;
            Model = model;

            PasswordViewModel = new GamePasswordViewModel(StopService.ViewModel, model);

            PasswordViewModel.ConfirmedPasswordEvent += OnPasswordRecieved;
        }

        public void OnPasswordRecieved(object sender, ConfirmedTextEventArgs e)
        {
            if (Model.Passwords != null)
            {
                foreach (GamePassword password in Model.Passwords)
                {
                    if (Correspond(password, e.Text))
                    {
                        PasswordCompleted?.Invoke(this, EventArgs.Empty);
                        PasswordViewModel.IsDone = true;
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
            PasswordViewModel.IsDone = false;
            Show();
        }

        public void Show()
        {
            if (!isVisible)
            {
                StopService.ViewModel.AddPasswordViewModel(PasswordViewModel);
                isVisible = true;
            }
        }

        public void Unshow()
        {
            if (isVisible)
            {
                StopService.ViewModel.RemovePasswordViewModel(PasswordViewModel);
                isVisible = false;
            }
        }
    }
}
