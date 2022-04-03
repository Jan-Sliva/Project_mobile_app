using Frontend.Smart;
using Frontend.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    // controls flyout items
    public class AppShellViewModel
    {
        public SmartCollection<FlyoutItem> FlyoutItems { get; set; }

        private AppShell AppShell { get; set; }

        AppShellViewModel()
        {
            AppShell = new AppShell(this);

            FlyoutItems = new SmartCollection<FlyoutItem>();
        }

        public void ShowViewModel<T>(PageViewModel<T> viewModel) where T : BasePage
        {
            FlyoutItems.Add(viewModel.FlyoutItem);
        }

        public void ShowAtPosition<T>(PageViewModel<T> viewModel, int pos) where T : BasePage
        {
            FlyoutItems.Insert(pos, viewModel.FlyoutItem);
        }

        public void HideViewModel<T>(PageViewModel<T> viewModel) where T : BasePage
        {
            FlyoutItems.Remove(viewModel.FlyoutItem);
        }
    }
}
