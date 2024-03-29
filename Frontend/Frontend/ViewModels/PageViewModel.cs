﻿using Frontend.Views;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    public abstract class PageViewModel<T> : BaseViewModel where T : BasePage
    {
        private string _title;
        public string Title { get => _title; set => SetProperty(ref _title, value); }

        private string _iconFileName;
        public string IconFileName { get => _iconFileName; set => SetProperty(ref _iconFileName, value); }

        public T Page { get; protected set; }

        public FlyoutItem FlyoutItem { get; protected set; }

        public ShellContent ShellContent { get; protected set; }

        public AppShellViewModel AppShell { get; protected set; }

        private bool _isVisible = false;

        public PageViewModel(AppShellViewModel appShell, string title, string iconFileName)
        {
            this.AppShell = appShell;

            FlyoutItem = new FlyoutItem();

            Title = title;
            IconFileName = iconFileName;

            this.Page = (T)Activator.CreateInstance(typeof(T), new object[] { this });

            ShellContent = new ShellContent { Content = this.Page };

            FlyoutItem.Items.Add(ShellContent);
        }

        protected override void OnPropertyChanged(string propertyName)
        {

            if (propertyName == nameof(Title))
            {
                UpdateTitle();
            }
            else if (propertyName == nameof(IconFileName))
            {
                UpdateIcon();
            }

            base.OnPropertyChanged(propertyName);
        }

        public void UpdateTitle()
        {
            if (Title != null) FlyoutItem.Title = Title;
        }

        public void UpdateIcon()
        {
            if (IconFileName != null) FlyoutItem.Icon = IconFileName;
        }

        public void Show()
        {
            if (!_isVisible) AppShell.ShowViewModel(this);

            _isVisible = true;
        }

        public void Hide()
        {
            if (_isVisible) AppShell.HideViewModel(this);

            _isVisible = false;
        }

        public void ShowAtPos(int pos)
        {
            Hide();
            AppShell.ShowAtPosition(this, pos);
            _isVisible = true;
        }
    }
}
