using Frontend.Views;
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

        public BasePage Page { get; protected set; }

        public FlyoutItem FlyoutItem { get; protected set; }

        public ShellContent ShellContent { get; protected set; }

        public AppShellViewModel AppShell { get; protected set; }

        private bool _isVisible = false;

        public PageViewModel(AppShellViewModel appShell)
        {
            this.AppShell = appShell;

            this.Page = (T)Activator.CreateInstance(typeof(T), new object[] { this });

            FlyoutItem = new FlyoutItem()
            {
                Title = this.Title,
                Icon = IconFileName,
            };

            ShellContent = new ShellContent { Content = this.Page };

            FlyoutItem.Items.Add(ShellContent);
        }

        public void ChangedProperty(object sender, PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName;

            if (propertyName == nameof(Title) || propertyName == nameof(IconFileName))
            {
                UpdateFlyoutItem();
            }
        }

        public void UpdateFlyoutItem()
        {
            FlyoutItem.Title = Title;
            FlyoutItem.Icon = IconFileName;
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
