using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    public abstract class InfoScreenViewModel : BaseViewModel
    {
        protected FlyoutItem FlyoutItem { get; set; }

        protected ShellContent ShellContent { get; set; }

        protected AppShell AppShell { get; set; }

        public ObservableCollection<DisplayObjectViewModel> DisplayObjects { get; protected set; }

        private string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        protected delegate void AddedDisplayObjectEventHandler(object sender, AddedDisplayObjectEventArgs e);

        protected event AddedDisplayObjectEventHandler AddedDisplayObject;

        protected void UpdateDisplayObjects(object sender, AddedDisplayObjectEventArgs e)
        {
            var newDisplayObjects = DisplayObjects.OrderBy(t => t.Position).ToList();
            for (int i = 0; i < newDisplayObjects.Count; i++)
            {
                this.DisplayObjects[i] = newDisplayObjects[i];
            }
        }

        public DisplayObjectViewModel RemoveDisplayObject(DisplayObject objectToRemove)
        {
            foreach (DisplayObjectViewModel displayObject in DisplayObjects)
            {
                if (displayObject.BaseObject == objectToRemove)
                {
                    DisplayObjects.Remove(displayObject);
                    return displayObject;
                }
            }
            return null;
        }

        public void AddDisplayObjectViewModel(DisplayObjectViewModel displayObjectViewModel)
        {
            DisplayObjects.Add(displayObjectViewModel);
            RaiseAddedDisplayObjectEvent(this, displayObjectViewModel);
        }

        public void RemoveDisplayObjectViewModel(DisplayObjectViewModel textViewModel)
        {
            DisplayObjects.Remove(textViewModel);
        }

        protected void RaiseAddedDisplayObjectEvent(InfoScreenViewModel sender, DisplayObjectViewModel displayObjectViewModel)
        {
            AddedDisplayObject(sender, new AddedDisplayObjectEventArgs(displayObjectViewModel));
        }

        public void UpdateDisplayObject(DisplayObjectViewModel item)
        {
            int index = DisplayObjects.IndexOf(item);
            if (index != -1)
            {
                DisplayObjects.Remove(item);
                DisplayObjects.Insert(index, item);
            }
        }
    }

    public class AddedDisplayObjectEventArgs : EventArgs
    {
        private readonly DisplayObjectViewModel displayObjectViewModel;

        public AddedDisplayObjectEventArgs(DisplayObjectViewModel displayObjectVieWModel)
        {
            this.displayObjectViewModel = displayObjectVieWModel;
        }

        public DisplayObjectViewModel Password { get { return displayObjectViewModel; } }
    }
}
