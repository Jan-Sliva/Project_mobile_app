using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Collections.Specialized;

namespace Frontend.ViewModels
{
    public class GamePasswordViewModel : DisplayObjectViewModel
    {
        private string _enteredPassword;

        public string EnteredPassword
        {
            get { return _enteredPassword; }
            set { _enteredPassword = value; }
        }

        private bool _isDone;

        public bool IsDone
        {
            get { return _isDone; }
            set { SetProperty(ref _isDone, value); }
        }

        public Command ConfirmPassword { get; }

        public GamePasswordViewModel(InfoScreenViewModel infoScreenViewModel, PasswordGameRequirement password, int position)
        {
            this.Title = password.Question;
            this.Position = position;
            this.BaseObject = password;
            this.IsDone = false;
            this.ConfirmPassword = new Command(OnPasswordConfirm);
            this.InfoScreenViewModel = infoScreenViewModel;

            this.PropertyChanged += (_, __) => InfoScreenViewModel.UpdateDisplayObject(this);
        }

        public event ConfirmedPasswordEventHandler ConfirmedPasswordEvent;

        public delegate void ConfirmedPasswordEventHandler(GamePasswordViewModel sender, GamePasswordEventArgs e);

        public void OnPasswordConfirm()
        {
            ConfirmedPasswordEvent(this, new GamePasswordEventArgs(this.EnteredPassword));
            SetProperty(ref _enteredPassword, "");
        }
    }

    public class GamePasswordEventArgs : EventArgs
    {
        private readonly string password;

        public GamePasswordEventArgs(string password)
        {
            this.password = password;
        }

        public string Password { get { return password; } }
    }
}
