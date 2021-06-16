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
    public class StopViewModel : InfoScreenViewModel
    {
        public StopPage StopPage { get; }

        public StopViewModel(AppShell appShell, string title)
        {
            this.Title = title;

            AppShell = appShell;

            DisplayObjects = new ObservableCollection<DisplayObjectViewModel>();

            AddedDisplayObject += UpdateDisplayObjects;

            FlyoutItem = new FlyoutItem()
            {
                Title = this.Title,
                Icon = "icon_stop.png",
            };

            StopPage = new StopPage(this) { Title = this.Title };

            ShellContent = new ShellContent { Content = StopPage };

            FlyoutItem.Items.Add(ShellContent);
        }


        public void AddToBar()
        {
            AppShell.AddFlyoutItemAtIndex(2, FlyoutItem);
        }

        public void RemoveFromBar()
        {
            AppShell.RemoveFlyoutItem(this.FlyoutItem);
        }

        public DisplayObjectViewModel AddDisplayObject(object objectToDisplay, int position)
        {
            if (objectToDisplay.GetType().Equals(typeof(Text)))
            {
                return AddText(objectToDisplay as Text, position);
            }
            else if (objectToDisplay.GetType().Equals(typeof(Picture)))
            {
                return AddPicture(objectToDisplay as Picture, position);
            }
            else if (objectToDisplay.GetType().Equals(typeof(PasswordGameRequirement)))
            {
                return AddGamePassword(objectToDisplay as PasswordGameRequirement, position);
            }
            return null;
        }

        public GamePasswordViewModel AddGamePassword(PasswordGameRequirement gamePasword, int position)
        {
            var addedPassword = new GamePasswordViewModel(this, gamePasword, position);
            DisplayObjects.Add(addedPassword);
            RaiseAddedDisplayObjectEvent(this, addedPassword);
            return addedPassword;
        }

        public void AddPasswordViewModel(GamePasswordViewModel passwordToAdd)
        {
            DisplayObjects.Add(passwordToAdd);
            RaiseAddedDisplayObjectEvent(this, passwordToAdd);
        }

        public void RemovePasswordViewModel(GamePasswordViewModel passwordToRemove)
        {
            DisplayObjects.Remove(passwordToRemove);
        }

        public TextViewModel AddText(Text text, int position)
        {
            var addedText = new TextViewModel(this, text, position);
            DisplayObjects.Add(addedText);
            RaiseAddedDisplayObjectEvent(this, addedText);
            return addedText;
        }

        public PictureViewModel AddPicture(Picture picture, int position)
        {
            var addedPicture = new PictureViewModel(this, picture, position);
            DisplayObjects.Add(addedPicture);
            RaiseAddedDisplayObjectEvent(this, addedPicture);
            return addedPicture;
        }
    }
}
