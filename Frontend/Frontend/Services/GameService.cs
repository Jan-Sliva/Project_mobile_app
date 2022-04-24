using Frontend.Models;
using Frontend.RestClient.Mapping;
using Frontend.ViewModels;
using System;
using System.Collections.Generic;

namespace Frontend.Services
{
    public class GameService
    {
        Game Model { get; set; }
        AppShellViewModel AppShell { get; set; }
        LocationChecker LocationChecker { get; set; }
        IntroductionViewModel Introduction { get; set; }
        DateTime StartingTime { get; set; }
        TimeSpan LengthOfThisGame { get; set; }
        MapViewModel MapViewModel { get; set; }
        Dictionary<Stop, StopService> buildingStops = new Dictionary<Stop, StopService>();
        Dictionary<ChoiceQuestion, ChoiceQuestionService> buildingChoiceQuestions = new Dictionary<ChoiceQuestion, ChoiceQuestionService>();
        Dictionary<TextQuestion, TextQuestionService> buildingTextQuestions = new Dictionary<TextQuestion, TextQuestionService>();
        Dictionary<StopOpening, UnlockStopService> buildingUnlockStops = new Dictionary<StopOpening, UnlockStopService>();

        public async void LoadAndPlayGame(int id, AppShellViewModel appShell)
        {
            var restClient = new RestClient.RestClient();
            var gameResource = await restClient.GetFullGameByIdAsync(id);
            var converter = new FullGameConverter();
            var game = converter.Convert(gameResource);
            LocationChecker = new LocationChecker();
            AppShell = appShell;
            Model = game;

            Introduction = new IntroductionViewModel(AppShell, Model.Introduction);
            MapViewModel = new MapViewModel(appShell);

            Text InfoAboutGame = new Text()
            {
                Title = "Hráči, kteří se podíleli na této hře",
                OwnText = "",
                PositionInIntroduction = 0
            };
            foreach (User user in Model.Owners)
            {
                InfoAboutGame.OwnText = InfoAboutGame.OwnText + user.UserName + " ";
            }

            Introduction.CreateAndAdd(InfoAboutGame, (int)InfoAboutGame.PositionInIntroduction);

            if (Model.Introduction.MapPositions != null)
            {
                foreach (MapPosition pos in Model.Introduction.MapPositions)
                {
                    new PinViewModel(MapViewModel, pos, PinDisplayType.NOT_STOP);
                }
            }

            StartingTime = DateTime.UtcNow;

            foreach (Stop stop in Model.Stops)
            {
                SetUpStopModel(stop);
            }

        }

        public void End()
        {
            AppShell.HideAll();

            LengthOfThisGame = StartingTime - DateTime.UtcNow;

            var EndInfo = new IntroductionViewModel(AppShell, new Introduction() { Title = "Konec"});

            if (LengthOfThisGame.Minutes <= Model.Limit.Minutes)
            {

                var EndText = new Text() { Title = "Úspěšně jsi dokončil hru", OwnText = "Hra ti trvala " + LengthOfThisGame.Minutes + " minut. "
                                           + "Limit byl " + Model.Limit.Minutes + " minut.", PositionInIntroduction = 0 };

                EndInfo.CreateAndAdd(EndText, (int)EndText.PositionInIntroduction);
            }
            else
            {
                var EndText = new Text()
                {
                    Title = "Hru jsi nestihnul v limitu",
                    OwnText = "Hra ti trvala " + LengthOfThisGame.Minutes + " minut. "
                                           + "Limit byl " + Model.Limit.Minutes + " minut.",
                    PositionInIntroduction = 0
                };

                EndInfo.CreateAndAdd(EndText, (int)EndText.PositionInIntroduction);
            }

        }

        private StopService SetUpStopModel(Stop stopModel)
        {
            if (buildingStops.TryGetValue(stopModel, out StopService stopService))
            {
                return stopService;
            }
            else
            {
                List<PasswordService> passwordServices = new List<PasswordService>();
                foreach(PasswordGameRequirement password in stopModel.Passwords)
                {
                    passwordServices.Add(new PasswordService(password));
                }

                var ret = new StopService(stopModel, AppShell, MapViewModel, LocationChecker, this, passwordServices);
                buildingStops[stopModel] = ret;
                foreach (Question question in stopModel.Questions)
                {
                    if (question is ChoiceQuestion choiceQuestion)
                    {
                        var questionService = SetUpChoiceQuestion(choiceQuestion);
                        ret.OpenQuestions.Add(questionService);
                    }
                    else if (question is TextQuestion textQuestion)
                    {
                        var questionService = SetUpTextQuestion(textQuestion);
                        ret.OpenQuestions.Add(questionService);
                    }
                }

                foreach (StopStop stopStop in stopModel.Opens)
                {
                    var unlockStop = SetUpUnlockStopService(stopStop);
                    ret.OpenStops.Add(unlockStop);
                }

                return ret;
            }
        }

        private UnlockStopService SetUpUnlockStopService(StopOpening unlockStopModel)
        {
            if (buildingUnlockStops.TryGetValue(unlockStopModel, out UnlockStopService unlockService))
            {
                return unlockService;
            }
            else
            {
                var stopService = SetUpStopModel(unlockStopModel.Opens);
                var ret = new UnlockStopService(unlockStopModel, stopService);
                buildingUnlockStops[unlockStopModel] = ret;
                return ret;
            }
        }

        private ChoiceQuestionService SetUpChoiceQuestion(ChoiceQuestion questionModel)
        {
            if (buildingChoiceQuestions.TryGetValue(questionModel, out ChoiceQuestionService questionService))
            {
                return questionService;
            }
            else
            {
                var ret = new ChoiceQuestionService(AppShell, questionModel);
                buildingChoiceQuestions[questionModel] = ret;

                foreach(ChoiceForChoiceQuestion choice in questionModel.Choices)
                {
                    new ChoiceChoiceService(ret, choice, MapViewModel);
                }

                return ret;
            }
        }

        private TextQuestionService SetUpTextQuestion(TextQuestion questionModel)
        {
            if (buildingTextQuestions.TryGetValue(questionModel, out TextQuestionService textQuestionService))
            {
                return textQuestionService;
            }
            else
            {
                var ret = new TextQuestionService(AppShell, questionModel);
                buildingTextQuestions[questionModel] = ret;

                foreach(ChoiceForTextQuestion choice in questionModel.Choices)
                {
                    var choiceService = new TextChoiceService(choice, MapViewModel);
                    ret.Choices.Add(choiceService);
                }

                var defaultChoiceService = new DefaultChoiceService(questionModel.DefaultChoice, MapViewModel);
                ret.DefaultChoice = defaultChoiceService;

                return ret;
            }
        }
    }
}
