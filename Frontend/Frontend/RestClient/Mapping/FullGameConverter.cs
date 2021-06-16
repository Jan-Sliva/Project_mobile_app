using System;
using System.Collections.Generic;
using System.Text;
using Frontend.RestClient.Resources.GameResources.FullGame;
using Frontend.Models;
using System.Linq;

namespace Frontend.RestClient.Mapping
{
    public class FullGameConverter
    {

        List<User> CreatedUsers = new List<User>();

        public User Convert(UserResourceForFullGame userResource)
        {
            var existingUser = CreatedUsers.Where(obj => obj.Id == userResource.Id).FirstOrDefault();

            if (existingUser != null)
            {
                Assign(existingUser, userResource);
                return existingUser;
            }
            else
            {
                var newUser = new User();
                CreatedUsers.Add(newUser);
                Assign(newUser, userResource);
                return newUser;
            }
        }

        void Assign(User user, UserResourceForFullGame userResource)
        {
            user.Id = userResource.Id;

            if (userResource.Password != null) user.Password = userResource.Password;

            if (userResource.Email != null) user.Email = userResource.Email;

            if (userResource.UserName != null) user.UserName = userResource.UserName;
        }

        List<Game> CreatedGames = new List<Game>();

        public Game Convert(GameResource gameResource)
        {
            var existingGame = CreatedGames.Where(obj => obj.Id == gameResource.Id).FirstOrDefault();

            if (existingGame != null)
            {
                Assign(existingGame, gameResource);
                return existingGame;
            }
            else
            {
                var newGame = new Game();
                CreatedGames.Add(newGame);
                Assign(newGame, gameResource);
                return newGame;
            }
        }

        void Assign(Game game, GameResource GameResource)
        {

            game.Id = GameResource.Id;

            if (GameResource.Description != null) game.Description = GameResource.Description;

            if (GameResource.Name != null) game.Name = GameResource.Name;

            if (GameResource.Limit != null) game.Limit = new TimeSpan(0, (int)GameResource.Limit, 0);

            if (GameResource.PlayingTime != null) game.PlayingTime = new TimeSpan(0, (int)GameResource.PlayingTime, 0);

            if((GameResource.Introduction != null) && game.Introduction == null)
            {
                Introduction newIntro = Convert(GameResource.Introduction);
                game.Introduction = newIntro;
                newIntro.Game = game;
            }

            if ((GameResource.Stops != null) && game.Stops == null)
            {
                game.Stops = new List<Stop>();

                foreach (StopResource stopResource in GameResource.Stops)
                {
                    var newStop = Convert(stopResource);
                    game.Stops.Add(newStop);
                    newStop.PartOfGame = game;
                }
            }

            if ((GameResource.Owners != null) && game.Owners == null)
            {
                game.Owners = new List<User>();

                foreach (UserResourceForFullGame userResource in GameResource.Owners)
                {
                    var newUser = Convert(userResource);
                    game.Owners.Add(newUser);
                    if (newUser.Games == null) newUser.Games = new List<Game>();
                    newUser.Games.Add(game);
                }
            }
        }


        List<Stop> CreatedStops = new List<Stop>();

        public Stop Convert(StopResource stopResource)
        {
            var existingStop = CreatedStops.Where(obj => obj.Id == stopResource.Id).FirstOrDefault();

            if (existingStop != null)
            {
                Assign(existingStop, stopResource);
                return existingStop;
            }
            else
            {
                var newStop = new Stop();
                CreatedStops.Add(newStop);
                Assign(newStop, stopResource);
                return newStop;
            }
        }

        void Assign(Stop stop, StopResource StopResource)
        {

            stop.Id = StopResource.Id;

            if (StopResource.IsFinal != null) stop.IsFinal = StopResource.IsFinal;

            if (StopResource.IsInitial != null) stop.IsInitial = StopResource.IsInitial;

            if (StopResource.Name != null) stop.Name = StopResource.Name;

            if (StopResource.State1Requirement != null) stop.State1Requirement = (short)StopResource.State1Requirement;

            if (StopResource.State2Requirement != null) stop.State2Requirement = (short)StopResource.State2Requirement;

            if (StopResource.State3Requirement != null) stop.State3Requirement = (short)StopResource.State3Requirement;

            if (StopResource.State4Requirement != null) stop.State4Requirement = (short)StopResource.State4Requirement;

            if ((StopResource.Position != null) && stop.Position == null)
            {
                MapPosition newMapPosition = Convert(StopResource.Position);
                stop.Position= newMapPosition;
                newMapPosition.PositionOfStop = stop;
            }

            if ((StopResource.Passwords != null) && stop.Passwords == null)
            {
                stop.Passwords = new List<PasswordGameRequirement>();

                foreach (PasswordGameRequirementResource passwordResource in StopResource.Passwords)
                {
                    PasswordGameRequirement newPassword = Convert(passwordResource);
                    stop.Passwords.Add(newPassword);
                    newPassword.Stop = stop;
                }
            }

            if ((StopResource.Questions != null) && stop.Questions == null)
            {
                stop.Questions = new List<Question>();

                foreach (QuestionResource questionResource in StopResource.Questions)
                {
                    Question newQuestion = Convert(questionResource);
                    stop.Questions.Add(newQuestion);
                    if (newQuestion.StopsThatOpenThis == null) newQuestion.StopsThatOpenThis = new List<Stop>();
                    newQuestion.StopsThatOpenThis.Add(stop);
                }
            }

            if ((StopResource.PositionsDisplayAfterDisplay != null) && stop.PositionsDisplayAfterDisplay == null)
            {
                stop.PositionsDisplayAfterDisplay = new List<MapPosition>();

                foreach (MapPositionResource positionResource in StopResource.PositionsDisplayAfterDisplay)
                {
                    MapPosition newPosition = Convert(positionResource);
                    stop.PositionsDisplayAfterDisplay.Add(newPosition);
                    if (newPosition.StopDisplayAfterDisplay == null) newPosition.StopDisplayAfterDisplay = new List<Stop>();
                    newPosition.StopDisplayAfterDisplay.Add(stop);
                }
            }

            if ((StopResource.PositionsDisplayAfterUnlock != null) && stop.PositionsDisplayAfterUnlock == null)
            {
                stop.PositionsDisplayAfterUnlock = new List<MapPosition>();

                foreach (MapPositionResource positionResource in StopResource.PositionsDisplayAfterUnlock)
                {
                    MapPosition newPosition = Convert(positionResource);
                    stop.PositionsDisplayAfterUnlock.Add(newPosition);
                    if (newPosition.StopDisplayAfterUnlock == null) newPosition.StopDisplayAfterUnlock = new List<Stop>();
                    newPosition.StopDisplayAfterUnlock.Add(stop);
                }
            }

            if ((StopResource.Opens != null) && stop.Opens == null)
            {
                stop.Opens = new List<StopStop>();

                foreach (StopStopResource stopStopResource in StopResource.Opens)
                {
                    StopStop newStopStop = Convert(stopStopResource);
                    stop.Opens.Add(newStopStop);
                    newStopStop.StopOpensThis = stop;
                }
            }

            if ((StopResource.ChoicesOpenThis != null) && stop.ChoicesOpenThis == null)
            {
                stop.ChoicesOpenThis = new List<ChoiceStop>();

                foreach (ChoiceStopResource choiceOpenThis in StopResource.ChoicesOpenThis)
                {
                    ChoiceStop newChoiceStop = Convert(choiceOpenThis);
                    stop.ChoicesOpenThis.Add(newChoiceStop);
                    newChoiceStop.Opens = stop;
                }
            }

            if ((StopResource.DisplayObjectsHints != null) && stop.DisplayObjectsHints == null)
            {
                stop.DisplayObjectsHints = new List<DisplayObjectStopDisplayAfterDisplay>();

                foreach (DisplayObjectStopDisplayAfterDisplayResource hint in StopResource.DisplayObjectsHints)
                {
                    DisplayObjectStopDisplayAfterDisplay newHint = Convert(hint);
                    stop.DisplayObjectsHints.Add(newHint);
                    newHint.Stop = stop;
                }
            }

            if ((StopResource.DisplayObjectsRewards != null) && stop.DisplayObjectsRewards == null)
            {
                stop.DisplayObjectsRewards = new List<DisplayObjectStopDisplayAfterUnlock>();

                foreach (DisplayObjectStopDisplayAfterUnlockResource reward in StopResource.DisplayObjectsRewards)
                {
                    DisplayObjectStopDisplayAfterUnlock newReward = Convert(reward);
                    stop.DisplayObjectsRewards.Add(newReward);
                    newReward.Stop = stop;
                }
            }
        }

        List<StopStop> CreatedStopStops = new List<StopStop>();

        public StopStop Convert(StopStopResource stopStopResource)
        {
            var existingStopStop = CreatedStopStops.Where(obj => obj.Id == stopStopResource.Id).FirstOrDefault();

            if (existingStopStop != null)
            {
                Assign(existingStopStop, stopStopResource);
                return existingStopStop;
            }
            else
            {
                var newStopStop = new StopStop();
                CreatedStopStops.Add(newStopStop);
                Assign(newStopStop, stopStopResource);
                return newStopStop;
            }
        }

        void Assign(StopStop stopStop, StopStopResource stopStopResource)
        {
            stopStop.Id = stopStopResource.Id;

            if (stopStopResource.IfUnlocked != null) stopStop.IfUnlocked = stopStopResource.IfUnlocked;

            if (stopStopResource.IfUnvisible != null) stopStop.IfUnvisible = stopStopResource.IfUnvisible;

            if (stopStopResource.IfVisible != null) stopStop.IfVisible = stopStopResource.IfVisible;

            if (stopStopResource.Value != null) stopStop.Value = stopStopResource.Value;

            if ((stopStopResource.Opens != null) && stopStop.Opens == null)
            {
                Stop newStop = Convert(stopStopResource.Opens);
                stopStop.Opens = newStop;
                if (newStop.StopsOpenThis == null) newStop.StopsOpenThis = new List<StopStop>();
                newStop.StopsOpenThis.Add(stopStop);
            }
        }

        List<ChoiceStop> CreatedChoiceStops = new List<ChoiceStop>();

        public ChoiceStop Convert(ChoiceStopResource choiceStopResource)
        {
            var existingChoiceStop = CreatedChoiceStops.Where(obj => obj.Id == choiceStopResource.Id).FirstOrDefault();

            if (existingChoiceStop != null)
            {
                Assign(existingChoiceStop, choiceStopResource);
                return existingChoiceStop;
            }
            else
            {
                var newChoiceStop = new ChoiceStop();
                CreatedChoiceStops.Add(newChoiceStop);
                Assign(newChoiceStop, choiceStopResource);
                return newChoiceStop;
            }
        }

        void Assign(ChoiceStop choiceStop, ChoiceStopResource choiceStopResource)
        {
            choiceStop.Id = choiceStopResource.Id;

            if (choiceStopResource.IfUnlocked != null) choiceStop.IfUnlocked = choiceStopResource.IfUnlocked;

            if (choiceStopResource.IfUnvisible != null) choiceStop.IfUnvisible = choiceStopResource.IfUnvisible;

            if (choiceStopResource.IfVisible != null) choiceStop.IfVisible = choiceStopResource.IfVisible;

            if (choiceStopResource.Value != null) choiceStop.Value = choiceStopResource.Value;

            if ((choiceStopResource.ChoiceOpensThis != null) && choiceStop.ChoiceOpensThis == null)
            {
                Choice newChoice = Convert(choiceStopResource.ChoiceOpensThis);
                choiceStop.ChoiceOpensThis = newChoice;
                if (newChoice.OpensStops == null) newChoice.OpensStops = new List<ChoiceStop>();
                newChoice.OpensStops.Add(choiceStop);
            }
        }


        public DisplayObjectStopDisplayAfterDisplay Convert(DisplayObjectStopDisplayAfterDisplayResource displayObject)
        {
            
            var newDisplayObject = new DisplayObjectStopDisplayAfterDisplay();
            Assign(newDisplayObject, displayObject);
            return newDisplayObject;
            
        }

        void Assign(DisplayObjectStopDisplayAfterDisplay displayObject, DisplayObjectStopDisplayAfterDisplayResource displayObjectResource)
        {
            if (displayObjectResource.Position != null) displayObject.Position = displayObjectResource.Position;

            if ((displayObjectResource.DisplayObject != null) && displayObject.DisplayObject == null)
            {
                DisplayObject newDisplayObject = Convert(displayObjectResource.DisplayObject);
                displayObject.DisplayObject = newDisplayObject;
                if (newDisplayObject.HintForTheseStops == null) newDisplayObject.HintForTheseStops = new List<DisplayObjectStopDisplayAfterDisplay>();
                newDisplayObject.HintForTheseStops.Add(displayObject);
            }
        }


        public DisplayObjectStopDisplayAfterUnlock Convert(DisplayObjectStopDisplayAfterUnlockResource displayObject)
        {
            var newDisplayObject = new DisplayObjectStopDisplayAfterUnlock();
            Assign(newDisplayObject, displayObject);
            return newDisplayObject;
            
        }

        void Assign(DisplayObjectStopDisplayAfterUnlock displayObject, DisplayObjectStopDisplayAfterUnlockResource displayObjectResource)
        {
            if (displayObjectResource.Position != null) displayObject.Position = displayObjectResource.Position;

            if ((displayObjectResource.DisplayObject != null) && displayObject.DisplayObject == null)
            {
                DisplayObject newDisplayObject = Convert(displayObjectResource.DisplayObject);
                displayObject.DisplayObject = newDisplayObject;
                if (newDisplayObject.RewardForTheseStops == null) newDisplayObject.RewardForTheseStops = new List<DisplayObjectStopDisplayAfterUnlock>();
                newDisplayObject.RewardForTheseStops.Add(displayObject);
            }
        }

        List<Introduction> CreatedIntroductions = new List<Introduction>();

        public Introduction Convert(IntroductionResource introductionResource)
        {
            var existingIntroduction = CreatedIntroductions.Where(obj => obj.Id == introductionResource.Id).FirstOrDefault();

            if (existingIntroduction != null)
            {
                Assign(existingIntroduction, introductionResource);
                return existingIntroduction;
            }
            else
            {
                var newIntroduction = new Introduction();
                CreatedIntroductions.Add(newIntroduction);
                Assign(newIntroduction, introductionResource);
                return newIntroduction;
            }
        }

        void Assign(Introduction introduction, IntroductionResource introductionResource)
        {
            introduction.Id = introductionResource.Id;

            if (introductionResource.Title != null) introduction.Title = introductionResource.Title;

            if ((introductionResource.MapPositions != null) && introduction.MapPositions == null)
            {
                introduction.MapPositions = new List<MapPosition>();

                foreach (MapPositionResource mapPositionResource in introductionResource.MapPositions)
                {
                    MapPosition newMapPosition = Convert(mapPositionResource);
                    introduction.MapPositions.Add(newMapPosition);
                    newMapPosition.Introduction = introduction;
                }
            }

            if ((introductionResource.DisplayObjects != null) && introduction.DisplayObjects == null)
            {
                introduction.DisplayObjects = new List<DisplayObject>();

                foreach (DisplayObjectResource displayObjectResource in introductionResource.DisplayObjects)
                {
                    DisplayObject newDisplayObject = Convert(displayObjectResource);
                    introduction.DisplayObjects.Add(newDisplayObject);
                    newDisplayObject.Introduction = introduction;
                }
            }
        }

        List<PasswordGameRequirement> CreatedPasswordGameRequirements = new List<PasswordGameRequirement>();

        public PasswordGameRequirement Convert(PasswordGameRequirementResource passwordResource)
        {
            var existingPasswordGameRequirement = CreatedPasswordGameRequirements.Where(obj => obj.Id == passwordResource.Id).FirstOrDefault();

            if (existingPasswordGameRequirement != null)
            {
                Assign(existingPasswordGameRequirement, passwordResource);
                return existingPasswordGameRequirement;
            }
            else
            {
                var newPasswordGameRequirement = new PasswordGameRequirement();
                CreatedPasswordGameRequirements.Add(newPasswordGameRequirement);
                Assign(newPasswordGameRequirement, passwordResource);
                return newPasswordGameRequirement;
            }
        }

        void Assign(PasswordGameRequirement password, PasswordGameRequirementResource passwordResource)
        {
            password.Id = passwordResource.Id;

            if (passwordResource.Question != null) password.Question = passwordResource.Question;

            if ((passwordResource.Passwords != null) && password.Passwords == null)
            {
                password.Passwords = new List<GamePassword>();

                foreach (GamePasswordResource gamePassword in passwordResource.Passwords)
                {
                    GamePassword newPasswords = Convert(gamePassword);
                    password.Passwords.Add(newPasswords);
                    newPasswords.PasswordGameRequirement = password;
                }
            }
        }

        List<GamePassword> CreatedGamePasswords = new List<GamePassword>();

        public GamePassword Convert(GamePasswordResource gamePasswordResource)
        {
            var existingGamePassword = CreatedGamePasswords.Where(obj => obj.Id == gamePasswordResource.Id).FirstOrDefault();

            if (existingGamePassword != null)
            {
                Assign(existingGamePassword, gamePasswordResource);
                return existingGamePassword;
            }
            else
            {
                var newGamePassword = new GamePassword();
                CreatedGamePasswords.Add(newGamePassword);
                Assign(newGamePassword, gamePasswordResource);
                return newGamePassword;
            }
        }

        void Assign(GamePassword gamePassword, GamePasswordResource gamePasswordResource)
        {
            gamePassword.Id = gamePasswordResource.Id;

            if (gamePasswordResource.DiffUpperCase != null) gamePassword.DiffUpperCase = gamePasswordResource.DiffUpperCase;

            if (gamePasswordResource.UseRegex != null) gamePassword.UseRegex = gamePasswordResource.UseRegex;

            if (gamePasswordResource.Password != null) gamePassword.Password = gamePasswordResource.Password;

        }

        List<MapPosition> CreatedMapPositions = new List<MapPosition>();

        public MapPosition Convert(MapPositionResource mapPositionResource)
        {
            var existingMapPosition = CreatedMapPositions.Where(obj => obj.Id == mapPositionResource.Id).FirstOrDefault();

            if (existingMapPosition != null)
            {
                Assign(existingMapPosition, mapPositionResource);
                return existingMapPosition;
            }
            else
            {
                var newMapPosition = new MapPosition();
                CreatedMapPositions.Add(newMapPosition);
                Assign(newMapPosition, mapPositionResource);
                return newMapPosition;
            }
        }

        void Assign(MapPosition mapPosition, MapPositionResource mapPositionResource)
        {
            mapPosition.Id = mapPositionResource.Id;

            if (mapPositionResource.Description != null) mapPosition.Description = mapPositionResource.Description;

            if (mapPositionResource.IsVisibleAsStopPosition != null) mapPosition.IsVisibleAsStopPosition = mapPositionResource.IsVisibleAsStopPosition;

            if (mapPositionResource.Radius != null) mapPosition.Radius = (double)mapPositionResource.Radius;

            if (mapPositionResource.X != null) mapPosition.X = (double)mapPositionResource.X;

            if (mapPositionResource.Y != null) mapPosition.Y = (double)mapPositionResource.Y;

        }

        List<DisplayObject> CreatedDisplayObjects = new List<DisplayObject>();

        public DisplayObject Convert(DisplayObjectResource displayObjectResource)
        {
            var existingDisplayObject = CreatedDisplayObjects.Where(obj => obj.Id == displayObjectResource.Id).FirstOrDefault();

            if (existingDisplayObject != null)
            {
                if (existingDisplayObject is Text)
                {
                    Assign(existingDisplayObject as Text, displayObjectResource);
                }
                else if (existingDisplayObject is Picture)
                {
                    Assign(existingDisplayObject as Picture, displayObjectResource);
                }
                return existingDisplayObject;
            }
            else
            {
                if (displayObjectResource.OwnText != null)
                {
                    var newText = new Text();
                    CreatedDisplayObjects.Add(newText);
                    Assign(newText, displayObjectResource);
                    return newText;
                }
                else if (displayObjectResource.Image != null)
                {
                    var newPicture = new Picture();
                    CreatedDisplayObjects.Add(newPicture);
                    Assign(newPicture, displayObjectResource);
                    return newPicture;
                }
                return null;
            }
        }

        void Assign(Text text, DisplayObjectResource displayObjectResource)
        {
            text.Id = displayObjectResource.Id;

            if (displayObjectResource.Title != null) text.Title = displayObjectResource.Title;

            if (displayObjectResource.PositionInIntroduction != null) text.PositionInIntroduction = displayObjectResource.PositionInIntroduction;

            if (displayObjectResource.OwnText != null) text.OwnText = displayObjectResource.OwnText;
        }

        void Assign(Picture picture, DisplayObjectResource displayObjectResource)
        {
            picture.Id = displayObjectResource.Id;

            if (displayObjectResource.Title != null) picture.Title = displayObjectResource.Title;

            if (displayObjectResource.PositionInIntroduction != null) picture.PositionInIntroduction = displayObjectResource.PositionInIntroduction;

            if (displayObjectResource.Image != null) picture.Image = displayObjectResource.Image;
        }

        List<Question> CreatedQuestions = new List<Question>();

        public Question Convert(QuestionResource questionResource)
        {
            var existingQuestion = CreatedQuestions.Where(obj => obj.Id == questionResource.Id).FirstOrDefault();

            if (existingQuestion != null)
            {
                if (existingQuestion is ChoiceQuestion)
                {
                    Assign(existingQuestion as ChoiceQuestion, questionResource);
                }
                else if (existingQuestion is TextQuestion)
                {
                    Assign(existingQuestion as TextQuestion, questionResource);
                }
                return existingQuestion;
            }
            else
            {
                if (questionResource.DefaultChoice == null)
                {
                    var newChoiceQuestion = new ChoiceQuestion();
                    CreatedQuestions.Add(newChoiceQuestion);
                    Assign(newChoiceQuestion, questionResource);
                    return newChoiceQuestion;
                }
                else
                {
                    var newTextQuestion = new TextQuestion();
                    CreatedQuestions.Add(newTextQuestion);
                    Assign(newTextQuestion, questionResource);
                    return newTextQuestion;
                }
            }
        }

        void Assign(ChoiceQuestion choiceQuestion, QuestionResource questionResource)
        {
            choiceQuestion.Id = questionResource.Id;

            if (questionResource.QuestionText != null) choiceQuestion.QuestionText = questionResource.QuestionText;

            if ((questionResource.ChoicesThatOpensThis != null) && choiceQuestion.ChoicesThatOpensThis == null)
            {
                choiceQuestion.ChoicesThatOpensThis = new List<Choice>();

                foreach (ChoiceResource choiceResource in questionResource.ChoicesThatOpensThis)
                {
                    Choice newChoice = Convert(choiceResource);
                    choiceQuestion.ChoicesThatOpensThis.Add(newChoice);
                    if (newChoice.OpensQuestions == null) newChoice.OpensQuestions = new List<Question>();
                    newChoice.OpensQuestions.Add(choiceQuestion);
                }
            }

            if ((questionResource.Choices != null) && choiceQuestion.Choices == null)
            {
                choiceQuestion.Choices = new List<ChoiceForChoiceQuestion>();

                foreach (ChoiceResource choiceResource in questionResource.Choices)
                {
                    ChoiceForChoiceQuestion newChoice = Convert(choiceResource) as ChoiceForChoiceQuestion;
                    choiceQuestion.Choices.Add(newChoice);
                    newChoice.Question = choiceQuestion;
                }
            }
        }

        void Assign(TextQuestion textQuestion, QuestionResource questionResource)
        {
            textQuestion.Id = questionResource.Id;

            if (questionResource.QuestionText != null) textQuestion.QuestionText = questionResource.QuestionText;

            if ((questionResource.ChoicesThatOpensThis != null) && textQuestion.ChoicesThatOpensThis == null)
            {
                textQuestion.ChoicesThatOpensThis = new List<Choice>();

                foreach (ChoiceResource choiceResource in questionResource.ChoicesThatOpensThis)
                {
                    Choice newChoice = Convert(choiceResource);
                    textQuestion.ChoicesThatOpensThis.Add(newChoice);
                    if (newChoice.OpensQuestions == null) newChoice.OpensQuestions = new List<Question>();
                    newChoice.OpensQuestions.Add(textQuestion);
                }
            }

            if ((questionResource.Choices != null) && textQuestion.Choices == null)
            {
                textQuestion.Choices = new List<ChoiceForTextQuestion>();

                foreach (ChoiceResource choiceResource in questionResource.Choices)
                {
                    ChoiceForTextQuestion newChoice = Convert(choiceResource) as ChoiceForTextQuestion;
                    textQuestion.Choices.Add(newChoice);
                    newChoice.Question = textQuestion;
                }
            }

            if ((questionResource.DefaultChoice != null) && textQuestion.DefaultChoice == null)
            {
                DefaultChoice newChoice = Convert(questionResource.DefaultChoice) as DefaultChoice;
                textQuestion.DefaultChoice = newChoice;
                newChoice.Question = textQuestion;
            }
        }

        List<Choice> CreatedChoices = new List<Choice>();

        public Choice Convert(ChoiceResource choiceResource)
        {
            var existingChoice = CreatedChoices.Where(obj => obj.Id == choiceResource.Id).FirstOrDefault();

            if (existingChoice != null)
            {
                if (existingChoice is ChoiceForChoiceQuestion)
                {
                    Assign(existingChoice as ChoiceForChoiceQuestion, choiceResource);
                }
                else if (existingChoice is ChoiceForTextQuestion)
                {
                    Assign(existingChoice as ChoiceForTextQuestion, choiceResource);
                }
                else if (existingChoice is DefaultChoice)
                {
                    Assign(existingChoice as DefaultChoice, choiceResource);
                }
                return existingChoice;
            }
            else
            {
                if (choiceResource.DiffUpperCase != null)
                {
                    var newChoice = new ChoiceForTextQuestion();
                    CreatedChoices.Add(newChoice);
                    Assign(newChoice, choiceResource);
                    return newChoice;
                }
                else if (choiceResource.Text != null)
                {
                    var newChoice = new ChoiceForChoiceQuestion();
                    CreatedChoices.Add(newChoice);
                    Assign(newChoice, choiceResource);
                    return newChoice;
                }
                else
                {
                    var newChoice = new DefaultChoice();
                    CreatedChoices.Add(newChoice);
                    Assign(newChoice, choiceResource);
                    return newChoice;
                }

            }
        }

        void Assign(ChoiceForChoiceQuestion choice, ChoiceResource choiceResource)
        {
            choice.Id = choiceResource.Id;

            if (choiceResource.Text != null) choice.Text = choiceResource.Text;

            if ((choiceResource.OpensMapPositions != null) && choice.OpensMapPositions == null)
            {
                choice.OpensMapPositions = new List<MapPosition>();

                foreach (MapPositionResource mapPositionResource in choiceResource.OpensMapPositions)
                {
                    MapPosition newPosition = Convert(mapPositionResource);
                    choice.OpensMapPositions.Add(newPosition);
                    if (newPosition.ChoicesThatOpenThis == null) newPosition.ChoicesThatOpenThis = new List<Choice>();
                    newPosition.ChoicesThatOpenThis.Add(choice);
                }
            }
        }

        void Assign(ChoiceForTextQuestion choice, ChoiceResource choiceResource)
        {
            choice.Id = choiceResource.Id;

            if (choiceResource.Text != null) choice.Text = choiceResource.Text;

            if (choiceResource.DiffUpperCase != null) choice.DiffUpperCase = choiceResource.DiffUpperCase;

            if (choiceResource.UseRegex != null) choice.UseRegex = choiceResource.UseRegex;

            if ((choiceResource.OpensMapPositions != null) && choice.OpensMapPositions == null)
            {
                choice.OpensMapPositions = new List<MapPosition>();

                foreach (MapPositionResource mapPositionResource in choiceResource.OpensMapPositions)
                {
                    MapPosition newPosition = Convert(mapPositionResource);
                    choice.OpensMapPositions.Add(newPosition);
                    if (newPosition.ChoicesThatOpenThis == null) newPosition.ChoicesThatOpenThis = new List<Choice>();
                    newPosition.ChoicesThatOpenThis.Add(choice);
                }
            }
        }

        void Assign(DefaultChoice choice, ChoiceResource choiceResource)
        {
            choice.Id = choiceResource.Id;

            if ((choiceResource.OpensMapPositions != null) && choice.OpensMapPositions == null)
            {
                choice.OpensMapPositions = new List<MapPosition>();

                foreach (MapPositionResource mapPositionResource in choiceResource.OpensMapPositions)
                {
                    MapPosition newPosition = Convert(mapPositionResource);
                    choice.OpensMapPositions.Add(newPosition);
                    if (newPosition.ChoicesThatOpenThis == null) newPosition.ChoicesThatOpenThis = new List<Choice>();
                    newPosition.ChoicesThatOpenThis.Add(choice);
                }
            }
        }
    }
}
