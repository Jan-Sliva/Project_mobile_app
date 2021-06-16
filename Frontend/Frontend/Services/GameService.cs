using Frontend.RestClient.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Models;
using Frontend.ViewModels;

namespace Frontend.Services
{
    public class GameService
    {
        
        Game Model { get; set; }

        AppShell AppShell { get; set; }

        MapService MapService { get; set; }

        LocationChecker LocationChecker { get; set; }

        IntroductionViewModel Introduction { get; set; }

        public async void LoadAndPlayGame(int id, AppShell appShell)
        {
            var restClient = new RestClient.RestClient();

            var gameResource = await restClient.GetFullGameByIdAsync(id);

            var converter = new FullGameConverter();

            var game = converter.Convert(gameResource);

            LocationChecker = new LocationChecker();

            AppShell = appShell;

            Model = game;

            MapService = new MapService(AppShell);

            Introduction = new IntroductionViewModel(AppShell, Model.Introduction.Title);

            foreach(DisplayObject obj in Model.Introduction.DisplayObjects)
            {
                Introduction.AddDisplayObject(obj);
            }

            MapService.AddNotStops(Model.Introduction.MapPositions as List<MapPosition>);

            foreach (Stop stop in Model.Stops)
            {
                SetUpStopModel(stop);
            }
        }

        public void End()
        {
            AppShell.RemoveAllFlyoutItems();

            var EndInfo = new IntroductionViewModel(AppShell, "Konec");

            var EndText = new Text() { Title = "Dokončil jsi hru", OwnText = "Dokončil jsi testovací hru, doufám, že se ti líbila", PositionInIntroduction = 0 };

            EndInfo.AddText(EndText);
        }

        private void SetUpStopModel(Stop stopModel)
        {
            if(stopModel.Service == null)
            {
                stopModel.Service = new StopService(stopModel, AppShell, MapService, LocationChecker, this);
                if (stopModel.Questions != null)
                {
                    foreach (Question questionModel in stopModel.Questions)
                    {
                        SetUpQuestionModel(questionModel);
                    }
                }
            }
        }

        private void SetUpQuestionModel(Question questionModel)
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
