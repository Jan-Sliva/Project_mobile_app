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
    public class AppShellViewModel : BaseViewModel
    {

        public AppShell AppShell { get; set; }

        public AppShellViewModel()
        {
            AppShell = new AppShell(this);
        }

        public void ShowViewModel<T>(PageViewModel<T> viewModel) where T : BasePage
        {
            AppShell.Items.Add(viewModel.FlyoutItem);
        }

        public void ShowAtPosition<T>(PageViewModel<T> viewModel, int pos) where T : BasePage
        {
            AppShell.Items.Insert(pos, viewModel.FlyoutItem);
        }

        public void HideViewModel<T>(PageViewModel<T> viewModel) where T : BasePage
        {
            AppShell.Items.Remove(viewModel.FlyoutItem);
        }

        public void HideAll()
        {
            AppShell.Items.Clear();
        }
    }
}
