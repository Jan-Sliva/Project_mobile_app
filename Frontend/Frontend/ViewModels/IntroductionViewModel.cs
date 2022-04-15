using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Frontend.Models;
using Frontend.Views;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Specialized;

namespace Frontend.ViewModels
{
    public class IntroductionViewModel : InfoScreenViewModel
    {
        public IntroductionViewModel(AppShellViewModel appShell)
            : base(appShell, "Úvod", "icon_about.png")
        {

            ShowAtPos(0);
        }
    }
}
