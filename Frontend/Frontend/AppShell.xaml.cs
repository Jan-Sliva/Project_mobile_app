using Frontend.ViewModels;
using Frontend.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Frontend
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell(AppShellViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            this.SetBinding(ItemsProperty, "FlyOutItems");
        }
    }
}
