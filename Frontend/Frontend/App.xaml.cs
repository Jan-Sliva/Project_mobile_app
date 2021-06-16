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

            MainPage = new AppShell();

            var MainGame = new GameService();

            MainGame.LoadAndPlayGame(1, MainPage as AppShell);

            /*
            locationChecker = new LocationChecker();

            var location1 = new LocationToCheck(49.94202651288202, 14.327889264263597, 10);

            location1.LocationReached += OnPositionReached;

            locationChecker.AddLocation(location1);

            var Intro1 = new IntroductionViewModel(MainPage as AppShell);

            var Text1 = new Text() { Title = "Test1", OwnText = "doufám, že to funguje", PositionInIntroduction = 1};

            var Text2 = new Text() { Title = "Test2", OwnText = "hodně doufám, že to funguje", PositionInIntroduction = 0 };

            var Text3 = new Text() { Title = "Test3", OwnText = "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh", PositionInIntroduction = 2 };

            Intro1.AddText(Text1);

            Intro1.AddDisplayObject(Text2);

            Intro1.AddText(Text3);

            var Map1 = new MapViewModel(MainPage as AppShell);

            var MapPos1 = new MapPosition() { Id = 1, Description = "H", Radius = 10, X = 49.94233003080672, Y = 14.338365888204779 };

            var MapPos2 = new MapPosition() { Id = 1, Description = "H2", Radius = 10, X = 49.94387250236016, Y = 14.32606872774059 };

            var PinView1 = Map1.AddMapPosition(MapPos1, PinDisplayType.NOT_STOP, true);

            var PinView2 = Map1.AddMapPosition(MapPos2, PinDisplayType.LOCKED, true);

            PinView1.ColourType = PinDisplayType.UNLOCKED;
            PinView2.ShowCircle = false;

            var Stop1 = new StopViewModel(MainPage as AppShell, "Stanoviště 1");

            var Text4 = new Text() { Title = "Test4", OwnText = "4: doufám, že to funguje", PositionInIntroduction = 1 };

            var Text5 = new Text() { Title = "Test5", OwnText = "5: hodně doufám, že to funguje", PositionInIntroduction = 0 };

            var Password1 = new PasswordGameRequirement() { Question = "Kolik je 1 + 0?" };

            var Password2 = new PasswordGameRequirement() { Question = "Kolik je 2 - 1?" };

            var PasswordView1 = Stop1.AddDisplayObject(Password1, 1);

            (PasswordView1 as GamePasswordViewModel).ConfirmedPasswordEvent += OnPasswordRecieved;

            Stop1.AddDisplayObject(Text4, 2);

            var PasswordView2 = Stop1.AddGamePassword(Password2, 3);

            PasswordView2.ConfirmedPasswordEvent += OnPasswordRecieved;

            Stop1.AddText(Text5, 0);

            new TextQuestionViewModel(MainPage as AppShell, new TextQuestion { QuestionText = "Kolik ti je let?" });
            */
        }

        /*
        public void OnPasswordRecieved(object sender, ConfirmedTextEventArgs e)
        {
            if (e.Text == "1")
            {
                (sender as GamePasswordViewModel).IsDone = true;
                (sender as GamePasswordViewModel).ConfirmedPasswordEvent -= OnPasswordRecieved;
            }
        }
        */

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
