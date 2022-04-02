using Frontend.Models;
using Frontend.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    public class InfoScreenViewModel : PageViewModel
    {

        public ObservableCollection<DisplayObjectViewModel> DisplayObjects { get; set; }

        public InfoScreenViewModel()
        {
            this.Title = "*extrémní*";

            this.IconFileName = "icon_stop.png";

            this.Page = new InfoScreenPage(this);

            SetUpFlyOutItem();

            DisplayObjects = new ObservableCollection<DisplayObjectViewModel>();

            //AddedDisplayObject += UpdateDisplayObjects;
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
