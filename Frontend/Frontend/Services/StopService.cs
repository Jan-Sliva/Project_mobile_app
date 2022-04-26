using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Frontend.Models;
using Frontend.ViewModels;
using Xamarin.Essentials;

namespace Frontend.Services
{
    public enum StopState
    {
        UNINITIALIZED = 0,
        UNVISIBLE = 1,
        VISIBLE = 2,
        UNLOCKED = 3,
        UNLOCKED_WITHOUT_ACTIONS = 4,
    }
    public class StopService
    {
        private StopState _state;
        public StopState State {
            get => _state;
            set
            {
                if (_state == value) return;
                switch (value)
                {
                    case StopState.UNVISIBLE:
                        SetAsUnvisible();
                        _state = StopState.UNVISIBLE;
                        break;
                    case StopState.VISIBLE:
                        SetAsVisible();
                        _state = StopState.VISIBLE;
                        break;
                    case StopState.UNLOCKED:
                        SetAsUnlocked();
                        _state = StopState.UNLOCKED;
                        break;
                    case StopState.UNLOCKED_WITHOUT_ACTIONS:
                        SetAsUnlockedWithoutActions();
                        _state = StopState.UNLOCKED;
                        break;
                    default: break;
                }
            }
        }

        private int _state1Value = 0;
        public int State1Value
        {
            get => _state1Value;
            set
            {
                _state1Value = value;
                if (_state1Value >= Model.State1Requirement)
                {
                    State = StopState.UNVISIBLE;
                    _state1Value = 0;
                }
            }
        }


        private int _state2Value = 0;
        public int State2Value
        {
            get => _state2Value;
            set
            {
                _state2Value = value;
                if (_state2Value >= Model.State2Requirement)
                {
                    State = StopState.VISIBLE;
                    _state2Value = 0;
                }
            }
        }

        private int _state3Value = 0;
        public int State3Value
        {
            get => _state3Value;
            set
            {
                _state3Value = value;
                if (_state3Value >= Model.State3Requirement)
                {
                    State = StopState.UNLOCKED;
                    _state3Value = 0;
                }
            }
        }

        private int _state4Value = 0;
        public int State4Value
        {
            get => _state4Value;
            set
            {
                _state4Value = value;
                if (_state4Value >= Model.State4Requirement)
                {
                    State = StopState.UNLOCKED_WITHOUT_ACTIONS;
                    _state4Value = 0;
                }
            }
        }

        private int _requirementValue;
        public int RequierementValue
        {
            get => _requirementValue;
            set
            {
                if (_requirementValue == value) return;
                _requirementValue = value;
                if (_requirementValue >= RequierementToUnlock)
                {
                    State = StopState.UNLOCKED;
                    _requirementValue = 0;
                }
            }
        }

        private int RequierementToUnlock;

        private bool FirstlyVisible = true;
        private bool FirstlyUnlocked = true;
        private MapViewModel MapViewModel;
        private LocationChecker LocationChecker;
        private List<PasswordService> Passwords = new List<PasswordService>();
        private GameService GameService;
        private PinViewModel PinOfTheStop;
        private List<PinViewModel> pinAfterDisplay = new List<PinViewModel>();
        private List<PinViewModel> pinAfterUnlock = new List<PinViewModel>();
        private bool IsVisibleInState2;
        private Stop Model;
        private StopViewModel ViewModel;
        private LocationToCheck LocationToCheck;

        public List<UnlockStopService> OpenStops = new List<UnlockStopService>();
        public List<QuestionService> OpenQuestions = new List<QuestionService>();

        public StopService(Stop stopModel, AppShellViewModel appShell,
            MapViewModel mapViewModel, LocationChecker locationChecker,
            GameService gameService, List<PasswordService> passwordServices)
        {
            Model = stopModel;
            ViewModel = new StopViewModel(appShell, Model, passwordServices.Select(x => x.ViewModel));
            MapViewModel = mapViewModel;
            LocationChecker = locationChecker;
            GameService = gameService;

            RequierementToUnlock = Model.Passwords.Count;

            if (Model.Position != null)
            {
                RequierementToUnlock++;
                IsVisibleInState2 = (bool) Model.Position.IsVisibleAsStopPosition;
                PinOfTheStop = new PinViewModel(mapViewModel, Model.Position, PinDisplayType.NOT_VISIBLE);

                LocationToCheck = new LocationToCheck(Model.Position.X, Model.Position.Y, Model.Position.Radius);
                LocationToCheck.LocationReached += OnPositionRequierementDone;
            }

            foreach(PasswordService passwordService in passwordServices)
            {
                passwordService.PasswordCompleted += OnPasswordRequierementDone;
            }

            foreach(MapPosition pos in Model.PositionsDisplayAfterDisplay)
            {
                pinAfterDisplay.Add(new PinViewModel(mapViewModel, pos));
            }

            foreach (MapPosition pos in Model.PositionsDisplayAfterUnlock)
            {
                pinAfterUnlock.Add(new PinViewModel(mapViewModel, pos));
            }

            _state = StopState.UNINITIALIZED;
            if ((bool)Model.IsInitial)
            {
                State = StopState.VISIBLE;
            }
            else
            {
                State = StopState.UNVISIBLE;
            }
        }

        private void SetAsUnvisible()
        {
            ViewModel.State = StopDisplayState.NOT_VISIBLE;

            if (PinOfTheStop != null) PinOfTheStop.State = PinDisplayType.NOT_VISIBLE;
        }

        private void SetAsVisible()
        {
            _requirementValue = 0;

            ViewModel.State = StopDisplayState.LOCKED;

            if (FirstlyVisible)
            {
                foreach (PinViewModel pinViewModel in pinAfterDisplay)
                {
                    pinViewModel.State = PinDisplayType.NOT_STOP;
                }
                FirstlyVisible = false;
            }

            foreach (PasswordService password in Passwords)
            {
                password.AskForPassword();
            }

            if (PinOfTheStop != null)
            {
                if (IsVisibleInState2) PinOfTheStop.State = PinDisplayType.LOCKED;
                else PinOfTheStop.State = PinDisplayType.NOT_VISIBLE;
            }

            if (LocationToCheck != null)
            {
                LocationChecker.AddLocation(LocationToCheck);
            }

            if (RequierementToUnlock == 0)
            {
                State = StopState.UNLOCKED;
            }
        }

        private void SetAsUnlocked()
        {
            ViewModel.State = StopDisplayState.UNLOCKED;

            if (FirstlyUnlocked)
            {
                foreach (PinViewModel pinViewModel in pinAfterUnlock)
                {
                    pinViewModel.State = PinDisplayType.NOT_STOP;
                }
                FirstlyUnlocked = false;
            }

            if (PinOfTheStop != null)
            {
                PinOfTheStop.State = PinDisplayType.UNLOCKED;
            }

            if (LocationToCheck != null)
            {
                LocationChecker.RemoveLocation(LocationToCheck);
            }

            foreach (UnlockStopService unlockStopService in OpenStops)
            {
                unlockStopService.Process();
            }

            foreach (QuestionService questionService in OpenQuestions)
            {
                questionService.Ask();
            }

            foreach (PasswordService password in Passwords)
            {
                password.Unshow();
            }

            if ((bool)Model.IsFinal)
            {
                GameService.End();
            }

        }

        private void SetAsUnlockedWithoutActions()
        {
            ViewModel.State = StopDisplayState.UNLOCKED;

            if (FirstlyUnlocked)
            {
                foreach (PinViewModel pinViewModel in pinAfterUnlock)
                {
                    pinViewModel.State = PinDisplayType.NOT_STOP;
                }
                FirstlyUnlocked = false;
            }

            if (PinOfTheStop != null)
            {
                PinOfTheStop.State = PinDisplayType.UNLOCKED;
            }

            if (LocationToCheck != null)
            {
                LocationChecker.RemoveLocation(LocationToCheck);
            }

            foreach (PasswordService password in Passwords)
            {
                password.Unshow();
            }
        }

        private void OnPositionRequierementDone(object sender, EventArgs e)
        {
            RequierementValue++;
        }

        private void OnPasswordRequierementDone(object sender, EventArgs e)
        {
            RequierementValue++;
        }

        public void ProcessChange(StopOpening stopStop)
        {
            if (State == StopState.UNVISIBLE && stopStop.IfUnvisible != null)
            {
                AddToState((int)stopStop.IfUnvisible, (int)stopStop.Value);
            }
            else if (State == StopState.VISIBLE && stopStop.IfVisible != null)
            {
                AddToState((int)stopStop.IfVisible, (int)stopStop.Value);
            }
            else if (State == StopState.UNLOCKED && stopStop.IfUnlocked != null)
            {
                AddToState((int)stopStop.IfUnlocked, (int)stopStop.Value);
            }
        }

        private void AddToState(int increasingState, int value)
        {
            switch (increasingState)
            {
                case 0: break;
                case 1:
                    State1Value += value;
                    break;
                case 2:
                    State2Value += value;
                    break;
                case 3:
                    State3Value += value;
                    break;
                case 4:
                    State4Value += value;
                    break;
                default: break;
            }
        }
    }
}
