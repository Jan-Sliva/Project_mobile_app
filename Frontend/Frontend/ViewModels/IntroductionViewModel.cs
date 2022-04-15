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
        public IntroductionViewModel(AppShellViewModel appShell, Introduction model)
            : base(appShell, model.Title, "icon_about.png")
        {
            CreateAndAddDisplayObjects(model.DisplayObjects, this.DisplayObjects,
                (ICollection<int>) model.DisplayObjects.Select(x => (int)x.PositionInIntroduction));
            ShowAtPos(0);
        }
    }
}
