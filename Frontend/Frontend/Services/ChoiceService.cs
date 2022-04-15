using Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Services
{
    public class ChoiceService
    {
        private List<UnlockStopService> UnlockStops = new List<UnlockStopService>();

        private List<QuestionService> UnlockQuestions = new List<QuestionService>();

        private List<PinViewModel> UnlockPins = new List<PinViewModel>();

        private bool FirstlyVisible = true;

        public void Process()
        {
            if (FirstlyVisible)
            {
                foreach (PinViewModel pin in UnlockPins)
                {
                    pin.State = PinDisplayType.NOT_STOP;
                }
                FirstlyVisible = false;
            }

            foreach(UnlockStopService stop in UnlockStops)
            {
                stop.Process();
            }

            foreach (QuestionService question in UnlockQuestions)
            {
                question.Ask();
            }
        }

    }
}
