using System;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    public abstract class PageViewModel : BaseViewModel
    {
        public ContentPage Page { get; set; }

        public string Title { get; set; }

        public string IconFileName { get; set; }

        public FlyoutItem FlyoutItem { get; set; }

        public ShellContent ShellContent { get; set; }

        public AppShellViewModel AppShell { get; set; }

        public void UpdateFlyOutItem()
        {
            FlyoutItem.Title = Title;
            FlyoutItem.Icon = IconFileName;
        }

        public void SetUpFlyOutItem()
        {
            FlyoutItem = new FlyoutItem()
            {
                Title = this.Title,
                Icon = IconFileName,
            };

            ShellContent = new ShellContent { Content = this.Page };

            FlyoutItem.Items.Add(ShellContent);
        }

        public void Show()
        {
            AppShell.ShowViewModel(this);
        }

        public void Hide()
        {
            AppShell.HideViewModel(this);
        }

        public void ShowAtPos(int pos)
        {
            AppShell.ShowAtPosition(this, pos);
        }
    }
}
