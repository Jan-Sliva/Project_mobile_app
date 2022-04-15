using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Services
{
    public class UnlockStopService
    {
        public StopOpening StopStop;
        public StopService Unlock;

        public UnlockStopService(StopOpening stopStop, StopService unlockStop)
        {
            StopStop = stopStop;
            Unlock = unlockStop;
        }

        public void Process()
        {
            Unlock.ProcessChange(StopStop);
        }
    }
}
