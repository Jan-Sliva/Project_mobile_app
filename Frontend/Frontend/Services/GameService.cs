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
        Dictionary<Stop, StopService> buildingStops;
        Dictionary<ChoiceQuestion, ChoiceQuestionService> buildingChoiceQuestions;
        Dictionary<TextQuestion, TextQuestionService> buildingTextQuestions;
        Dictionary<StopOpening, UnlockStopService> buildingUnlockStops;

        public async void LoadAndPlayGame(int id, AppShellViewModel appShell)
        {
            var restClient = new RestClient.RestClient();
            var gameResource = await restClient.GetFullGameByIdAsync(id);
            var converter = new FullGameConverter();
            var game = converter.Convert(gameResource);
            LocationChecker = new LocationChecker();
            AppShell = appShell;
            Model = game;
            MapViewModel = new MapViewModel(appShell);

            Introduction = new IntroductionViewModel(AppShell, Model.Introduction);

            Text InfoAboutGame = new Text()
            {
                Title = "Hráči, kteří se podíleli na této hře",
                OwnText = "",
                PositionInIntroduction = 0
            };
            foreach(User user in Model.Owners)
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

            }
        }

        private TextQuestionService SetUpTextQuestion(TextQuestion questionModel)
        {
            if(questionModel.Service == null)
            {
                if (questionModel is ChoiceQuestion)
                {
                    questionModel.Service = new ChoiceQuestionService(AppShell, questionModel as ChoiceQuestion, MapService);
                    foreach (ChoiceForChoiceQuestion choiceModel in (questionModel as ChoiceQuestion).Choices)
                    {
                        if (choiceModel.OpensQuestions != null)
                        {
                            foreach (Question choiceQuestionModel in choiceModel.OpensQuestions)
                            {
                                SetUpQuestionModel(choiceQuestionModel);
                            }
                        }
                    }
                }
                else if (questionModel is TextQuestion)
                {
                    questionModel.Service = new TextQuestionService(AppShell, questionModel as TextQuestion, MapService);
                    foreach (ChoiceForTextQuestion choiceModel in (questionModel as TextQuestion).Choices)
                    {
                        if (choiceModel.OpensQuestions != null)
                        {
                            foreach (Question choiceQuestionModel in choiceModel.OpensQuestions)
                            {
                                SetUpQuestionModel(choiceQuestionModel);
                            }
                        }
                    }

                    if ((questionModel as TextQuestion).DefaultChoice.OpensQuestions != null)
                    {
                        foreach (Question choiceModel in (questionModel as TextQuestion).DefaultChoice.OpensQuestions)
                        {
                            SetUpQuestionModel(choiceModel);
                        }
                    }
                }
            }
        }
    }
}
