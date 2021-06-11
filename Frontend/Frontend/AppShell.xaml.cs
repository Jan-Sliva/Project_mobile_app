using Frontend.ViewModels;
using Frontend.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Frontend
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        public void AddFlyoutItem(FlyoutItem item)
        {
            Items.Add(item);
        }

        public void AddFlyoutItemAtIndex(int index, FlyoutItem item)
        {
            Items.Insert(index, item);
        }

        public void RemoveFlyoutItem(FlyoutItem item)
        {
            Items.Remove(item);
        }

        public void RemoveFlyoutItemAtIndex(int index)
        {
            Items.RemoveAt(index);
        }
    }
}
