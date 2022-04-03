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
    public abstract class InfoScreenViewModel<T> : PageViewModel<T> where T : BasePage
    {
        public SmartCollection<DisplayObjectViewModel<T>> DisplayObjects { get; set; }

        public InfoScreenViewModel(AppShellViewModel appShell) : base(appShell)
        {
            DisplayObjects = new SmartCollection<DisplayObjectViewModel<T>>();
        }

        public void AddDisplayObject(DisplayObjectViewModel<T> displayObject)
        {
            DisplayObjects.Insert(displayObject.Position, displayObject);
        }

        public void RemoveDisplayObject(DisplayObjectViewModel<T> displayObject)
        {
            DisplayObjects.Remove(displayObject);
        }

        public void AddDisplayObjects(ICollection<DisplayObjectViewModel<T>> displayObjects)
        {
            foreach (DisplayObjectViewModel<T> displayObject in displayObjects)
            {
                this.AddDisplayObject(displayObject);
            }
        }

        public void RemoveDisplayObjects(ICollection<DisplayObjectViewModel<T>> displayObjects)
        {
            foreach (DisplayObjectViewModel<T> displayObject in displayObjects)
            {
                this.RemoveDisplayObject(displayObject);
            }
        }
    }
}
