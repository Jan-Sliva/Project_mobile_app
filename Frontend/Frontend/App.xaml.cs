using Frontend.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Frontend.ViewModels;
using Frontend.Models;
using System.Collections.Generic;
using Frontend.RestClient;
using System.Threading;
using Frontend.RestClient.Mapping;
using Frontend.RestClient.Resources.GameResources.FullGame;
using Frontend.Services;

namespace Frontend
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var MainViewModel = new AppShellViewModel();

            var MainGame = new GameService();

            MainGame.LoadAndPlayGame(1, MainViewModel);

            MainPage = MainViewModel.AppShell;

            Console.WriteLine("App is ready.");

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
