using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Models;
using Frontend.ViewModels;
using Xamarin.Essentials;

namespace Frontend.Services
{
    public class StopService
    {
        public Stop Model { get; set; }

        public StopViewModel ViewModel { get; set; }

        public int State { get; private set; }

        private int State1Value = 0;

        private int State2Value = 0;

        private int State3Value = 0;

        private int State4Value = 0;

        private bool FirstlyVisible = true;

        private bool FirstlyUnlocked = true;

        private int RequierementToUnlock { get; set; }

        private int RequierementValue { get; set; }

        private MapService MapService { get; }

        public LocationChecker LocationChecker { get; set; }

        private List<PasswordService> Passwords = new List<PasswordService>();

        GameService GameService { get; set; }

        PinViewModel PinOfTheStop { get; set; }

        bool? IsVisibleInState2;

        public StopService(Stop stopModel, AppShell appShell, MapService mapService, LocationChecker locationChecker, GameService gameService)
        {
            Model = stopModel;
            Model.Service = this;
            ViewModel = new StopViewModel(appShell, Model.Name);
            MapService = mapService;
            LocationChecker = locationChecker;
            GameService = gameService;
            if (Model.Position != null) IsVisibleInState2 = Model.Position.IsVisibleAsStopPosition;

            State = 0;
            if ((bool)Model.IsInitial)
            {
                SetAsVisible();
            }
            else
            {
                SetAsUnvisible();
            }
        }

        private void SetAsUnvisible()
        {
            if (State == 1) return;

            if (State == 2 || State == 3) ViewModel.RemoveFromBar();

            if (PinOfTheStop != null) MapService.SetPinViewModelToState(PinOfTheStop, 1, IsVisibleInState2);

            State = 1;
        }

        private void SetAsVisible()
        {
            if (State == 2) return;

            if (State == 1 || State == 0) ViewModel.AddToBar();
            if (FirstlyVisible)
            {
                if (Model.PositionsDisplayAfterDisplay != null) 
                    MapService.AddNotStops(Model.PositionsDisplayAfterDisplay as List<MapPosition>);

                if (Model.DisplayObjectsHints != null)
                {
                    foreach (DisplayObjectStopDisplayAfterDisplay displayObject in Model.DisplayObjectsHints)
                    {
                        ViewModel.AddDisplayObject(displayObject.DisplayObject, (int)displayObject.Position);
                    }

                }

                if (Model.Passwords != null)
                {
                    foreach (PasswordGameRequirement password in Model.Passwords)
                    {
                        var passwordService = new PasswordService(this, password);
                        Passwords.Add(passwordService);
                    }
                }

                FirstlyVisible = false;
            }

            if (Model.Position != null && PinOfTheStop == null) PinOfTheStop = MapService.AddStop(Model.Position, 2, IsVisibleInState2);
            else if (PinOfTheStop != null) MapService.SetPinViewModelToState(PinOfTheStop, 2, IsVisibleInState2);

            RequierementToUnlock = Model.Passwords.Count;
            RequierementValue = 0;

            foreach (PasswordService password in Passwords)
            {
                password.AskForPassword();
                password.PasswordCompleted += OnPasswordRequierementDone;
            }

            if (Model.Position != null)
            {
                RequierementToUnlock++; 
                var locationToCheck = new LocationToCheck(Model.Position.X, Model.Position.Y, Model.Position.Radius);
                locationToCheck.LocationReached += OnPositionRequierementDone;
                LocationChecker.AddLocation(locationToCheck);
            }
            else if (RequierementToUnlock == 0)
            {
                SetAsUnlocked();
                return;
            }

            State = 2;
        }

        private void SetAsUnlocked()
        {
            if (State == 3) return;

            if (FirstlyUnlocked)
            {
                if (Model.PositionsDisplayAfterUnlock != null)
                    MapService.AddNotStops(Model.PositionsDisplayAfterUnlock as List<MapPosition>);

                if (Model.DisplayObjectsRewards != null)
                {
                    foreach (DisplayObjectStopDisplayAfterUnlock displayObject in Model.DisplayObjectsRewards)
                    {
                        ViewModel.AddDisplayObject(displayObject.DisplayObject, (int)displayObject.Position);
                    }
                }

                FirstlyUnlocked = false;
            }


            if (Model.Position != null && PinOfTheStop == null) PinOfTheStop = MapService.AddStop(Model.Position, 3, IsVisibleInState2);
            else if (PinOfTheStop != null) MapService.SetPinViewModelToState(PinOfTheStop, 3, IsVisibleInState2);

            if (Model.Opens != null)
            {
                foreach (StopStop opening in Model.Opens)
                {
                    opening.Opens.Service.ProcessChange(opening.IfUnvisible, opening.IfVisible, opening.IfUnlocked, (int)opening.Value);
                }
            }

            if (Model.Questions != null)
            {
                foreach (Question question in Model.Questions)
                {
                    question.Service.Ask();
                }
            }

            if (State == 2)
            {
                foreach (PasswordService password in Passwords)
                {
                    password.Unshow();
                }
            }

            State = 3;

            if ((bool)Model.IsFinal)
            {
                GameService.End();
            }

            MainThread.BeginInvokeOnMainThread(() =>
            {
                GameService.End();
            });
        }

        private void SetAsUnlockedWithoutActions()
        {
            if (State == 3) return;

            if (FirstlyUnlocked)
            {
                if (Model.PositionsDisplayAfterUnlock != null) MapService.AddNotStops(Model.PositionsDisplayAfterUnlock as List<MapPosition>);

                if (Model.DisplayObjectsRewards != null)
                {
                    foreach (DisplayObjectStopDisplayAfterUnlock displayObject in Model.DisplayObjectsRewards)
                    {
                        ViewModel.AddDisplayObject(displayObject.DisplayObject, (int)displayObject.Position);
                    }
                }
                FirstlyUnlocked = false;
            }


            if (Model.Position != null && PinOfTheStop == null) PinOfTheStop = MapService.AddStop(Model.Position, 3, IsVisibleInState2);
            else if (PinOfTheStop != null) MapService.SetPinViewModelToState(PinOfTheStop, 3, IsVisibleInState2);

            if (State == 2)
            {
                foreach (PasswordService password in Passwords)
                {
                    password.Unshow();
                }
            }

            State = 3;

            if ((bool)Model.IsFinal)
            {
                GameService.End();
            }
        }

        private void OnPositionRequierementDone(object sender, EventArgs e)
        {
            RequierementValue++;
            CheckRequierements();
        }

        private void OnPasswordRequierementDone(object sender, EventArgs e)
        {
            (sender as PasswordService).PasswordCompleted -= OnPasswordRequierementDone;
            RequierementValue++;
            CheckRequierements();
        }

        private bool CheckRequierements()
        {
            if (RequierementValue >= RequierementToUnlock)
            {
                SetAsUnlocked();
                return true;
            }
            return false;
        }

        public void ProcessChange(int? IfUnvisible, int? IfVisible, int? IfUnlocked, int Value)
        {
            if (State == 1 && IfUnvisible != null)
            {
                AddToStateAndCheck((int)IfUnvisible, Value);
            }
            else if (State == 2 && IfVisible != null)
            {
                AddToStateAndCheck((int)IfUnvisible, Value);
            }
            else if (State == 3 && IfUnlocked != null)
            {
                AddToStateAndCheck((int)IfUnlocked, Value);
            }
        }

        private void AddToStateAndCheck(int increasingState, int value)
        {
            switch (increasingState)
            {
                case 0: break;
                case 1:
                    State1Value += value;
                    if (State1Value >= Model.State1Requirement)
                    {
                        State1Value = 0;
                        SetAsUnvisible();
                    }
                    break;
                case 2:
                    State2Value += value;
                    if (State2Value >= Model.State2Requirement)
                    {
                        State2Value = 0;
                        SetAsVisible();
                    }
                    break;
                case 3:
                    State3Value += value;
                    if (State3Value >= Model.State3Requirement)
                    {
                        State3Value = 0;
                        SetAsUnlocked();
                    }
                    break;
                case 4:
                    State4Value += value;
                    if (State4Value >= Model.State4Requirement)
                    {
                        State4Value = 0;
                        SetAsUnlockedWithoutActions();
                    }
                    break;
                default: break;
            }
        }
    }
}
