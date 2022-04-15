using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.ViewModels
{
    public enum StopDisplayState
    {
        NOT_VISIBLE = 1,
        LOCKED = 2,
        UNLOCKED = 3
    }
    public class StopViewModel : InfoScreenViewModel
    {
        private StopDisplayState _lastState;
        private StopDisplayState _state;
        public StopDisplayState State { get => _state; set => SetProperty(ref _state, value); }

        private List<DisplayObjectViewModel> _dispayAfterDisplay;
        private List<DisplayObjectViewModel> _dispayAfterUnlock;
        private List<DisplayObjectViewModel> _hideAfterUnlock; // display after display, hide after unlock

        public StopViewModel(AppShellViewModel appShellViewModel, Stop stop)
            : base(appShellViewModel, stop.Name, "icon_stop.png")
        {
            _state = StopDisplayState.NOT_VISIBLE;
            _lastState = _state;
        }

        protected new void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(State))
            {
                UpdateState(_state, _lastState);
                _lastState = _state;
            }
        }

        private void UpdateState(StopDisplayState newState, StopDisplayState lastState)
        {
            if (newState == lastState) return;

            switch (newState)
            {
                case StopDisplayState.NOT_VISIBLE:
                    RemoveDisplayObjects(_dispayAfterDisplay);
                    if (lastState == StopDisplayState.UNLOCKED) RemoveDisplayObjects(_dispayAfterUnlock);
                    else if (lastState == StopDisplayState.LOCKED) RemoveDisplayObjects(_hideAfterUnlock);
                    Hide();
                    break;
                case StopDisplayState.LOCKED:
                    AddDisplayObjects(_hideAfterUnlock);
                    if (lastState == StopDisplayState.NOT_VISIBLE)
                    {
                        AddDisplayObjects(_dispayAfterDisplay);
                        ShowAtPos(2);
                    }
                    else if (lastState == StopDisplayState.UNLOCKED)
                    {
                        RemoveDisplayObjects(_dispayAfterUnlock);
                    }
                    break;
                case StopDisplayState.UNLOCKED:
                    if (lastState == StopDisplayState.NOT_VISIBLE)
                    {
                        AddDisplayObjects(_dispayAfterDisplay);
                        ShowAtPos(2);
                    }
                    else if (lastState == StopDisplayState.LOCKED) RemoveDisplayObjects(_hideAfterUnlock);
                    AddDisplayObjects(_dispayAfterUnlock);
                    break;
                default: break;
            }
        }
    }
}
