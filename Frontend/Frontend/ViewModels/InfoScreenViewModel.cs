using Frontend.Models;
using Frontend.Smart;
using Frontend.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    public abstract class InfoScreenViewModel : PageViewModel<InfoScreenPage>
    {
        public SmartCollection<DisplayObjectViewModel> DisplayObjects { get; set; }

        public InfoScreenViewModel(AppShellViewModel appShell,  string title, string iconFileName)
            : base(appShell, title, iconFileName)
        {
            DisplayObjects = new SmartCollection<DisplayObjectViewModel>();
        }

        public void AddDisplayObject(DisplayObjectViewModel displayObject)
        {
            DisplayObjects.Insert(displayObject.Position, displayObject);
        }

        public void RemoveDisplayObject(DisplayObjectViewModel displayObject)
        {
            DisplayObjects.Remove(displayObject);
        }

        public void AddDisplayObjects(ICollection<DisplayObjectViewModel> displayObjects)
        {
            foreach (DisplayObjectViewModel displayObject in displayObjects)
            {
                this.AddDisplayObject(displayObject);
            }
        }

        public void RemoveDisplayObjects(ICollection<DisplayObjectViewModel> displayObjects)
        {
            foreach (DisplayObjectViewModel displayObject in displayObjects)
            {
                this.RemoveDisplayObject(displayObject);
            }
        }
    }
}
