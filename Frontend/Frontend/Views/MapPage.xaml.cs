using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Frontend.ViewModels;
using Frontend.Models;
using Xamarin.Forms.Maps;
using Frontend.Services;
using System.Threading;
using Frontend.Resources;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : BasePage
    {
        public static MapPage Constructor<T>(PageViewModel<T> viewModel) where T : BasePage
        {
            MapPage page = new MapPage();

            page.Init(viewModel);
            page.InitializeComponent();

            return page;
        }

    }
}
