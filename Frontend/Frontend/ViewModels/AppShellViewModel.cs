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
        public ObservableCollection<FlyoutItem> FlyoutItems { get; set; }

        private AppShell AppShell { get; set; }

        AppShellViewModel()
        {
            AppShell = new AppShell(this);

            FlyoutItems = new ObservableCollection<FlyoutItem>();
        }

        public void ShowViewModel(PageViewModel viewModel)
        {
            FlyoutItems.Add(viewModel.FlyoutItem);
        }

        public void ShowAtPosition(PageViewModel viewModel, int pos)
        {
            FlyoutItems.Insert(pos, viewModel.FlyoutItem);
        }

        public void HideViewModel(PageViewModel viewModel)
        {
            FlyoutItems.Remove(viewModel.FlyoutItem);
        }
    }
}
