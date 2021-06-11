using Frontend.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Frontend.ViewModels;
using Frontend.Models;

namespace Frontend
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            var Map1 = new MapViewModel(MainPage as AppShell);

            var MapPos1 = new MapPosition() { Id = 1, Description = "H", Radius = 10, X = 49.94233003080672, Y = 14.338365888204779 };

            var MapPos2 = new MapPosition() { Id = 1, Description = "H2", Radius = 10, X = 49.94387250236016, Y = 14.32606872774059 };

            Map1.AddMapPosition(MapPos1, PinDisplayType.NOT_STOP, true);
            Map1.AddMapPosition(MapPos2, PinDisplayType.LOCKED, true);

            var Map2 = new MapViewModel(MainPage as AppShell);

            var Map3 = new MapViewModel(MainPage as AppShell);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
