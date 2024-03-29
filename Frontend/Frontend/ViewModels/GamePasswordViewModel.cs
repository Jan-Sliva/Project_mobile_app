﻿using Frontend.Models;
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
        public string EnteredPassword { get => _enteredPassword; set => SetProperty(ref _enteredPassword, value); }

        private bool _isDone;
        public bool IsDone { get => _isDone; set => SetProperty(ref _isDone, value); }

        public Command ConfirmPassword { get; }

        public GamePasswordViewModel(PasswordGameRequirement password, int position = 0) : base(position)
        {
            this.Title = password.Question;
            this.IsDone = false;
            this.EnteredPassword = "";
            this.ConfirmPassword = new Command(OnPasswordConfirm);
        }

        protected override void OnPropertyChanged(string propertyName)
        {

            if (propertyName == nameof(IsDone))
            {
                if (!_isDone) EnteredPassword = "";
            }

            base.OnPropertyChanged(propertyName);
        }

        public event ConfirmedPasswordEventHandler ConfirmedPasswordEvent;

        public delegate void ConfirmedPasswordEventHandler(GamePasswordViewModel sender, ConfirmedTextEventArgs e);

        public void OnPasswordConfirm()
        {
            ConfirmedPasswordEvent?.Invoke(this, new ConfirmedTextEventArgs(this.EnteredPassword));
            EnteredPassword = "";
        }
    }


}
