using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Services
{
    public class UnlockStopService
    {
        public StopStop StopStop;
        public StopService Unlock;

        public UnlockStopService(StopStop stopStop, StopService unlockStop)
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
