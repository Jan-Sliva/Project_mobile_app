using Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Frontend.Views
{
    public class BasePage : ContentPage
    {
        public void Init<T>(PageViewModel<T> viewModel) where T : BasePage
        {
            this.BindingContext = viewModel;
        }
    }
}
