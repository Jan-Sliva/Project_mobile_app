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
        
        public IntroPage IntroPage { get; }

        public IntroductionViewModel(AppShell appShell, string title = "Úvod")
        {
            this.Title = title;

            AppShell = appShell;

            DisplayObjects = new ObservableCollection<DisplayObjectViewModel>();

            AddedDisplayObject += UpdateDisplayObjects;

            FlyoutItem = new FlyoutItem()
            {
                Title = this.Title,
                Icon = "icon_about.png",
            };

            IntroPage = new IntroPage(this) { Title = this.Title };

            ShellContent = new ShellContent { Content = IntroPage };

            FlyoutItem.Items.Add(ShellContent);

            AddToBar();
        }


        public void AddToBar()
        {
            AppShell.AddFlyoutItemAtIndex(0, FlyoutItem);
        }

        public void RemoveFromBar()
        {
            AppShell.RemoveFlyoutItem(this.FlyoutItem);
        }

        public DisplayObjectViewModel AddDisplayObject(DisplayObject displayObject)
        {
            if (displayObject.GetType().Equals(typeof(Text)))
            {
                return AddText(displayObject as Text);
            }
            else if (displayObject.GetType().Equals(typeof(Picture)))
            {
                return AddPicture(displayObject as Picture);
            }
            return null;
        }

        public TextViewModel AddText(Text text)
        {
            var addedText = new TextViewModel(this, text, (int)text.PositionInIntroduction);
            DisplayObjects.Add(addedText);
            RaiseAddedDisplayObjectEvent(this, addedText);
            return addedText;
        }

        public PictureViewModel AddPicture(Picture picture)
        {
            var addedPicture = new PictureViewModel(this, picture, (int)picture.PositionInIntroduction);
            DisplayObjects.Add(addedPicture);
            RaiseAddedDisplayObjectEvent(this, addedPicture);
            return addedPicture;
        }
    }
}
